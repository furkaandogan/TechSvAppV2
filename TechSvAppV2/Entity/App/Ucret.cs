using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class Ucret : ICopyMembers<Ucret>
    {


        [Required(ErrorMessage = "Boş bırakılamaz!")]
      //  [RegularExpression(@"^\w*$", ErrorMessage = "geçersiz veri girdiniz sadece sayısal veri girilebilir")]
        public double KDVOrani { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
      //  [RegularExpression(@"^\w*$", ErrorMessage = "geçersiz veri girdiniz sadece sayısal veri girilebilir")]
        public double UcretDegeri { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
       // [RegularExpression(@"^\w*$", ErrorMessage = "geçersiz veri girdiniz sadece sayısal veri girilebilir")]
        public double AlisUcreti { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public UcretTipiEnum UcretTipi { get; set; }
    }
}
