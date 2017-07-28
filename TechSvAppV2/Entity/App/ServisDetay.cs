using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class ServisDetay : ICopyMembers<ServisDetay>
    {

        [DataType(DataType.DateTime)]
        public DateTime GirisTarihi { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CikisTarihi { get; set; }


        [DataType(DataType.Text)]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string Yapilanİslemler { get; set; }


        public virtual Musteri Musteri { get; set; }
                
        public virtual ServisDurumu ServisDurumu { get; set; } 

        public virtual Ucret Ucret { get; set; }
        public virtual List<ArizaSeti> ArizaSetileri { get; set; } 
        public virtual List<Ekipman> Ekipmanlar { get; set; }
        public virtual List<DisServisNotu> DisServisNotu { get; set; }
        public Entity.App.Kullanici Kullanici { get; set; }

    }
}
