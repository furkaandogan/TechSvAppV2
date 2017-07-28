using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Common
{
    public class PropertyChange : ValidationIDataError,INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        #region Public Members

        public virtual void OnAllPropertiesChanged()
        {
            OnPropertyChanged(string.Empty);
        }

        public virtual void OnPropertyChanged<T>(params Expression<Func<T>>[] properties)
        {
            foreach (var property in properties)
                OnPropertyChanged(GetPropertyName(property));
        }

        #endregion

        #region Static Helper Methods

        public static string GetPropertyName<T>(Expression<Func<T>> property)
        {
            MemberExpression memberExpression;

            var lambda = (LambdaExpression)property;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)lambda.Body;
            }

            return memberExpression.Member.Name;
        }
        #endregion
    }
}

