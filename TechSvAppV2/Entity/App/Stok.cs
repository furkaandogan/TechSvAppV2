using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class Stok : ICopyMembers<Stok>
    {
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public int Adet { get; set; }
    }
}
