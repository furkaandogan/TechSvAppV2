using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class User : BaseModel
    {
        #region Members

        private Entity.App.Kullanici _model;
        private ObservableCollection<Entity.App.Kullanici> _users = new ObservableCollection<Entity.App.Kullanici>();

        #endregion
        #region Properties

        public Entity.App.Kullanici Model
        {
            get { return _model; }
            set
            {
                _model = value;

                if (_model != null)
                {
                    _model.EklenmeTarihi = DateTime.Now;
                    _model.TakipKodu = Bin.AppSetting.CreatCodeKey(Users.Count);

                    if (_model.KullniciAdi != null)
                        ButtonEnable = true;
                    else
                        ButtonEnable = false;
                }
                OnPropertyChanged("Model");
            }
        }
        public ObservableCollection<Entity.App.Kullanici> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        #endregion

        #region Constructor


        public User()
        {
            Users = new ObservableCollection<Entity.App.Kullanici>(Bin.ActionEvent.UserActionEvents.GetList(model=>model.AppID== Bin.Model.AppSettingModel.AppID && model.Durum==true).Model as List<Entity.App.Kullanici>);
            Model = new Entity.App.Kullanici();
            Tag = "Ad | Soyad | Mail | Kullanıcı Adı";
        }

        #endregion

    }
}
