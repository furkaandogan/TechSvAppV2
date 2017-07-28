using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class DisServisKullanicisi : ICopyMembers<DisServisKullanicisi>
    {
       // public Entity.App.Kullanici Kullanici { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string Ad { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string Soyad { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(4, ErrorMessage = "4 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string KullniciAdi { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(4, ErrorMessage = "4 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "kullanıcı şifresi 20 karakterden fazla girilemez!")]
        public string KullaniciSifresi { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        [DefaultValue("defualt değer")]
        public string Email { get; set; }


    }
}
