using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model
{
    public class ICopyMembers<TModel> :GenerealApp, ICloneable
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public TModel MeCopy()
        {
            return (TModel)this.MemberwiseClone();
        }
        public TModel MyClone()
        {
            return (TModel)this.MemberwiseClone();
        }
        public TModel MeCopy<TModel>()
        {
            return (TModel)this.MemberwiseClone();
        }
        public TModel MyClone<TModel>()
        {
            return (TModel)this.MemberwiseClone();
        }

    }
}
