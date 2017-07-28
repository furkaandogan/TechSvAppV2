using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exline.Cache
{
    internal class ExCacheModel
    {
        internal object Data { get; set; }
        internal string Date { get; set; }
        internal ExCacheModel(object CacheModel, string Date)
        {
            this.Data = CacheModel;
            this.Date = Date;
        }
    }
    internal class ExCacheModel<Model>
    {
        internal Model Data { get; set; }
        internal string Date { get; set; }
        internal ExCacheModel(Model CacheModel, string Date)
        {
            this.Data = CacheModel;
            this.Date = Date;
        }
    }
}
