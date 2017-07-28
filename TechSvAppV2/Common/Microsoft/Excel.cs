using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Microsoft
{
    public class ExcelExport<TEntity,TList> 
        where TList :ICollection<TList> 
        where TEntity :class,new()
    {
        private global::Microsoft.Office.Interop.Excel.Application _excelApp;
        private global::Microsoft.Office.Interop.Excel.Workbooks _books;
        private global::Microsoft.Office.Interop.Excel.Workbook _book;
        private global::Microsoft.Office.Interop.Excel.Sheets _sheets;
        private global::Microsoft.Office.Interop.Excel.Worksheet _workSheet;
        private global::Microsoft.Office.Interop.Excel.Range _range;
        private global::Microsoft.Office.Interop.Excel.Font _font;



        public TList Data { get; set; }

        public List<string> HeaderNameRule { get; set; }


        private object _optionalValue = Missing.Value;

        public ExcelExport ()
        {
            _excelApp = new global::Microsoft.Office.Interop.Excel.Application();
            _books = (global::Microsoft.Office.Interop.Excel.Workbooks)_excelApp.Workbooks;
            _book = (global::Microsoft.Office.Interop.Excel.Workbook)(_books.Add(_optionalValue));
            _sheets = (global::Microsoft.Office.Interop.Excel.Sheets)_book.Worksheets;
           // _workSheet = (global::Microsoft.Office.Interop.Excel.Worksheets)(_sheets.get_Item(1));
        }


        #region Methods

        public void openEcxel()
        {
            _excelApp.Visible = true;
        }

        public void export()
        {
            List<string> header = creatHeader();

        }

        private List<string> creatHeader()
        {
            List<string> headers = new List<string>();
            foreach (PropertyInfo info in typeof(TEntity).GetProperties())
            {
                if(headerRuleControl(info.Name))
                    headers.Add(info.Name);
            }
            var objHeader = headers.ToArray();
            //add
            return headers;
        }


        private void addExcelRow(string value,int rowIndex,int colunmIndex)
        {
           // _range=_workSheet.Range.ad
        }

        private bool headerRuleControl(string name)
        {
            if (HeaderNameRule != null)
            {
                foreach (string ruleName in HeaderNameRule)
                {
                    if (ruleName == name)
                        return false;
                }
            }
            return true;
        }

        private void addHeaderRule(string columnName)
        {
            if (string.IsNullOrEmpty(HeaderNameRule.Where(model => model.ToString() == columnName).ToList().FirstOrDefault()))
                HeaderNameRule.Add(columnName);
        }

        #endregion


    }
}
