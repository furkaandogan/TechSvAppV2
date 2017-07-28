using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class Musteri : ICopyMembers<Musteri>
    {

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

        [MaxLength(11, ErrorMessage = "11 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        //^[+]90[-]d{3}[-]d{3}[-]d{4}$
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Yanlış Telefonu numarası girdiniz örn:05315031756")]

        public string Telefon { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Geçersiz Tc kimlik girdiniz")]
        [MaxLength(11, ErrorMessage = "11 karakterden fazla girilemez!")]
        public string Tc { get; set; }

        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        public string Adres { get; set; }

        [MaxLength(140,ErrorMessage = "140 karakterden fazla girilemez!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "geçersiz mail adresi girdiniz")]
        public string Mail { get; set; }
        
        // public Entity.App.Kullanici Kullanici { get; set; }

    }
}
