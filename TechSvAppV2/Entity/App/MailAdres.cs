using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class MailAdres : ICopyMembers<MailAdres>
    {
        [MaxLength(50, ErrorMessage = "50 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string Adres { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla girilemez!")]
        [MinLength(8, ErrorMessage = "80 karakterden az girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [DefaultValue("defualt değer")]
        public string Sifre { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string Host { get; set; }


        [RegularExpression(@"[0-9]", ErrorMessage = "Geçersiz veri girişi bu alan sadece sayısal veri alır örn:80")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public int Port { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public bool SSL { get; set; }
       // public Entity.App.Kullanici Kullanici { get; set; }
    }
}
