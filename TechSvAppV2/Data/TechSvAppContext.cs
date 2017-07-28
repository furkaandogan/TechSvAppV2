using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TechSvAppContext :DbContext
    {

        #region Singelton

        private static TechSvAppContext _instance;

        public static TechSvAppContext Instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance = new TechSvAppContext(true);
                }
                return _instance;
            }
        }

        private TechSvAppContext(bool netDurum)
            :base("Data Source = "+AppSettingsData.Server+"; Initial Catalog = "+AppSettingsData.Catagory+"; User Id = "+AppSettingsData.Username+"; Password="+AppSettingsData.Password+";")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TechSvAppContext>());
        }


        #endregion


        #region Tables

        #region App

        public DbSet<Entity.App.ArizaSeti> ArizaSetiDbSet { get; set; }
        public DbSet<Entity.App.DisServisKullanicisi> DisServisKullanicisiDbSet { get; set; }
        public DbSet<Entity.App.DisServisNotu> DisServisNotuDbSet { get; set; }
        public DbSet<Entity.App.Ekipman> EkipmanDbSet { get; set; }
        public DbSet<Entity.App.Firma> FirmaDbSet { get; set; }
        public DbSet<Entity.App.Hatirlatma> HatırlamtaDbSet { get; set; }
        public DbSet<Entity.App.Kullanici> KullaniciDbSet { get; set; }
        public DbSet<Entity.App.MailAdres> MailAdresDbSet { get; set; }
        public DbSet<Entity.App.MailGorev> MailGörevDbSet { get; set; }
        public DbSet<Entity.App.MailSablon> MailSablonDbSet { get; set; }
        public DbSet<Entity.App.Marka> MarkaDbSet { get; set; }
        public DbSet<Entity.App.Musteri> MusteriDbSet { get; set; }
        public DbSet<Entity.App.Resim> ResimDbSet { get; set; }
        public DbSet<Entity.App.Servis> ServisDbSet { get; set; }
        public DbSet<Entity.App.ServisDetay> ServisDetayDbSet { get; set; }
        public DbSet<Entity.App.ServisDurumu> ServisDurumuDbSet { get; set; }
        public DbSet<Entity.App.Stok> StokDbSet { get; set; }
        public DbSet<Entity.App.Ucret> UcretDbSet { get; set; }
        public DbSet<Entity.App.Urun> UrunDbSet { get; set; }
        public DbSet<Entity.App.UrunTipi> UrunTipiDbSet { get; set; }


     ///   public DbSet<Entity.App.Hakkında> HakkındaDbSet { get; set; }

        public DbSet<Entity.AppTheme> AppThemeDbSet { get; set; }
        public DbSet<Entity.AppConfig> AppConfigDbSet { get; set; }


        #region Theme

        //public DbSet<Entity.App.Theme.ThemeBase> ThemeBaseDbSet { get; set; }
        //public DbSet<Entity.App.Theme.DashboardTheme> DashboardThemeDbSet { get; set; }

        #endregion

        #endregion

      //  public DbSet<Entity.AppFeedBack> AppFeedBackDbSet { get; set; }


        #endregion


    }
}
