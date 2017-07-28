using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.App
{
    public partial class Ekipman :ICopyMembers<Ekipman>
    {
        public int ID { get; set; }
        public int ServisID { get; set; }

        [StringLength(140)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string Ad { get; set; }


    }
}
