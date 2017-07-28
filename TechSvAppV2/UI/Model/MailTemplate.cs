using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class MailTemplate :BaseModel
    {
        #region memebers

        private Entity.App.MailSablon _model;
        private ObservableCollection<Entity.App.MailSablon> _mailTemplares;

        #endregion

        #region properties

        public Entity.App.MailSablon Model
        {
            get { return _model; }
            set
            {
                _model = value;
                if (_model != null)
                {
                    if (_model.Baslik == null)
                    {
                        ButtonEnable = false;
                        _model.TakipKodu = Bin.AppSetting.CreatCodeKey(MailTemplates.Count);
                    }
                    else
                    {
                        ButtonEnable = true;
                    }
                }
                OnPropertyChanged("Model");
            }
        }
        public ObservableCollection<Entity.App.MailSablon> MailTemplates
        {
            get { return _mailTemplares; }
            set
            {
                _mailTemplares = value;
                OnPropertyChanged("MailTemplates");
            }
        }

        #endregion

        #region Constructor


        public MailTemplate() :base()
        {
            MailTemplates = new ObservableCollection<Entity.App.MailSablon>((Bin.ActionEvent.MailTemplateActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.MailSablon>).ToList());
            Model = new Entity.App.MailSablon();
            Tag = "Konu | İçerik";
        }

        #endregion

        #region Helpers

        public override void dateFilter()
        {
            MailTemplates = new ObservableCollection<Entity.App.MailSablon>((Bin.ActionEvent.MailTemplateActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.MailSablon>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
        }
        public override void dataRowsCountFilter()
        {
            MailTemplates = new ObservableCollection<Entity.App.MailSablon>((Bin.ActionEvent.MailTemplateActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.MailSablon>).Skip((/*StartRowIndex > Notifications.Count ? Notifications.Count :*/ StartRowIndex)).Take((/*EndRowIndex > Notifications.Count ? Notifications.Count :*/ EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            MailTemplates = new ObservableCollection<Entity.App.MailSablon>((Bin.ActionEvent.MailTemplateActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.MailSablon>).Skip(0).Take((/*RowsValue > Notifications.Count ? Notifications.Count :*/ RowsValue)).ToList());
        }

        #endregion
    }
}
