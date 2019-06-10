using System;
using System.Windows.Input;

namespace toqpka.Word
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        private Action mAction;

        #endregion

        #region Public Events
        /// <summary>
        ///  when the CanExecute value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor
        /// <summary>
        /// Def cunstructor
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        #endregion

        #region Command Methods

        /// <summary>
        /// command can always execute
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
