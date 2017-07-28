using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UI
{
    /// <summary>
    /// Interaction logic for SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {

        #region members

        private Thread loadingThread;
        private Storyboard Showboard;
        private Storyboard Hideboard;

        private delegate void ShowDelegate(string text);
        private delegate void HideDelegate();
        private delegate void LoadExDelegate();

        private ShowDelegate showDelegate;
        private HideDelegate hideDelegate;
        private LoadExDelegate loadExtensionsDelegate;

        private bool loadComplete = false;


        #endregion

        #region Properteis



        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(SplashScreenWindow));



        #endregion


        public SplashScreenWindow()
        {
            InitializeComponent();
            showDelegate = new ShowDelegate(this.ShowText);
            hideDelegate = new HideDelegate(this.HideText);
            loadExtensionsDelegate = new LoadExDelegate(this.LoadExt);
            Showboard = this.Resources["ShowStoryBoard"] as Storyboard;
            Hideboard = this.Resources["HideStoryBoard"] as Storyboard;
        }


        private void ShowText(string text)
        {
            Message = text;
            BeginStoryboard(Showboard);
        }
        private void HideText()
        {
            BeginStoryboard(Hideboard);
        }
        internal void LoadTechSvApp()
        {
            loadingThread = new Thread(load);
            loadingThread.SetApartmentState(ApartmentState.STA);
            loadingThread.IsBackground = true;
            loadingThread.Start();
        }
        private void load()
        {

            //Do the loading here in another thread in order to show more smooth loading screen!
            loadExtensionsDelegate.BeginInvoke(LoadExtEnd, loadExtensionsDelegate);

            //this.Dispatcher.BeginInvoke(showDelegate,this);


            Thread.Sleep(500);
            //this.Dispatcher.BeginInvoke(showDelegate, this);
            this.Dispatcher.Invoke(showDelegate, "a");
            //Thread.Sleep(2000);
            //TODO needs to get from app.config
            //OUTA.Common.ScriptMLHelper.Instance.Initialize("ScriptMultiLanguage_en-us.dict");

            this.Dispatcher.Invoke(hideDelegate);
            // "Loading Extensions"
            Thread.Sleep(500);
            //this.Dispatcher.BeginInvoke(showDelegate, this);
            this.Dispatcher.Invoke(showDelegate, "s");
            //showDelegate("Loading Elements");
            //Thread.Sleep(2000);
            //load data 
            //IntelliSenseProvider.Instance.Initialize(OUTA.Common.OUTAConstants.RequisitesDirectory);

            this.Dispatcher.Invoke(hideDelegate);

            Thread.Sleep(500);
            //this.Dispatcher.BeginInvoke(showDelegate, this);
            this.Dispatcher.Invoke(showDelegate, "d");
            //showDelegate("Loading Windows");
            Thread.Sleep(500);
            //load data
            this.Dispatcher.Invoke(hideDelegate);


            Thread.Sleep(500);
            //this.Dispatcher.BeginInvoke(showDelegate, this);
            this.Dispatcher.Invoke(showDelegate, "f");
            //showDelegate("Finish");
            Thread.Sleep(500);
            //load data 
            this.Dispatcher.Invoke(hideDelegate);

            while (!loadComplete)
            {
                Thread.Sleep(50);
            }

            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { this.Close(); });
        }
        private void LoadExt()
        {
            (App.Current as App).InitializeScripts();
            //string sLang = (App.Current as App).SettingsVM.SelectedScriptLanguage.Value.ToString();
            //if(sLang.Equals("TR"))
            //    OUTA.Common.ScriptMLHelper.Instance.Initialize("ScriptMultiLanguage_tr-tr.dict");
            //else
            //    OUTA.Common.ScriptMLHelper.Instance.Initialize("ScriptMultiLanguage_en-us.dict");
            //IntelliSenseProvider.Instance.Initialize(OUTA.Common.OUTAConstants.RequisitesDirectory);
        }

        private void LoadForm(IAsyncResult result)
        {

        }

        private void LoadExtEnd(IAsyncResult result)
        {
            loadComplete = true;
        }
    }
}
