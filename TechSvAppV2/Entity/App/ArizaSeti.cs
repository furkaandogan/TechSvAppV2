using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class ArizaSeti : ICopyMembers<ArizaSeti>
    {

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string Aciklama { get; set; }
      //  public Entity.App.Kullanici Kullanici { get; set; }
        public virtual Ucret Ucret { get; set; }


    }
}
