using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public partial class AppTheme : ICopyMembers<AppTheme>
    {
        public string BorderBrush { get; set; }
        public string BackgroundBrush { get; set; }

    }
}
