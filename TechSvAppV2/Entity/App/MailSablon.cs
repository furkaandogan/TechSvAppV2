using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class MailSablon : ICopyMembers<MailSablon>
    {

        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string Baslik { get; set; }

        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string İcerik { get; set; }
      //  public Entity.App.Kullanici Kullanici { get; set; }

    }
}
