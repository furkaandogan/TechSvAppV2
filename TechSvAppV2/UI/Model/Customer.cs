using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;

namespace UI.Model
{
    public class Customer : BaseModel
    {
        #region Members

        private Entity.App.Musteri _model;
        private ObservableCollection<Entity.App.Musteri> _customers = new ObservableCollection<Entity.App.Musteri>();

        #endregion

        #region Properties

        public Entity.App.Musteri Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                if (value != null)
                {
                    //_model.Kullanici = UI.Model.Const.DataAccess.User;
                    if (string.IsNullOrEmpty(value.TakipKodu))
                    {
                        _model.TakipKodu = Bin.AppSetting.CreatCodeKey(_customers.Count);
                        _model.EklenmeTarihi = DateTime.Now;
                    }
                    if (value.Ad != null)
                    {
                        ButtonEnable = true;
                    }
                    else
                    {
                        ButtonEnable = false;
                    }
                }
                else
                {
                    ButtonEnable = false;
                }
                OnPropertyChanged("Model");
            }
        }
        public ObservableCollection<Entity.App.Musteri> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged("Customers");
            }
        }


        #endregion

        public Customer()
        {
            result = Bin.ActionEvent.CustomerActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true);

            UI.Model.Const.Theme.Instance.AlertSet(result);
            Customers = new ObservableCollection<Entity.App.Musteri>(result.Model as List<Entity.App.Musteri>);

            Model = new Entity.App.Musteri();
            ButtonEnable = false;
            Tag = "Müşteri Takip Kod | Ad | Soyad | TC | Telefon | Mail | Adres";
        }

        #region Helpers

        public override void dateFilter()
        {
            Customers = new ObservableCollection<Entity.App.Musteri>((Bin.ActionEvent.CustomerActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Musteri>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
        }

        public override void dataRowsCountFilter()
        {
            Customers = new ObservableCollection<Entity.App.Musteri>((Bin.ActionEvent.CustomerActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Musteri>).Skip((/*StartRowIndex > Customers.Count ? Customers.Count :*/ StartRowIndex)).Take((/*EndRowIndex > Customers.Count ? Customers.Count :*/ EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            Customers = new ObservableCollection<Entity.App.Musteri>((Bin.ActionEvent.CustomerActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Musteri>).Skip(0).Take((/*RowsValue>Customers.Count? Customers.Count :*/RowsValue)).ToList());

        }

        #endregion
    }
}
