using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model
{
    public partial  class GenerealApp :Common.ValidationIDataError
    {
        public bool Durum { get; set; } = true;

        public string AppID { get; set; } = AppSetting.GetAppID();
    }
}
