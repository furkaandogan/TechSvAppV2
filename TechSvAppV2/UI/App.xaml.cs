using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private void AppClose()
        {
            Application.Current.Shutdown();
        }

        public void InitializeScripts()
        {

        }


        protected override void OnStartup(StartupEventArgs e)
        {
            //Repository.App.FirmaRepository re = new Repository.App.FirmaRepository();
            //re.Add(new Entity.App.Firma()
            //{
            //    Ad = "OTOTAMİR-DEMO",
            //    Adres = "Aydın",
            //    AppConfig = new Entity.AppConfig()
            //    {
            //        DataBaseName = "demoTexhSvApp",
            //        DataBasePassword = "demomssql",
            //        DataBaseServer = "demo.mssql.com",
            //        DataBaseUser = "demomssql",
            //        FtpPassword = "demoftp",
            //        FtpServer = "ftp.techsvapp.com",
            //        FtpUser = "demoftpuser",
            //        KritikStok = 15,
            //        LicenseExpiryDate = (DateTime.Now + TimeSpan.FromDays(720)),
            //        RegistrationDate = DateTime.Now,
            //        TakipKodu = "OTB",
            //    },
            //    Email = "demo@exline.com",
            //    Fax = "02164444949",
            //    Telefon = "02164444949",
            //    TakipKodu = "YDL1",
            //    Resim = new Entity.App.Resim()
            //    {
            //        Url = "YDL.PGN",
            //    },
            //    GSM = "05309304888",
            //    VergiDairesi = "1234567891",
            //    VergiNumarasi = "1234567891",
            //});
            //Repository.App.KullaniciRespository ku = new Repository.App.KullaniciRespository();
            //ku.Add(new Entity.App.Kullanici()
            //{
            //    Durum = true,
            //    KullaniciSifresi = "admin",
            //    KullniciAdi = "admin",
            //    Soyad = "DOĞAN",
            //    Ad = "Muhammet Furkan",
            //    Email = "furkandogan@exlinetr.com",
            //    TakipKodu = "mfd",
            //    EklenmeTarihi = DateTime.Now
            //});

            Entity.App.Firma company = new Repository.App.FirmaRepository().Get(model => model.AppID == Bin.Model.AppSettingModel.AppID).Model as Entity.App.Firma;
            if (company == null || company.Durum == false)
            {
                UI.Model.Const.Theme.Instance.ActiveUrl = "Error";
                UI.Model.Const.Theme.Instance.Nagivate = "AÇIKLAMA";
                UI.Model.Const.Theme.Instance.NagivateMini = "AÇIKLAMA";
            }


            if (e.Args.Length == 0)
            {
                try
                {
                    View.MainView MainView = new View.MainView();
                    SplashScreenWindow v = new SplashScreenWindow();
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                    });
                    v.LoadTechSvApp();
                    v.ShowDialog();

                    base.OnStartup(e);
                    MainView.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata Oluştu");
                }

            }
            else
            {

            }



        }

        protected override void OnExit(ExitEventArgs e)
        {
            Model.Const.Theme.Instance.PublicAlertStop();
            base.OnExit(e);
        }

    }
}
