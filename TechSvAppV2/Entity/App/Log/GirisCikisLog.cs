using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App.Log
{
    public partial class GirisCikisLog :Base
    {

        public int ID { get; set; }
        public int KullaniciID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime GirisTarihi { get; set; }

        [StringLength(20)]
        [DataType(DataType.DateTime)]
        public DateTime CikisTarihi { get; set; }

    }
}
