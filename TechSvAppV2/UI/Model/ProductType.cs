using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class ProductType : BaseModel
    {

        #region Members

        private Entity.App.UrunTipi _model;
        private ObservableCollection<Entity.App.UrunTipi> _productTypes;

        #endregion

        #region Properties


        public ObservableCollection<Entity.App.UrunTipi> ProductTypes
        {
            get { return _productTypes; }
            set
            {
                _productTypes = value;
                OnPropertyChanged("ProductTypes");
            }
        }
        public Entity.App.UrunTipi Model
        {
            get { return _model; }
            set
            {
                if (value != null)
                {
                    _model = value;
                    _model.TakipKodu= Bin.AppSetting.CreatCodeKey(ProductTypes.Count);
                    _model.EklenmeTarihi = DateTime.Now;
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

        #endregion

        #region Constructor
        public ProductType()
        {
            result = Bin.ActionEvent.ProductTypeActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true);

            UI.Model.Const.Theme.Instance.AlertSet(result);
            ProductTypes = new ObservableCollection<Entity.App.UrunTipi>(result.Model as List<Entity.App.UrunTipi>);

            Model = new Entity.App.UrunTipi();
            ButtonEnable = false;
            Tag = "Ad";
        }

        #endregion



        #region Helpers

        public override void dateFilter()
        {
            ProductTypes = new ObservableCollection<Entity.App.UrunTipi>((Bin.ActionEvent.ProductTypeActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.UrunTipi>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
        }
        public override void dataRowsCountFilter()
        {
            ProductTypes = new ObservableCollection<Entity.App.UrunTipi>((Bin.ActionEvent.ProductTypeActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.UrunTipi>).Skip((/*StartRowIndex > ProductTypes.Count ? ProductTypes.Count : */StartRowIndex)).Take((/*EndRowIndex > ProductTypes.Count ? ProductTypes.Count :*/ EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            ProductTypes = new ObservableCollection<Entity.App.UrunTipi>((Bin.ActionEvent.ProductTypeActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.UrunTipi>).Skip(0).Take((/*RowsValue > ProductTypes.Count ? ProductTypes.Count :*/ RowsValue)).ToList());
        }

        #endregion
    }
}
