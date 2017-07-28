using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public partial class MailGorev : ICopyMembers<MailGorev>
    {

        public virtual MailAdres MailAdres { get; set; }

        public virtual MailSablon MailSablon { get; set; }
      //  public Entity.App.Kullanici Kullanici { get; set; }
    }
}
