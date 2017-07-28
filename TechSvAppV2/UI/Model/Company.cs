using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class Company :BaseModel
    {
        private Entity.App.Firma _model;
        public Entity.App.Firma Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        public Company()
        {
            Model = (Bin.ActionEvent.CompanyActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.Firma>).FirstOrDefault();
        }

    }
}
