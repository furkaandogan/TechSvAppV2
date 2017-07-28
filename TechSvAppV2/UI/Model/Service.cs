using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class Service : BaseModel
    {

        #region Members

        private Entity.App.Servis _model;
        private ObservableCollection<Entity.App.Servis> _services;
        private ObservableCollection<Entity.App.Musteri> _customers;
        private string _selectedProductType;
        private string _selectedBrand;
        private string _selectedServiceStatuName;
        private string _selectedServiceWarrantyName;
        private System.Windows.Visibility _dataVisibility;

        #endregion

        #region Properties

        public System.Windows.Visibility DataVisibility
        {
            get { return _dataVisibility; }
            set
            {
                _dataVisibility = value;
                OnPropertyChanged("DataVisibility");
            }
        }

        public ObservableCollection<Entity.App.Servis> Services
        {
            get { return _services; }
            set
            {
                _services = value;
                OnPropertyChanged("Services");
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
        public Entity.App.Servis Model
        {
            get
            {

                if (_model.ServisDetay != null)
                {
                    if (_model.ServisDetay.Musteri != null)
                    {
                        if (!string.IsNullOrEmpty(_model.ServisDetay.Musteri.Ad))
                            DataVisibility = System.Windows.Visibility.Collapsed;
                    }
                }
                return _model;
            }
            set
            {
                if (value != null)
                {
                    _model = value;
                    if (value.UrunTipi != null)
                    {
                        SelectedProductType = value.UrunTipi.Ad;
                        SelectedBrand = value.Marka.Ad;
                        SelectedServiceStatuName = value.ServisDetay.ServisDurumu.Ad;
                        SelectedServiceWarrantyName = value.GarantiDurum.ToString();
                        if (Model.ServisDetay.GirisTarihi == Model.ServisDetay.CikisTarihi)
                            Model.ServisDetay.CikisTarihi = DateTime.Now;
                    }
                    if (value.ServisDetay == null)
                    {
                        _model.ServisDetay = new Entity.App.ServisDetay();
                        _model.EklenmeTarihi = DateTime.Now;
                        _model.ServisDetay.GirisTarihi = DateTime.Now;
                        _model.ServisDetay.TakipKodu = Bin.AppSetting.CreatCodeKey(Services.Count);
                        _model.TakipKodu = Bin.AppSetting.CreatCodeKey(Services.Count);
                        _model.ServisDetay.Musteri = UI.Model.Const.DataAccess.Customer != null ? UI.Model.Const.DataAccess.Customer : new Entity.App.Musteri();
                        _model.ServisDetay.Kullanici = UI.Model.Const.DataAccess.User != null ? UI.Model.Const.DataAccess.User : new Entity.App.Kullanici();
                        _model.ServisDetay.ArizaSetileri = new List<Entity.App.ArizaSeti>(){
                        new Entity.App.ArizaSeti(){
                            Aciklama ="-----",
                            Ucret = new Entity.App.Ucret(){
                                AlisUcreti = 0,
                                KDVOrani = 0,
                                UcretDegeri = 0,
                                TakipKodu=Bin.AppSetting.CreatCodeKey(Services.Count),
                            },
                            TakipKodu=Bin.AppSetting.CreatCodeKey(Services.Count),

                        }
                        };
                        _model.ServisDetay.DisServisNotu = new List<Entity.App.DisServisNotu>()
                        {
                        new Entity.App.DisServisNotu(){
                            Aciklama ="-----",
                            GirisTarihi=DateTime.Now,
                            Ucret=new Entity.App.Ucret() {
                                UcretTipi=Entity.App.UcretTipiEnum.DısServis,
                                TakipKodu=Bin.AppSetting.CreatCodeKey(Services.Count),
                            },
                            DisServisKullanicisi=new Entity.App.DisServisKullanicisi(){
                                Ad="-----",
                                Email="dısservis@mail.com",
                                KullaniciSifresi="-----",
                                KullniciAdi="-----",
                                Soyad="-----",
                                TakipKodu=Bin.AppSetting.CreatCodeKey(Services.Count),

                            },
                            TakipKodu=Bin.AppSetting.CreatCodeKey(Services.Count),
                        },
                        };
                        _model.ServisDetay.Ekipmanlar = new List<Entity.App.Ekipman>(){
                            new Entity.App.Ekipman(){
                                Ad ="-----",
                                TakipKodu=Bin.AppSetting.CreatCodeKey(Services.Count),
                            }
                        };
                        _model.ServisDetay.Ucret = new Entity.App.Ucret()
                        {
                            AlisUcreti = 0,
                            KDVOrani = 0,
                            UcretDegeri = 0,
                            UcretTipi = Entity.App.UcretTipiEnum.Sevis,
                            TakipKodu = Bin.AppSetting.CreatCodeKey(Services.Count),
                        };
                        _model.ServisDetay.CikisTarihi = DateTime.Now;

                        _model.ServisDetay.Yapilanİslemler = "-----";
                    }
                    if (value.ServisDetay != null)
                    {
                        if (value.ServisDetay.Musteri != null)
                        {
                            if (!string.IsNullOrEmpty(value.ServisDetay.Musteri.Ad))
                                DataVisibility = System.Windows.Visibility.Collapsed;
                        }
                    }
                    OnPropertyChanged("Model");
                    if (value.UrunTipi != null)
                    {
                        if (value.UrunTipi.Ad != null)
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
                else
                {
                    ButtonEnable = false;
                }
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
        public List<string> SerivceStatusNames
        {
            get { return Bin.ActionEvent.ServiceStatusActionEvents.GetNames(); }
        }
        public string[] WarrantyNames
        {
            get { return Enum.GetNames(typeof(Bin.Model.App.GrantiDurumEnum)); }
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
                    if (value != "Ürün Tipi Seçiniz")
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
                    if (value != "Marka Seçiniz")
                        Model.Marka = Bin.ActionEvent.BrandActionEvents.Get(value).Model as Entity.App.Marka;
                    OnPropertyChanged("SelectedBrand");
                }
            }
        }
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string SelectedServiceStatuName
        {
            get { return _selectedServiceStatuName; }
            set
            {
                if (value != null)
                {
                    _selectedServiceStatuName = value;
                    if (value != "Servis Durumu Seçiniz")
                        Model.ServisDetay.ServisDurumu = Bin.ActionEvent.ServiceStatusActionEvents.Get(value);
                    OnPropertyChanged("SelectedServiceStatuName");
                }
            }
        }
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string SelectedServiceWarrantyName
        {
            get { return _selectedServiceWarrantyName; }
            set
            {
                if (value != null)
                {
                    _selectedServiceWarrantyName = value;
                    if (!string.IsNullOrEmpty(value) && value != "Ürün Garanti Durumu Seçiniz")
                    {
                        Model.GarantiDurum = (Entity.App.GarantiDurumEnum)Enum.Parse(typeof(Entity.App.GarantiDurumEnum), value, true);
                    }
                    OnPropertyChanged("SelectedServiceWarrantyName");
                }
            }
        }

        #endregion

        #region Constructor
        public Service()
        {
            result = Bin.ActionEvent.ServiceActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true);

            UI.Model.Const.Theme.Instance.AlertSet(result);
            Services = new ObservableCollection<Entity.App.Servis>(result.Model as List<Entity.App.Servis>);

            Model = new Entity.App.Servis();
            ButtonEnable = false;
            Tag = "Servis Kod | Marka | Müşteri Ad | Ürün Tipi";
            DataVisibility = System.Windows.Visibility.Collapsed;
        }

        #endregion



        #region Helpers

        public void ModelSet()
        {
            Model = new Entity.App.Servis();
            SelectedBrand = "";
            SelectedProductType = "";
            SelectedServiceStatuName = "";
            SelectedServiceWarrantyName = "";
        }

        public override void dateFilter()
        {
            Services = new ObservableCollection<Entity.App.Servis>((Bin.ActionEvent.ServiceActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Servis>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
        }
        public override void dataRowsCountFilter()
        {
            Services = new ObservableCollection<Entity.App.Servis>((Bin.ActionEvent.ServiceActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Servis>).Skip((/*StartRowIndex > Services.Count ? Services.Count :*/ StartRowIndex)).Take((/*EndRowIndex > Services.Count ? Services.Count :*/ EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            Services = new ObservableCollection<Entity.App.Servis>((Bin.ActionEvent.ServiceActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Servis>).Skip(0).Take((/*RowsValue > Services.Count ? Services.Count :*/ RowsValue)).ToList());
        }

        #endregion


    }
}
