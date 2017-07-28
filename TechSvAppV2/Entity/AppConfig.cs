using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public partial class AppConfig : ICopyMembers<AppConfig>
    {
        [StringLength(140)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string FtpServer { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string FtpUser { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string FtpPassword { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string DataBaseServer { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string DataBaseName { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string DataBaseUser { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(6, ErrorMessage = "6 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla girilemez!")]
        public string DataBasePassword { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LicenseExpiryDate { get; set; }

        public int KritikStok { get; set; }

    }
}
