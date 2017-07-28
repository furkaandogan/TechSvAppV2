using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class Brand : BaseModel
    {

        #region Members

        private Entity.App.Marka _model;
        private ObservableCollection<Entity.App.Marka> _brands;

        #endregion

        #region Properties


        public ObservableCollection<Entity.App.Marka> Brands
        {
            get { return _brands; }
            set
            {
                _brands = value;
                OnPropertyChanged("Brands");
            }
        }
        public Entity.App.Marka Model
        {
            get { return _model; }
            set
            {
                if (value != null)
                {
                    _model = value;
                    _model.EklenmeTarihi = DateTime.Now;
                    _model.TakipKodu = Bin.AppSetting.CreatCodeKey(Brands.Count);
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
        public Brand()
        {
            result = Bin.ActionEvent.BrandActionEvents.GetList();

            UI.Model.Const.Theme.Instance.AlertSet(result);
            Brands = new ObservableCollection<Entity.App.Marka>(result.Model as List<Entity.App.Marka>);

            Model = new Entity.App.Marka();
            ButtonEnable = false;
            Tag = "Ad";
        }

        #endregion



        #region Helpers
        public override void dateFilter()
        {
            Brands = new ObservableCollection<Entity.App.Marka>((Bin.ActionEvent.BrandActionEvents.GetList().Model as List<Entity.App.Marka>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
            base.dateFilter();
        }

        public override void dataRowsCountFilter()
        {
            Brands = new ObservableCollection<Entity.App.Marka>((Bin.ActionEvent.BrandActionEvents.GetList().Model as List<Entity.App.Marka>).Skip((StartRowIndex)).Take((EndRowIndex > Brands.Count ? Brands.Count : EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            Brands = new ObservableCollection<Entity.App.Marka>((Bin.ActionEvent.BrandActionEvents.GetList().Model as List<Entity.App.Marka>).Skip(0).Take((RowsValue)).ToList());

        }
        #endregion
    }
}
