using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App.Log
{
    public partial class MailLog : Base
    {
        //public int ID { get; set; }
        //public int MailAdresID { get; set; }
        //public int MailSablonID { get; set; }
        //public int MusteriID { get; set; }

        [StringLength(20)]
        [DataType(DataType.DateTime)]
        public DateTime GonderimTarihi { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual MailAdres MailAdres { get; set; }
        public virtual MailSablon MailSablon { get; set; }
    }
}
