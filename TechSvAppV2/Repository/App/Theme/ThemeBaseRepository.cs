using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App.Theme
{
    public class ThemeBaseRepository :BaseRepository<Entity.App.Theme.ThemeBase>
    {
        public ThemeBaseRepository() :base(Data.TechSvAppContext.Instance)
        {
        }
    }
}
