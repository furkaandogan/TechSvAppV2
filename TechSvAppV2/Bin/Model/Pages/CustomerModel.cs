using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.Pages
{
    public partial class CustomerModel :ICopyMembers<CustomerModel>
    {
        public int ID { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings =true,ErrorMessage ="Müşteri Adı boş bırakılamaz!")]
        [MinLength(3,ErrorMessage ="Müşteri Adı 3 karakterden az olamaz")]
       // [RegularExpression(@"[A-Z] [a-z]", ErrorMessage ="Yanlış formatta girdiniz bu alan sadece metin girilebilir")]
        public string Ad { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = true, ErrorMessage = "Müşteri Soyadı boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "Müşteri Soyadı 3 karakterden az olamaz")]
       // [RegularExpression(@"[A-Z] [a-z]", ErrorMessage = "Yanlış formatta girdiniz bu alan sadece metin girilebilir")]
        public string Soyad { get; set; }

        [StringLength(10)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Müşteri telefonu boş bırakılamaz")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Yanlış Telefonu numarası girdiniz örn:5315031756")]
        public string Telefon { get; set; }

        [StringLength(11)]
        [DataType(DataType.Text)]
        [RegularExpression(@"[0-9]{11}",ErrorMessage ="Geçersiz Tc kimlik girdiniz")]
        public string Tc { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Adres { get; set; }

        [StringLength(64)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = true, ErrorMessage = "Müşteri Mail boş bırakılamaz!")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage ="geçersiz mail adresi girdiniz")]
        public string Mail { get; set; }

        public bool Durum { get; set; } = true;

        public string AppID { get; set; }="1";

        [Required(AllowEmptyStrings = true, ErrorMessage = "Seçim Yapmalısıznı")]
        public CustomerModel Selected { get; set; }

    }
}
