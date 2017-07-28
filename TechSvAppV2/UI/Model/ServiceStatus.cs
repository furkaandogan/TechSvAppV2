using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class ServiceStatus : BaseModel
    {
        #region Members

        private Entity.App.ServisDurumu _model;
        private ObservableCollection<Entity.App.ServisDurumu> _serviceStatu;

        #endregion

        #region Properties

        public Entity.App.ServisDurumu Model
        {
            get { return _model; }
            set
            {
                if (value != null)
                {
                    _model = value;
                    _model.TakipKodu = Bin.AppSetting.CreatCodeKey(ServiceStatu.Count);
                    _model.EklenmeTarihi = DateTime.Now;
                    if (_model.Resim == null)
                    {
                        _model.Resim = new Entity.App.Resim();
                        _model.Resim.TakipKodu = Bin.AppSetting.CreatCodeKey(ServiceStatu.Count);
                    }
                    OnPropertyChanged("Model");
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
            }
        }

        public ObservableCollection<Entity.App.ServisDurumu> ServiceStatu
        {
            get { return _serviceStatu; }
            set
            {
                _serviceStatu = value;
                OnPropertyChanged("ServiceStatu");
            }
        }

        #endregion

        #region Constructor

        public ServiceStatus()
        {
            result = Bin.ActionEvent.ServiceStatusActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true);

            UI.Model.Const.Theme.Instance.AlertSet(result);
            ServiceStatu = new ObservableCollection<Entity.App.ServisDurumu>(result.Model as List<Entity.App.ServisDurumu>);

            Model = new Entity.App.ServisDurumu();
            Tag = "Ad";
        }

        #endregion

        #region Helpers

        public override void dateFilter()
        {
            ServiceStatu = new ObservableCollection<Entity.App.ServisDurumu>((Bin.ActionEvent.ServiceStatusActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.ServisDurumu>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
        }
        public override void dataRowsCountFilter()
        {
            ServiceStatu = new ObservableCollection<Entity.App.ServisDurumu>((Bin.ActionEvent.ServiceStatusActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.ServisDurumu>).Skip((/*StartRowIndex > ServiceStatu.Count ? ServiceStatu.Count :*/ StartRowIndex)).Take((/*EndRowIndex > ServiceStatu.Count ? ServiceStatu.Count : */EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            ServiceStatu = new ObservableCollection<Entity.App.ServisDurumu>((Bin.ActionEvent.ServiceStatusActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.ServisDurumu>).Skip(0).Take((/*RowsValue > ServiceStatu.Count ? ServiceStatu.Count :*/ RowsValue)).ToList());
        }

        #endregion

    }
}
