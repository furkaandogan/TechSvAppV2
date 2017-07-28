using System;
using System.Windows.Input;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action _handler;
        public event EventHandler CanExecuteChanged;

        #region Consructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        public DelegateCommand(Action handler)
        {
            _handler = handler;
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _handler();
        }

        public static implicit operator string (DelegateCommand v)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : ICommand
    {

        private readonly Action<T> _handler;
        public event EventHandler CanExecuteChanged;

        #region Consructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        public DelegateCommand(Action<T> handler)
        {
            _handler = handler;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _handler((T)parameter);
        }
    }
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class DelegateCommand<T,T2> : ICommand
{

    private readonly Action<T, T2> _handler;
    public event EventHandler CanExecuteChanged;

    #region Consructor

    /// <summary>
    /// 
    /// </summary>
    /// <param name="handler"></param>
    public DelegateCommand(Action<T, T2> handler)
    {
        _handler = handler;
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object parameter)
    {
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object parameter, object e)
    {
        _handler((T)parameter,(T2)e);
    }

    public void Execute(object parameter)
    {
       // _handler((T)parameter,null);
    }
}

