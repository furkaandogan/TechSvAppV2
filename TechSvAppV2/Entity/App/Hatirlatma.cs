using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class Hatirlatma : ICopyMembers<Hatirlatma>
    {
        
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public DateTime HatırlatmaTarihi { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string Konu { get; set; }

        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string İcerik { get; set; }

        public Entity.App.Kullanici Kullanici { get; set; }
    }
}
