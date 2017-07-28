using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class Urun : ICopyMembers<Urun>
    {
        public virtual UrunTipi UrunTipi { get; set; }

        public virtual Marka Marka { get; set; }

        public virtual Ucret Ucret { get; set; }

        public virtual Stok Stok { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla girilemez!")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [DataType(DataType.Text)]
        public string Model { get; set; }
       // public Entity.App.Kullanici Kullanici { get; set; }

    }
}
