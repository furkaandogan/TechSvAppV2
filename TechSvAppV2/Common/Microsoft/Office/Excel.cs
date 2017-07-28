using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Microsoft.Office
{

    public enum RuleType
        : int
    {
        FuncRules = 0,
        StringRules = 1,
    }

    //public class Excel<TEntity>
    //    : IOfficeApp
    //    where TEntity : class, new()
    //{

    //    #region members

    //    #region private

    //    private global::Microsoft.Office.Interop.Excel.Application _app;
    //    private global::Microsoft.Office.Interop.Excel.Workbook _workBook;
    //    private global::Microsoft.Office.Interop.Excel.Worksheet _workSheet;
    //    private global::Microsoft.Office.Interop.Excel.Range _range;
    //    private object missing = System.Reflection.Missing.Value;


    //    #endregion


    //    public IDictionary<Func<TEntity, bool>, string> FuncRules { get; set; }
    //    public ICollection<string> StringRules { get; set; }
    //    private RuleType _ruleType;
    //    public RuleType RuleType
    //    {
    //        get { return _ruleType; }
    //        set
    //        {
    //            _ruleType = value;
    //            if (value == Office.RuleType.FuncRules)
    //                FuncRules = new Dictionary<Func<TEntity, bool>, string>();
    //            else
    //                StringRules = new List<string>();
    //        }
    //    }
    //    public ObservableCollection<TEntity> Model { get; set; }

    //    #endregion

    //    #region constructor

    //    public Excel()
    //    {
    //        RuleType = RuleType.StringRules;
    //        Model = new ObservableCollection<TEntity>();
    //        creat();
    //    }

    //    public Excel(ObservableCollection<TEntity> model)
    //    {
    //        RuleType = RuleType.StringRules;
    //        Model = model;
    //        creat();
    //    }

    //    public Excel(ObservableCollection<TEntity> model, RuleType ruleType)
    //    {
    //        RuleType = ruleType;
    //        Model = model;
    //        creat();
    //    }

    //    #endregion

    //    #region this methods



    //    #endregion

    //    #region IExcel members

    //    public void export()
    //    {
    //        if (Model == null)
    //            throw new Exception("null model");

    //        List<string> headerNames = getHeader().ToList();
    //        for (int index = 0; index < headerNames.Count; index++)
    //        {
    //            write(headerNames[index], 0, index);
    //        }
    //        for (int row = 1; row < Model.Count; row++)
    //        {
    //            for (int column = 0; column < typeof(TEntity).GetProperties().Length - (typeof(TEntity).GetProperties().Length - headerNames.Count); column++)
    //            {
    //                write(typeof(TEntity).InvokeMember(headerNames[column].ToString(), BindingFlags.GetProperty, null, (Model[row - 1]), null).ToString(), row, column);
    //            }
    //        }
    //    }

    //    public void creat()
    //    {
    //        try
    //        {
    //            _app = new global::Microsoft.Office.Interop.Excel.Application();
    //            _workBook = _app.Workbooks.Add(missing);
    //            _workSheet = (global::Microsoft.Office.Interop.Excel.Worksheet)_workBook.Worksheets.get_Item(1);
    //            _range = _workSheet.UsedRange;
    //            _workSheet = (global::Microsoft.Office.Interop.Excel.Worksheet)_workBook.ActiveSheet;
    //            _app.Visible = false;
    //            _app.AlertBeforeOverwriting = false;

    //        }
    //        catch (Exception)
    //        {
    //        }
    //    }

    //    public void open()
    //    {
    //        if (_app != null)
    //            _app.Visible = true;
    //    }

    //    public void save(string path)
    //    {
    //        if (!File.Exists(path))
    //            throw new Exception("An invalid address enrty");
    //        if (_workBook != null)
    //            _workBook.SaveAs(path);
    //    }

    //    public void write(string value, int row, int column)
    //    {
    //        value = value.Trim().ToString();
    //        if (!string.IsNullOrEmpty(value))
    //        {
    //            row += 1;
    //            column += 1;
    //            if (row < 1)
    //                throw new Exception("negtif and 0 row index value can not be");
    //            if (column < 1)
    //                throw new Exception("negtif and 0 column index value can not be");

    //            global::Microsoft.Office.Interop.Excel.Range myRange = (global::Microsoft.Office.Interop.Excel.Range)_workSheet.Cells[row, column];
    //            myRange.Value2 = value.Trim().ToString();
    //        }
    //    }

    //    public ICollection<string> getHeader()
    //    {
    //        List<string> headerName = new List<string>();
    //        foreach (PropertyInfo prop in typeof(TEntity).GetProperties())
    //        {
    //            if (!ruleControl(prop.Name))
    //                headerName.Add(prop.Name);
    //        }

    //        return headerName;
    //    }

    //    public bool ruleControl(string headerName)
    //    {
    //        if (RuleType == Office.RuleType.StringRules)
    //            foreach (string rule in StringRules)
    //            {
    //                if (rule == headerName)
    //                    return true;
    //            }
    //        else
    //            foreach (var rule in FuncRules)
    //            {
    //                if ((Model as List<TEntity>).Where(rule.Key).FirstOrDefault() == null)
    //                    return true;
    //            }
    //        return false;
    //    }

    //    public void addRule<TEntity>(Func<TEntity, bool> rule, string value)
    //    {
    //        //if (RuleType == null)
    //        //    throw new Exception("rule type is null you can not!");
    //        //if (RuleType == Office.RuleType.StringRules)
    //        //    throw new Exception("you chose Func Rule type you can not!");

    //        //if (!FuncRules.ContainsKey(rule))
    //        //    FuncRules.Add(rule, value);
    //        //else
    //        //    if (FuncRules[rule] != value)
    //        //        throw new Exception("different values ​​of the same rules you can not!");
    //        //    else
    //        //        FuncRules[rule] = value;
    //    }

    //    public void addRule<TEntity>(string value)
    //    {
    //        if (RuleType == null)
    //            throw new Exception("rule type is null you can not!");
    //        if (RuleType == Office.RuleType.FuncRules)
    //            throw new Exception("you chose String rule type you can not!");

    //        if (!StringRules.Contains(value))
    //            StringRules.Add(value);
    //    }

    //    #endregion


    //}
}
