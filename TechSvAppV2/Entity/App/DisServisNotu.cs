using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class DisServisNotu : ICopyMembers<DisServisNotu>
    {


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string Aciklama { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public DateTime GirisTarihi { get; set; }

        public virtual DisServisKullanicisi DisServisKullanicisi { get; set; }

        public virtual Ucret Ucret { get; set; }
    }
}
