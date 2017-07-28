using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class UrunTipi : ICopyMembers<UrunTipi>
    {

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla girilemez!")]
        public string Ad { get; set; }

    }
}
