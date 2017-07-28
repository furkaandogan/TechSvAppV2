using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class Repository :BaseModel
    {

        #region Members


        private Entity.App.Urun _model;
        private ObservableCollection<Entity.App.Urun> _products;
        private string _stok;
        private string _kdv;
        private string _alisFiyati;
        private string _selectedProductType;
        private string _selectedBrand;


        #endregion


        #region Properteis

        public Entity.App.Urun Model
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
                    if (_model.TakipKodu == null)
                    {
                        _model.TakipKodu = Bin.AppSetting.CreatCodeKey(Products.Count);
                        _model.Ucret = new Entity.App.Ucret();
                        _model.Stok = new Entity.App.Stok();
                        _model.UrunTipi = new Entity.App.UrunTipi();
                        _model.Marka = new Entity.App.Marka();
                        _model.Ucret.UcretTipi = Entity.App.UcretTipiEnum.Urun;
                        Stok = string.Empty;
                        AlisUcreti = string.Empty;
                        Kdv = string.Empty;
                    }
                    else
                    {
                        AlisUcreti = _model.Ucret.AlisUcreti.ToString();
                        Kdv = _model.Ucret.KDVOrani.ToString();
                        Stok = _model.Stok.Adet.ToString();
                        ButtonEnable = true;
                    }
                }
                OnPropertyChanged("Model");
            }
        }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string Stok
        {
            get { return _stok; }
            set
            {
                _stok = value;
                if (!string.IsNullOrEmpty(value))
                {
                    if (int.Parse(value) < 0)
                        _stok = (0).ToString();

                    Model.Stok.Adet = int.Parse(_stok);
                }

                OnPropertyChanged("Stok");
            }
        }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string Kdv
        {
            get { return _kdv; }
            set
            {
                _kdv = value;
                if (!string.IsNullOrEmpty(value))
                {
                    if (int.Parse(value) < 0)
                        _kdv = (0).ToString();
                    if (int.Parse(value) > 100)
                        _kdv = (10).ToString();

                    Model.Ucret.KDVOrani = int.Parse(_kdv);
                    Model.Ucret.UcretDegeri = Model.Ucret.AlisUcreti + (_model.Ucret.KDVOrani * (Model.Ucret.AlisUcreti / 100));
                }
                OnPropertyChanged("Kdv");
            }
        }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string AlisUcreti
        {
            get { return _alisFiyati; }
            set
            {
                _alisFiyati = value;
                if (!string.IsNullOrEmpty(value))
                {
                    if (int.Parse(value) < 0)
                        _alisFiyati = (0).ToString();

                    Model.Ucret.AlisUcreti = int.Parse(_alisFiyati);
                    Model.Ucret.UcretDegeri = Model.Ucret.AlisUcreti + (_model.Ucret.KDVOrani * (Model.Ucret.AlisUcreti / 100));
                }
                OnPropertyChanged("AlisUcreti");
            }
        }
        public ObservableCollection<Entity.App.Urun> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        public List<string> ProductTypeNames
        {
            get { return Bin.ActionEvent.ProductTypeActionEvents.GetNames(); }
        }
        public List<string> BrandNames
        {
            get { return Bin.ActionEvent.BrandActionEvents.GetNames(); }
        }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string SelectedProductType
        {
            get { return _selectedProductType; }
            set
            {
                if (value != null)
                {
                    _selectedProductType = value;
                    //if (value != "Ürün Tipi Seçiniz")
                        Model.UrunTipi = Bin.ActionEvent.ProductTypeActionEvents.Get(value).Model as Entity.App.UrunTipi;
                    OnPropertyChanged("SelectedProductType");
                }
            }
        }
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string SelectedBrand
        {
            get { return _selectedBrand; }
            set
            {
                if (value != null)
                {
                    _selectedBrand = value;
                    //if (value != "Marka Seçiniz")
                        Model.Marka = Bin.ActionEvent.BrandActionEvents.Get(value).Model as Entity.App.Marka;
                    OnPropertyChanged("SelectedBrand");
                }
            }
        }
        #endregion

        #region Constructor

        public Repository() :base()
        {
            Products = new ObservableCollection<Entity.App.Urun>((Bin.ActionEvent.RepositoryActionEvents.GetList(model=>model.AppID==Bin.Model.AppSettingModel.AppID && model.Durum==true).Model as List<Entity.App.Urun>).ToList());
            Model = new Entity.App.Urun();
            ButtonEnable = false;
            Tag = "Model | Marka | Ürün Tipi | Ücret";
        }

        #endregion

        #region Helpers

        public override void dateFilter()
        {
            Products = new ObservableCollection<Entity.App.Urun>((Bin.ActionEvent.RepositoryActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Urun>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
        }
        public override void dataRowsCountFilter()
        {
            Products = new ObservableCollection<Entity.App.Urun>((Bin.ActionEvent.RepositoryActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Urun>).Skip((/*StartRowIndex > Notifications.Count ? Notifications.Count :*/ StartRowIndex)).Take((/*EndRowIndex > Notifications.Count ? Notifications.Count :*/ EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            Products = new ObservableCollection<Entity.App.Urun>((Bin.ActionEvent.RepositoryActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Urun>).Skip(0).Take((/*RowsValue > Notifications.Count ? Notifications.Count :*/ RowsValue)).ToList());
        }

        #endregion

    }
}
