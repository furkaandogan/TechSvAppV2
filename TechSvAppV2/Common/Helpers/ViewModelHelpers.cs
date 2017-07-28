using Common;

namespace Common.Helpers
{
    public class ViewModelHelpers:PropertyChange 
    {


        public CommandList Commands { get; protected set; }
        public WindowsManagment Windows { get; protected set; }
        public Validation Validation { get; protected set; }
        public ValidationIDataError ValidationIDataError { get; set; }
        public Microsoft.Office.IOfficeApp IOfficeApp { get; set; }

        #region Methods

        public bool InternetCheckUp()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (var stream = client.OpenRead("http://www.facebook.com/ExlineTr"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion


    }
}
