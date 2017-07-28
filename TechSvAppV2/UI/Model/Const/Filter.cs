using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model.Const
{
    public class Filter<TModel> :Common.Helpers.ViewModelHelpers
        where TModel :class,new()
    {

        #region Members

        private string _tag;
        private Model.App.FilterType _type;
        private ObservableCollection<TModel> _source;

        #endregion

        #region Properties

        public string Tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                OnPropertyChanged("Tag");
            }
        }
        public Model.App.FilterType FilterType
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("FilterType");
            }
        }
        public ObservableCollection<TModel> Source
        {
            get { return _source; }
            set
            {
                _source = value;
                OnPropertyChanged("Source");
            }
        }

        #endregion

        #region Methods


        public void SetMethod()
        {
            Commands.AddCommand("TextChanged", new Common.DelegateCommand<object>(TextChanged));
        }
        

        private void TextChanged(object sender)
        {
            //Source = new ObservableCollection<Entity.App.Musteri>((Bin.ActionEvent.CustomerActionEvents.GetList(model => model.AppID == "1" && model.Durum == true).Model as List<Entity.App.Musteri>).Where(model =>
            //       (model.Ad != null ? model.Ad.ToString().ToUpper().Contains((sender as UIElements.Controls.ExTextBox).Text.ToString().ToUpper()) : false)
            //    || (model.Soyad != null ? model.Soyad.ToString().ToUpper().Contains((sender as UIElements.Controls.ExTextBox).Text.ToString().ToUpper()) : false)
            //    || (model.Mail != null ? model.Mail.ToString().ToUpper().Contains((sender as UIElements.Controls.ExTextBox).Text.ToString().ToUpper()) : false)
            //    || (model.Adres != null ? model.Adres.ToString().ToUpper().Contains((sender as UIElements.Controls.ExTextBox).Text.ToString().ToUpper()) : false)
            //    || (model.Tc != null ? model.Tc.ToString().ToUpper().Contains((sender as UIElements.Controls.ExTextBox).Text.ToString().ToUpper()) : false)).ToList());
        }

        #endregion

        #region Singelton


        private static Filter<TModel> _instance;
        public static Filter<TModel> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Filter<TModel>();


                return _instance;
            }
        }

        private Filter()
        {

        }

        #endregion

    }
}
