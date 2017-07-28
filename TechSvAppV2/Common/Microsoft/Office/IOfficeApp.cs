using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Microsoft.Office
{
    public interface IOfficeApp
    {
        void open();
        void export();
        void creat();
        void save(string path);
        bool ruleControl(string headerName);
        ICollection<string> getHeader();
        void write(string value, int row, int column);
        void addRule<TEntity>(Func<TEntity, bool> rule, string value);
        void addRule<TEntity>(string value);
     //   object Model { get; set; }

    }
}