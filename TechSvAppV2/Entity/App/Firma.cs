using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public class Firma : ICopyMembers<Firma>
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string Ad { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(11, ErrorMessage = "11 karakterden az olamaz")]
        [MaxLength(11, ErrorMessage = "11 karakterden fazla girilemez!")]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Yanlış Telefonu numarası girdiniz örn:02164440404")]
        public string Telefon { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(11, ErrorMessage = "11 karakterden az olamaz")]
        [MaxLength(11, ErrorMessage = "11 karakterden fazla girilemez!")]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Yanlış Telefonu numarası girdiniz örn:02164440404")]
        public string Fax { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(11, ErrorMessage = "11 karakterden az olamaz")]
        [MaxLength(11, ErrorMessage = "11 karakterden fazla girilemez!")]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Yanlış Telefonu numarası girdiniz örn:05315031756")]
        public string GSM { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "geçersiz mail adresi girdiniz")]
        public string Email { get; set; }

        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string Adres { get; set; }

        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string VergiDairesi { get; set; }

        [MinLength(10, ErrorMessage = "10 karakterden az olamaz")]
        [MaxLength(10, ErrorMessage = "10 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string VergiNumarasi { get; set; }

        public virtual Resim Resim { get; set; }

        public virtual AppConfig AppConfig { get; set; }

    }
}
