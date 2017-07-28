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
    public partial class Kullanici : ICopyMembers<Kullanici>
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        [MinLength(3, ErrorMessage = "3 karakterden az girilemez!")]
        public string Ad { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        [MinLength(3, ErrorMessage = "3 karakterden az girilemez!")]
        public string Soyad { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        [MinLength(5, ErrorMessage = "5 karakterden az girilemez!")]
        public string KullniciAdi { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        [MinLength(5, ErrorMessage = "5 karakterden az girilemez!")]
        public string KullaniciSifresi { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "geçersiz mail adresi girdiniz")]
        public string Email { get; set; }
        
    }
}
