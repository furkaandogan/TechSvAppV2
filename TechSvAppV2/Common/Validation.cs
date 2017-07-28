using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    public class Validation : INotifyDataErrorInfo
    {
        public bool HasErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidatableModel : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        private ConcurrentDictionary<string, List<string>> _errors =
            new ConcurrentDictionary<string, List<string>>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
            ValidateAsync();
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            if (handler != null)
                handler(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            List<string> errorsForName;
            _errors.TryGetValue(propertyName, out errorsForName);
            return errorsForName;
        }

        public bool HasErrors
        {
            get { return _errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
        }

        public Task ValidateAsync()
        {
            return Task.Run(() => Validate());
        }

        private object _lock = new object();
        public void Validate()
        {
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, validationContext, validationResults, true);

                foreach (var kv in _errors.ToList())
                {
                    if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                    {
                        List<string> outLi;
                        _errors.TryRemove(kv.Key, out outLi);
                        OnErrorsChanged(kv.Key);
                    }
                }

                var q = from r in validationResults
                        from m in r.MemberNames
                        group r by m into g
                        select g;

                foreach (var prop in q)
                {
                    var messages = prop.Select(r => r.ErrorMessage).ToList();

                    if (_errors.ContainsKey(prop.Key))
                    {
                        List<string> outLi;
                        _errors.TryRemove(prop.Key, out outLi);
                    }
                    _errors.TryAdd(prop.Key, messages);
                    OnErrorsChanged(prop.Key);
                }
            }
        }
    }

    public class ValidationIDataError : IDataErrorInfo
    {
        private List<ValidationResult> results;
        private ValidationContext context;
        private ValidationResult validationResult;
        private bool result;
        private object value;
        private string errorMess;
       //private List<bool> errArray=new List<bool>();


        string IDataErrorInfo.this[string propertyName] 
        {
            get { return OnValidate(propertyName); }
        }
        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Invalid property name", propertyName);

            errorMess = string.Empty;
            value = this.GetType().GetProperty(propertyName).GetValue(this, null);
            results = new List<ValidationResult>(1);

            context = new ValidationContext(this, null, null) { MemberName = propertyName };

            result = Validator.TryValidateProperty(value, context, results);

            if (!result)
            {
                validationResult = results.First();
                errorMess = validationResult.ErrorMessage;
            }

           // errArray.Add(result);
            return errorMess;
        }
        //public bool isError
        //{
        //    get
        //    {
        //        int val=0;
        //        foreach (bool item in errArray)
        //        {
        //            if (item == false)
        //                val++;
        //        }
        //        if((errArray.Count/2)==val)
        //            return false;

        //        errArray = new List<bool>();
        //        return true;
        //    }
        //}

        public string Error
        {
            get
            {
                return "";
            }
        }
    }

}

