using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.App
{
    public partial class Servis :ICopyMembers<Servis>
    {
        public int ID { get; set; }
        
        [StringLength(140)]
        [DataType(DataType.Text)]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla girilemez!")]
        public string MusteriSikayeti { get; set; }

        public DateTime Tarih { get; set; }
        public string ServisKod { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        public string SelectedUrunTipi { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Boş bırakılamaz!")]
        public string SelectedMarka { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        public string SelectedServisDurumu { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        public string SelectedGarantiDurumu { get; set; }
    }
}
