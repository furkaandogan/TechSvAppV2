using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model.Const
{
    public class Theme : EventBase
    {



        #region Properties

        //private Entity.App.Theme.ThemeBase _themeBase;
        //public Entity.App.Theme.ThemeBase ThemeBase
        //{
        //    get { return _themeBase; }
        //    set
        //    {
        //        _themeBase = value;
        //        OnPropertyChanged("ThemeBase");
        //    }
        //}

        private string _nagivate = "Yetkili Girişi";
        public string Nagivate
        {
            get { return _nagivate; }
            set
            {
                _nagivate = value;
                OnPropertyChanged("Nagivate");
            }
        }

        private string _nagivateMini = "Yetkili Girişi";
        public string NagivateMini
        {
            get { return _nagivateMini; }
            set
            {
                if (_nagivateMini.Split('/').Length > 11)
                {
                    _nagivateMini = "Dashboard";
                }
                _nagivateMini += " / " + value;
                OnPropertyChanged("NagivateMini");
            }
        }
        private string _backNagivateUrl = "Login";
        public string BackNagivateUrl
        {
            get { return _backNagivateUrl; }
        }
        private string _activeUrl = "Login";
        /// <summary>
        /// "/UI;component/View/Pages/" + value + ".xaml"
        /// </summary>
        public string ActiveUrl
        {
            get { return "/UI;component/View/Pages/" + _activeUrl + ".xaml"; }
            set
            {
                _backNagivateUrl = _activeUrl;
                _activeUrl = value;
                OnPropertyChanged("ActiveUrl");
            }
        }
        private string _publicAlertUrl = "/UI;component/View/Pages/none.xaml";
        /// <summary>
        /// "/UI;component/View/Controls/PublicAlert.xaml"
        /// </summary>
        public string PublicAlertUrl
        {
            get { return _publicAlertUrl; }
            set
            {
                _publicAlertUrl = value;
                OnPropertyChanged("PublicAlertUrl");
            }
        }

        private string _searchKey;
        public string SearchKey
        {
            get { return _searchKey; }
            set
            {
                _searchKey = value;
                OnPropertyChanged("SearchKey");
            }
        }

        #endregion


        /// <summary>
        /// geçici çüzüm kendi viewmodeli var
        /// </summary>

        #region PublicAlert

        private string _title;
        private string _message;
        private string _image;
        private string _background;
        private string _borderBrush;
        private bool state = true;

        private System.Threading.Thread PublicAlertHideThared;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        /// <summary>
        /// Background="#2ab677" BorderBrush="#18a767" result.IsError = false
        /// Background="#ca6455" BorderBrush="#ab4143" result.IsError = true
        /// </summary>
        public string Background
        {
            get { return _background; }
            set
            {
                _background = value;
                OnPropertyChanged("Background");
            }
        }
        public string BorderBrush
        {
            get { return _borderBrush; }
            set
            {
                _borderBrush = value;
                OnPropertyChanged("BorderBrush");
            }
        }

        public void AlertSet(Entity.Result result)
        {
            PublicAlertUrl = "/UI;component/View/Pages/none.xaml";
            if (result.IsError)
            {
                Title = "HATA";
                Background = "#ca6455";
                BorderBrush = "#ab4143";
                Image = "/UI;component/Resource/Images/Completed.png";
            }
            else
            {
                Title = "UYGULANDI";
                Background = "#2ab677";
                BorderBrush = "#18a767";
                Image = "/UI;component/Resource/Images/Completed.png";
            }
            Message = result.Message;
            PublicAlertUrl = "/UI;component/View/Controls/PublicAlert.xaml";

            if (PublicAlertHideThared.ThreadState == System.Threading.ThreadState.Unstarted)
                PublicAlertHideThared.Start();
            else if (PublicAlertHideThared.ThreadState == System.Threading.ThreadState.Suspended)
                PublicAlertHideThared.Resume();
        }

        private void PublicAlert()
        {
            while (state)
            {
                System.Threading.Thread.Sleep(4000);
                PublicAlertUrl = "/UI;component/View/Pages/none.xaml";
                PublicAlertHideThared.Suspend();
            }
        }

        public void PublicAlertHide()
        {
            PublicAlertUrl = "/UI;component/View/Pages/none.xaml";
        }
        public void PublicAlertStop()
        {
            try
            {
                state = false;
                PublicAlertHideThared.IsBackground = true;
                PublicAlertHideThared.DisableComObjectEagerCleanup();
                PublicAlertHideThared.Abort();

            }
            catch 
            {
            }
        }

        #endregion


        #region Singelton


        private static Theme _instance;
        public static Theme Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Theme();


                return _instance;
            }
        }

        private Theme()
        {
            PublicAlertHideThared = new System.Threading.Thread(PublicAlert);
            PublicAlertHideThared.IsBackground = false;
            //ThemeBase = (Bin.ActionEvent.Theme.ThemeBaseActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Theme.ThemeBase>).FirstOrDefault();

        }

        #endregion

    }
}
