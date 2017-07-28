using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FtpManager :FtpEntity
    {
        private FtpWebRequest ftpRequest;
        private FtpWebResponse ftpResponse;
        private Stream stream;
        private FileStream localFileStream;

        private int bufferSize = 2048;

        public FtpManager()
        {

        }
        public FtpManager(FtpEntity ftpEntity)
        {
            Server = ftpEntity.Server;
            User = ftpEntity.User;
            Password = ftpEntity.Password;
        }

        public bool Upload(string filename, string localFileAdress)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(Server + "/" + filename);
                ftpRequest.Credentials = new NetworkCredential(User, Password);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                stream = ftpRequest.GetRequestStream();
                localFileStream = new FileStream(localFileAdress, FileMode.Create);
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                try
                {
                    while (bytesSent != 0)
                    {
                        stream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch
                {
                    return false;
                }
                localFileStream.Close();
                stream.Close();
                ftpRequest = null;
            }
            catch 
            {
                return false;
            }
            return true;;
        }


    }

    public class FtpEntity
    {
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
