using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Common
{
    public class WindowsManagment:IDisposable
    {

        private Dictionary<string, Window> _windows;
        private string _maniViewName;
        private static object syncRoot = new Object();

        public string MainViewName
        {
            get { return _maniViewName; }
            set
            {
                _maniViewName = value;
            }
        }

        public Dictionary<string,Window> Windows 
        {
            get { return _windows; }
            set
            {
                _windows = value;
            }
        }


        public Window this[string name]
        {
            get
            {
                return Windows[name];
            }
        }

        #region Singelton

        private static WindowsManagment _instance;
        public static WindowsManagment Instance 
        {
            get
            {
                    if (_instance == null)
                        lock(syncRoot)
                            _instance = new WindowsManagment();
                    return _instance;

            }
        }

        private WindowsManagment()
        {
            Windows = new Dictionary<string, Window>();
        }

        #endregion

        public void AddWindow(string name,Window window)
        {
            if (Windows.ContainsKey(name))
                Windows[name] = window;
            else
                Windows.Add(name, window);
        }

        public void DeleteWindow(string name)
        {
            if (Windows.ContainsKey(name))
                Windows.Remove(name);
        }

        public void CloseWindow(string name)
        {
            if (Windows.ContainsKey(name))
            {
                Windows[name].Close();
                Windows.Remove(name);
            }
        }

        public void Dispose()
        {
            Windows.Clear();
        }
    }
}
