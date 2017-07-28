using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class Marka : ICopyMembers<Marka>
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string Ad { get; set; }
      //  public Entity.App.Kullanici Kullanici { get; set; }
    }
}
