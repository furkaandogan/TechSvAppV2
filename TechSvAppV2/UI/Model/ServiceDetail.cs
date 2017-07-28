using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class ServiceDetail : BaseModel
    {
        #region Memebers

        private Entity.App.Servis _model;
        private List<string> _faultSets;
        private List<string> _equipments;
        private string _selectedFaulSet;
        private string _selectedEquipment;
        private string _selectedProductType;
        private string _selectedBrand;
        private string _selectedServiceStatuName;
        private string _selectedServiceWarrantyName;

        #endregion

        #region Properties

        public Entity.App.Servis Model
        {
            get { return _model; }
            set
            {
                _model = value;
                SelectedProductType = value.UrunTipi.Ad;
                SelectedBrand = value.Marka.Ad;
                SelectedServiceStatuName = value.ServisDetay.ServisDurumu.Ad;
                SelectedServiceWarrantyName = value.GarantiDurum.ToString();
                if (_model.ServisDetay.Yapilanİslemler == "-----")
                    _model.ServisDetay.Yapilanİslemler = null;
                OnPropertyChanged("Model");
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

        public List<string> FaultSets
        {
            get { return _faultSets; }
            set
            {
                _faultSets = value;
                OnPropertyChanged("FaultSets");
            }
        }
        public List<string> Equipments
        {
            get { return _equipments; }
            set
            {
                _equipments = value;
                OnPropertyChanged("Equipments");
            }
        }
        public string SelectedFaultSet
        {
            get { return _selectedFaulSet; }
            set
            {
                _selectedFaulSet = value;
                OnPropertyChanged("SelectedFaultSet");
            }
        }
        public string SelectedEquipment
        {
            get { return _selectedEquipment; }
            set
            {
                _selectedEquipment = value;
                OnPropertyChanged("SelectedEquipment");
            }
        }

        #endregion


        public ServiceDetail()
        {
            Model = UI.Model.Const.DataAccess.Service;
            foreach (Entity.App.ArizaSeti faulSet in Model.ServisDetay.ArizaSetileri)
            {
                if (faulSet.Aciklama != "-----")
                    FaultSets.Add(faulSet.Aciklama);
            }
            foreach (Entity.App.Ekipman equipments in Model.ServisDetay.Ekipmanlar)
            {
                if (equipments.Ad != "-----")
                    FaultSets.Add(equipments.Ad);
            }

            Tag = "Ad";
        }


    }
}
