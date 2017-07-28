using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.App
{
    public class Hakkında :ICopyMembers<Hakkında>
    {

        public bool SaticiBayiDurum { get; set; }
        public string SaticiBayi { get; set; }
        public string SaticiBayiYetkilisi { get; set; }

        [DataType(DataType.Text)]
        public string Ad { get; set; }

        [DataType(DataType.Text)]
        public string Model { get; set; }

        [DataType(DataType.Text)]
        public string Surum { get; set; }
        public LisenceType LisansTipi { get; set; }

        [DataType(DataType.Text)]
        public string LisansIcerigi { get; set; }



    }
}
