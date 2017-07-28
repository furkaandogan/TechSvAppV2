using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIElements.Controls;

namespace UI.Model.Const
{
    public class EventBase :Common.Helpers.ViewModelHelpers
    {



        #region Constructor


        public EventBase()
        {
            Commands = new Common.CommandList();
            Commands.AddCommand("NagivateCmd", new Common.DelegateCommand<object>(NagivateCmd));
            Commands.AddCommand("BackNagivateCmd", new Common.DelegateCommand(BackNagivateCmd));
            Commands.AddCommand("SearchCmd", new Common.DelegateCommand<object>(SearchCmd)); 
        }

        #endregion

        #region Methods

        private void NagivateCmd(object sender)
        {
            if (DataAccess.User != null)
            {
                if (!string.IsNullOrEmpty(((ExButton)sender).Url) && Model.Const.Theme.Instance.ActiveUrl.Split('/')[Model.Const.Theme.Instance.ActiveUrl.Split('/').Length - 1].Split('.')[0].ToString() != ((ExButton)sender).Url)
                {
                    Model.Const.DataAccess.Dispose();
                    Model.Const.Theme.Instance.ActiveUrl = ((ExButton)sender).Url.ToString();
                    Model.Const.Theme.Instance.Nagivate = ((ExButton)sender).Content.ToString();
                    Model.Const.Theme.Instance.NagivateMini = ((ExButton)sender).Content.ToString();
                }
            }
        }
        private void BackNagivateCmd()
        {
            Model.Const.Theme.Instance.ActiveUrl = Model.Const.Theme.Instance.BackNagivateUrl;
        }

        private void SearchCmd(object sender)
        {
            Model.Const.Theme.Instance.ActiveUrl = "SearchResult";
            Model.Const.Theme.Instance.Nagivate = "Arama Sonuçları";
            Model.Const.Theme.Instance.NagivateMini = "Arama Sonuçları";
            Model.Const.Theme.Instance.SearchKey=((ExTextBox)sender).Text.ToString();
        }

        #endregion

    }
}
