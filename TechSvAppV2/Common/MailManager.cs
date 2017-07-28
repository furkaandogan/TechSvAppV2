using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Windows;

namespace Common
{
    public class MailManager : MailCommon
    {


        #region Members

        private SmtpClient smtpClient;
        private NetworkCredential networtCredential;

        #endregion

        #region Properties

        public Dictionary<string, string> MessageReplaceKeyAndValue { get; set; }
        public MailEntity MailEntity { get; set; }
        public List<MailEntity> MailEntityCollection { get; set; }

        #endregion

        #region Constructor

        public MailManager(string Email, string Password, int Port, string Host, bool Ssl)
        {
            this.Email = Email;
            this.Password = Password;
            this.Port = Port;
            this.Host = Host;
            smtpClient = new SmtpClient(this.Host, this.Port);
            smtpClient.EnableSsl = Ssl;
            networtCredential = new NetworkCredential(this.Email, this.Password);
            smtpClient.Credentials = networtCredential;


        }

        #endregion

        #region Methods

        public bool SendMail(MailEntity mail)
        {
            try
            {
                smtpClient.Send(this.Email, mail.Email, mail.Title, mail.Body);
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
        public bool SendRangeMail(List<MailEntity> mails)
        {
            foreach (MailEntity mail in mails)
            {
                try
                {
                    smtpClient.Send(this.Email, mail.Email, mail.Title, mail.Body);
                }
                catch
                {
                    return false;
                }

            }
            return true;
        }

        public bool MessageTemplateReplace()
        {
            try
            {
                foreach (var item in MessageReplaceKeyAndValue)
                {
                    MailEntity.Body = MailEntity.Body.Replace(item.Key, item.Value);
                }
                return true;
            }
            catch   
            {
                return false;
            }
        }
        public bool MessageTemplateReplace(Dictionary<string, string> messageReplaceKeyAndValue)
        {
            try
            {
                MessageReplaceKeyAndValue = messageReplaceKeyAndValue;
                foreach (var item in MessageReplaceKeyAndValue)
                {
                    MailEntity.Body = MailEntity.Body.Replace(item.Key, item.Value);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool MessageTemplateReplace(Dictionary<string, string> messageReplaceKeyAndValue,MailEntity mail)
        {
            try
            {
                MessageReplaceKeyAndValue = messageReplaceKeyAndValue;
                MailEntity = mail;
                foreach (var item in MessageReplaceKeyAndValue)
                {
                    MailEntity.Body = MailEntity.Body.Replace(item.Key, item.Value);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        #endregion

        #region Helpers

        #endregion

    }
    public partial class MailCommon
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
    public partial class MailEntity
    {
        public string Email { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    public partial class TemplateKeyAndValueItem
    {
        public string Key { get; set; }
        public string Value { get; set; }

    }
    public class TemplateKeyAndValueCollection
    {

    }
}
