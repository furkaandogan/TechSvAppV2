using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.App
{
    public partial class ServisDetay :ICopyMembers<ServisDetay>
    {
        public int ID { get; set; }

        #region eski
        //public int UcretID { get; set; }
        //public int ServisID { get; set; }
        //public int ArizaSetiID { get; set; }
        //public int DisServisID { get; set; }

        #endregion

        [DataType(DataType.DateTime)]
        public DateTime GirisTarihi { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CikisTarihi { get; set; }


        [StringLength(140)]
        [DataType(DataType.Text)]
        public string Yapilanİslemler { get; set; }
    }
}
