using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.Pages
{
    public partial class DashboardSettingModel : ICopyMembers<DashboardSettingModel>
    {
        public static Dictionary<string, string> pageValue = new Dictionary<string, string>()
        {
            { "Kargo durumları sorgu penceresi", "ServiceStatus" },
            { "Markaya göre istatistik", "BrandChart" },
            { "Marka sorgu penceresi", "Brand" },
            { "Ürün tipine göre istatistik", "ProductTypeChart" },
            { "Ürün tipi sorgu penceresi", "ProductTypeChart" },
        };
        private List<string> _exFrameList = new List<string>()
        {
            "Kargo durumları sorgu penceresi",
            "Marka sorgu penceresi",
            "Markaya göre istatistik"
        };
        public List<String> ExFrameList
        {
            get { return _exFrameList; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş geçilemez!")]
        public string ExFrema_1_Selected { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş geçilemez!")]
        public string ExFrema_2_Selected { get; set; }
        

    }
}
