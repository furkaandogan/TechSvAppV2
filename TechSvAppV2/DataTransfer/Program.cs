using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransfer
{
    class Program
    {

        private static System.Data.DataTable dataTable;
        private static System.Data.SqlClient.SqlCommand command;
        private static System.Data.SqlClient.SqlConnection connection;
        private static System.Data.SqlClient.SqlDataAdapter dataAdapter;
        private static string connectionString = "Data Source =94.73.147.6; Initial Catalog =DB150114215941; User Id =USR150114215941; Password=PSS!C3V8A1%;";
        private static Repository.App.KullaniciRespository kullaniciRepository = new Repository.App.KullaniciRespository();
        private static Repository.App.UrunTipiRepository urunTipiRepository = new Repository.App.UrunTipiRepository();
        private static Repository.App.MarkaRespository markaRepository = new Repository.App.MarkaRespository();
        private static Repository.App.MusteriRepository musteriRepository = new Repository.App.MusteriRepository();
        private static Repository.App.ServisDurumuRespository servisDurumRepository = new Repository.App.ServisDurumuRespository();
        private static Repository.App.HatirlatmaRepository hatirlatmaRepository = new Repository.App.HatirlatmaRepository();
        private static int index = 0;
        static void Main(string[] args)
        {
            dbOpen();
            // transferUrunTipi();
            // transferMarka();
            // transferMusteri();
            // transferServisDurumu();
          //  transferHatirlatma();
        }


        #region DATA CONNECTİON CODE

        /* MSSQL DATA CONNECTİON */

        private static void dbOpen()
        {
            connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();

        }

        private static void Execute(string query)
        {
            command = new System.Data.SqlClient.SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
        private static System.Data.DataTable GetTable(string query)
        {
            Execute(query);
            dataTable = new System.Data.DataTable();
            dataAdapter = new System.Data.SqlClient.SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }


        #endregion

        #region YADONEL DB TRANSFER CODE

        /* YADONEL DB TRANSFER CODE  */


        private static void transferKullanici()
        {
            dataTable = GetTable("SELECT * FROM TechnicalStaffs");
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                kullaniciRepository.Add(new Entity.App.Kullanici()
                {
                    Ad = row["Name"].ToString().Split(' ')[0],
                    Soyad = row["Name"].ToString().Split(' ')[1],
                    Email = row["Email"].ToString(),
                    KullniciAdi = row["UserName"].ToString(),
                    KullaniciSifresi = row["UserPassword"].ToString(),
                    TakipKodu = Bin.AppSetting.CreatCodeKey(dataTable.Rows.Count + index),
                });
                index++;
            }
            Console.WriteLine("Kullanıcılar Transfer edildi");
        }

        private static void transferUrunTipi()
        {
            dataTable = GetTable("SELECT * FROM ProductTypes");
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                urunTipiRepository.Add(new Entity.App.UrunTipi()
                {
                    Ad = row["Name"].ToString(),
                    TakipKodu = Bin.AppSetting.CreatCodeKey(dataTable.Rows.Count + index),
                });
                index++;
            }

            Console.WriteLine("Ürün Tipleri Transfer edildi");

        }

        private static void transferMarka()
        {
            dataTable = GetTable("SELECT * FROM Brands");
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                markaRepository.Add(new Entity.App.Marka()
                {
                    Ad = row["Name"].ToString(),
                    TakipKodu = Bin.AppSetting.CreatCodeKey(dataTable.Rows.Count + index),
                });
                index++;
            }

            Console.WriteLine("Markalar Transfer edildi");
        }

        private static void transferMusteri()
        {
            dataTable = GetTable("SELECT * FROM Customers");
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                musteriRepository.Add(new Entity.App.Musteri()
                {
                    Ad = row["Name"].ToString().Split(' ')[0],
                    Soyad = row["Name"].ToString().Split(' ')[1],
                    Telefon = row["Phone"].ToString(),
                    Mail = (!string.IsNullOrEmpty(row["Email"].ToString())) ? row["Email"].ToString() : "mailadresi@msn.com",
                    Tc = row["Tc"].ToString(),
                    Adres = row["Address"].ToString(),
                    TakipKodu = Bin.AppSetting.CreatCodeKey(dataTable.Rows.Count + index),
                });
                index++;
            }

            Console.WriteLine("Müşteriler Transfer edildi");
        }

        private static void transferServisDurumu()
        {
            dataTable = GetTable("SELECT * FROM ServiceStatus");
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                servisDurumRepository.Add(new Entity.App.ServisDurumu()
                {
                    Ad = row["Name"].ToString().Split(' ')[0],
                    Resim = new Entity.App.Resim()
                    {
                        Url = "https://cdn2.iconfinder.com/data/icons/social-aquiocons/128/Aquicon-Instagram.png",
                        TakipKodu = Bin.AppSetting.CreatCodeKey(dataTable.Rows.Count + index),
                    },
                    TakipKodu = Bin.AppSetting.CreatCodeKey(dataTable.Rows.Count + index),
                });
                index++;
            }

            Console.WriteLine("Servis Durumları Transfer edildi");

        }

        private static void transferHatirlatma()
        {
            dataTable = GetTable("SELECT * FROM Comments");
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                hatirlatmaRepository.Add(new Entity.App.Hatirlatma()
                {
                    EklenmeTarihi = DateTime.Now, // Convert.ToDateTime(row["RemindingDateOfEntry"].ToString()),
                    HatırlatmaTarihi = DateTime.Now, // Convert.ToDateTime(row["RemindingDate"].ToString()),
                    Konu = row["Title"].ToString(),
                    İcerik = row["Reminding"].ToString(),
                    Kullanici = kullaniciRepository.Get(x => x.AppID == Bin.Model.AppSettingModel.AppID && x.Durum == true && x.ID == 1).Model as Entity.App.Kullanici,
                    TakipKodu = Bin.AppSetting.CreatCodeKey(dataTable.Rows.Count + index),
                });
                index++;
            }

            Console.WriteLine("Müşteriler Transfer edildi");
        }




        #endregion





    }
}
