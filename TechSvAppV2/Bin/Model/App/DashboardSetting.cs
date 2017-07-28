using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.App
{
    public partial class DashboardSetting :Entity.ICopyMembers<DashboardSetting>
    {
        public static Dictionary<string, string> pageValue = new Dictionary<string, string>()
        {
            { "Kargo durumları sorgu penceresi", "ServiceStatus" },
            { "Kritik Stok Takip", "InventoryTracking" },
            { "Markaya göre istatistik", "BrandChart" },
            { "Kaynak Kullanımı", "UseResource" },
            { "Bildirimler", "Notification" },
            //{ "Marka sorgu penceresi", "Brand" },
            //{ "Ürün tipine göre istatistik", "ProductTypeChart" },
            //{ "Ürün tipi sorgu penceresi", "ProductTypeChart" },
        };
        private List<string> _exFrameList = new List<string>()
        {
            "Kargo durumları sorgu penceresi",
            "Markaya göre istatistik",
            "Kritik Stok Takip",
            "Kaynak Kullanımı",
            "Bildirimler",
        };
        public List<String> ExFrameList
        {
            get { return _exFrameList; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        public string ExFrema_1_Selected { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        public string ExFrema_2_Selected { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        public string ExFrema_3_Selected { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Boş bırakılamaz!")]
        public string ExFrema_4_Selected { get; set; }



    }
}
