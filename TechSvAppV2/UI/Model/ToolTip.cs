using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class ToolTip :BaseModel
    {

        private static ToolTip _instance;
        public static ToolTip Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ToolTip();
                return _instance;
            }
            
        }
        private ToolTip()
        {

        }

        private string _username;
        private string _mail;


        public string UserName
        {
            get { return _username; }//(Const.DataAccess.User!=null ? Const.DataAccess.User.Ad +" "+ Const.DataAccess.User.Soyad :"Giriş Yapınız"); }
            set
            {
                _username = value;
                OnPropertyChanged("UserName");
            }
        }
        public string Email
        {
            get { return _mail; }//Const.DataAccess.User != null ? Const.DataAccess.User.Email : "----------"; }
            set
            {
                _mail = value;
                OnPropertyChanged("Email");
            }
        }

    }
}
