using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class FeedBack :BaseModel
    {

        private Entity.AppFeedBack _model;
        private string _selectedType;
        public Entity.AppFeedBack Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        public List<string> Types
        {
            get
            {
                return Enum.GetNames(typeof(Entity.FeedBackType)).ToList();
            }
        }
        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                if (!string.IsNullOrEmpty(value))
                    Model.Type = (Entity.FeedBackType)Enum.Parse(typeof(Entity.FeedBackType), value);
            }
        }

        public FeedBack()
        {
            Model = new Entity.AppFeedBack();
            Model.Email = Const.DataAccess.User.Email.ToString();
        }



    }
}
