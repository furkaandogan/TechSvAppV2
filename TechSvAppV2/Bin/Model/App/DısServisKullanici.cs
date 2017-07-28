using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.App
{
    public partial class DısServisKullanici : ICopyMembers<DısServisKullanici>
    {
        public int ID { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string Ad { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string Soyad { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string KullniciAdi { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "kullanıcı şifresi 20 karakterden fazla girilemez!")]
        public string KullaniciSifresi { get; set; }

        [StringLength(140)]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string Email { get; set; }

    }
}
