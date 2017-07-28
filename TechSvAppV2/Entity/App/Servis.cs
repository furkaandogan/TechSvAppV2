using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class Servis : ICopyMembers<Servis>
    { 
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string MusteriSikayeti { get; set; }
        public virtual GarantiDurumEnum GarantiDurum { get; set; }       
        public virtual Marka Marka { get; set; }
        public virtual UrunTipi UrunTipi { get; set; } 
        public virtual ServisDetay ServisDetay { get; set; }


        public Servis()
        {
        }
        public Servis(string musteriSikayeti,GarantiDurumEnum garantiDurumu,Marka marka,UrunTipi urunTipi,ServisDetay servisDetay)
        {
            this.MusteriSikayeti = musteriSikayeti;
            this.GarantiDurum = garantiDurumu;
            this.Marka = marka;
            this.UrunTipi = urunTipi;
            this.ServisDetay = servisDetay;
        }
    }
}
