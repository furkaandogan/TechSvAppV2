using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.App
{
    public partial class ServisDurum :ICopyMembers<ServisDurum>
    {
        public int ID { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "3 karakterden az olamaz")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla girilemez!")]
        public string Ad { get; set; }
        public int Count { get; set; }

    }
}
