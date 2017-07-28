using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helpers
{
    public class MailController
    {
        private static Dictionary<string, string> mailRules;
        private static global::Common.MailManager mailManager;
        private static Entity.App.Servis _model;
        public static Entity.App.Servis Model
        {
            get { return _model; }
            set
            {
                mailRules = new Dictionary<string, string>();
                mailRules.Add("{customer}", value.ServisDetay.Musteri.Ad + " " + value.ServisDetay.Musteri.Soyad);
                mailRules.Add("{productType}", value.UrunTipi.Ad);
                mailRules.Add("{brand}", value.Marka.Ad);
                mailRules.Add("{date}", value.EklenmeTarihi.ToString());
                mailRules.Add("{complaint}", value.MusteriSikayeti);
                mailRules.Add("{guarantee}", value.GarantiDurum.ToString());
                mailRules.Add("{trackingCode}", value.TakipKodu);
                _model = value;
            }
        }

        public static void newService()
        {
            Entity.App.MailGorev task = (Bin.ActionEvent.MailTaskActionEvents.GetList().Model as List<Entity.App.MailGorev>).ToList().FirstOrDefault();
            if (task != null)
            {
                if (!string.IsNullOrEmpty(Model.ServisDetay.Musteri.Mail))
                {
                    mailManager = new global::Common.MailManager(task.MailAdres.Adres, task.MailAdres.Sifre, task.MailAdres.Port, task.MailAdres.Host, task.MailAdres.SSL);
                    mailManager.SendMail(new global::Common.MailEntity()
                    {
                        Body = mailReplace(task.MailSablon.İcerik),
                        Email = Model.ServisDetay.Musteri.Mail,
                        Title = task.MailSablon.Baslik,
                    });
                }
            }
        }

        private static string mailReplace(string template)
        {
            foreach (var rule in mailRules)
            {
                template = template.Replace(rule.Key,rule.Value);
            }
            return template;
        }

    }
}
