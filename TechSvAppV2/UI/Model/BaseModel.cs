using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class BaseModel : Common.Helpers.ViewModelHelpers
    {

        #region Memebrs

        public Entity.Result result;
        public View.ExMessageBoxViewModel exMessage;

        private DateTime _selectedDateTime_1 = DateTime.Now;
        private DateTime _selectedDateTime_2 = DateTime.Now;

        private bool _buttonEnable;
        private int _startRowIndex;
        private int _endRowIndex;
        private int _rowsValue;

        private string _tag;

        #endregion

        #region Properties
        public bool ButtonEnable
        {
            get { return _buttonEnable; }
            set
            {
                _buttonEnable = value;
                OnPropertyChanged("ButtonEnable");
            }
        }
        public DateTime SelectedDateTime_1
        {
            get { return _selectedDateTime_1; }
            set
            {
                if (SelectedDateTime_2 > value)
                {
                    _selectedDateTime_1 = value;
                    OnPropertyChanged("SelectedDateTime_1");
                    dateFilter();
                }
            }
        }
        public DateTime SelectedDateTime_2
        {
            get
            {
                return _selectedDateTime_2;
            }
            set
            {
                if (SelectedDateTime_1 < value)
                {
                    _selectedDateTime_2 = value;
                    OnPropertyChanged("SelectedDateTime_2");
                    dateFilter();
                }
            }
        }

        [RegularExpression(@"^\w*$", ErrorMessage = "geçersiz veri girdiniz sadece sayısal veri girilebilir")]
        public int StartRowIndex
        {
            get { return _startRowIndex; }
            set
            {
                _startRowIndex = (value-1);
                OnPropertyChanged("StartRowIndex");
                if (EndRowIndex != 0)
                    dataRowsCountFilter();
            }
        }

        [RegularExpression(@"^\w*$", ErrorMessage = "geçersiz veri girdiniz sadece sayısal veri girilebilir")]
        public int EndRowIndex
        {
            get { return _endRowIndex; }
            set
            {
                _endRowIndex = value;
                OnPropertyChanged("EndRowIndex");
                if (StartRowIndex != 0)
                    dataRowsCountFilter();
            }
        }

        [RegularExpression(@"^\w*$", ErrorMessage = "geçersiz veri girdiniz sadece sayısal veri girilebilir")]
        public int RowsValue
        {
            get { return _rowsValue; }
            set
            {
                _rowsValue = value;
                OnPropertyChanged("RowsValue");
                dataRowsValuetFilter();
            }
        }

        public string Tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                OnPropertyChanged("Tag");
            }
        }


        #endregion


        #region Ovirried Methods

        /// <summary>
        /// tarihe göre filtreleem yapar
        /// </summary>
        public virtual void dateFilter()
        {

        }
        /// <summary>
        /// belirlenen indexten sonra isteilen count kadar kaydı getirir
        /// </summary>
        public virtual void dataRowsCountFilter()
        {

        }
        /// <summary>
        /// sayfda istenilen count kadar kayıt listeler
        /// </summary>
        public virtual void dataRowsValuetFilter()
        {

        }

        #endregion

        public BaseModel()
        {
            ButtonEnable = false;
        }



    }






    public enum ModelSetType : int
    {
        entityToModel = 1,
        modelToEntity = 2,
    }
}
