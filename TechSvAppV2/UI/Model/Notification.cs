using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.Model
{
    public class Notification :BaseModel
    {
        #region Members

        private Entity.App.Hatirlatma _model;
        private ObservableCollection<Entity.App.Hatirlatma> _notifications;
        private Thickness _margin = new Thickness(0, -5, 0, 0);

        #endregion


        #region Properties

        public Entity.App.Hatirlatma Model
        {
            get
            {
                if (_model != null)
                {
                    if (_model.HatırlatmaTarihi < DateTime.Now)
                        _model.HatırlatmaTarihi = DateTime.Now + TimeSpan.FromDays(1);
                }

                return _model;
            }
            set
            {
                _model = value;
                if (_model != null)
                {
                    _model.TakipKodu = Bin.AppSetting.CreatCodeKey(Notifications.Count);
                    _model.Kullanici = Const.DataAccess.User;
                    if (string.IsNullOrEmpty(_model.Konu))
                    {
                        ButtonEnable = false;
                        _model.EklenmeTarihi = DateTime.Now;
                        _model.HatırlatmaTarihi = DateTime.Now + TimeSpan.FromDays(1);
                        _model.Kullanici = Const.DataAccess.User;
                    }
                    else
                    {
                        ButtonEnable = true;
                    }
                    if (_model.HatırlatmaTarihi < DateTime.Now)
                        _model.HatırlatmaTarihi = DateTime.Now + TimeSpan.FromDays(1);
                }
                OnPropertyChanged("Model");
            }
        }

        public ObservableCollection<Entity.App.Hatirlatma> Notifications
        {
            get { return _notifications; }
            set
            {
                _notifications = value;                
                OnPropertyChanged("Notifications");
            }
        }
        //0,-5,0,0;
        public Thickness Margin
        {
            get { return _margin; }
            set
            {
                _margin = value;
                OnPropertyChanged("Margin");
            }
        }
        #endregion


        #region Singelton

        public Notification() :base()
        {
            Notifications = new ObservableCollection<Entity.App.Hatirlatma>(Bin.ActionEvent.NotificationsActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Hatirlatma>);
            Model = new Entity.App.Hatirlatma();
            Tag = "Konu | Kullanıcı Adı | Ad";
        }

        #endregion

        #region Helpers

        public override void dateFilter()
        {
            Notifications = new ObservableCollection<Entity.App.Hatirlatma>((Bin.ActionEvent.NotificationsActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Hatirlatma>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
        }
        public override void dataRowsCountFilter()
        {
            Notifications = new ObservableCollection<Entity.App.Hatirlatma>((Bin.ActionEvent.NotificationsActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Hatirlatma>).Skip((/*StartRowIndex > Notifications.Count ? Notifications.Count :*/ StartRowIndex)).Take((/*EndRowIndex > Notifications.Count ? Notifications.Count :*/ EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            Notifications = new ObservableCollection<Entity.App.Hatirlatma>((Bin.ActionEvent.NotificationsActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Hatirlatma>).Skip(0).Take((/*RowsValue > Notifications.Count ? Notifications.Count :*/ RowsValue)).ToList());
        }

        #endregion



    }
}
