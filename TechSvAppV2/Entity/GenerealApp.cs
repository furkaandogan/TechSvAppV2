using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public partial class GeneralApp :Common.ValidationIDataError
    {
        public int ID { get; set; }

        [StringLength(64)]
        [DataType(DataType.Text)]
        public string AppID { get; set; } = AppSettings.GetAppID();
        public bool Durum { get; set; }=true;

        [DataType(DataType.DateTime)]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime SilinmeTarihi { get; set; }=DateTime.Now;

        [DataType(DataType.Text)]
        public string TakipKodu { get; set; }
    }
}
