using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class Resim : ICopyMembers<Resim>
    {

        [DataType(DataType.Text)]
        [Required( ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(5, ErrorMessage = "5 karakterden az olamaz")]
        public string Url { get; set; }
      //  public Entity.App.Kullanici Kullanici { get; set; }
    }
}
