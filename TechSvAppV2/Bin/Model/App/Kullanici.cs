using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.App
{
    public partial class Kullanici : ICopyMembers<Kullanici>
    {
        public int ID { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        [MinLength(3, ErrorMessage = "3 karakterden az girilemez!")]
        public string Ad { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        [MinLength(3, ErrorMessage = "3 karakterden az girilemez!")]
        public string Soyad { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        [MinLength(6, ErrorMessage = "6 karakterden az girilemez!")]
        public string KullniciAdi { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "20 karakterden fazla girilemez!")]
        [MinLength(6, ErrorMessage = "6 karakterden az girilemez!")]
        public string KullaniciSifresi { get; set; }

        [StringLength(140)]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string Email { get; set; }

    }
}
