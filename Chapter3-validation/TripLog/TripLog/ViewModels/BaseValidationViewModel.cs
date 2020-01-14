using Qwantalabs.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TripLog.ViewModels
{
    public class BaseValidationViewModel : BaseViewModel , INotifyDataErrorInfo
    {
        public BaseValidationViewModel()
        {

        }

        #region validation

        //CallerFilePath
        //CallerLineNumber
        //CallerMemberName
        protected void Validate(Func<bool> rule,
                                string error,
                                [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return;
            _errors.If(l => l.ContainsKey(propertyName)).Do(l => l.Remove(propertyName));
            _errors.If(l => rule() == false).Do(l => l.Add(propertyName, new List<string> { error }));
            OnPropertyChanged(nameof(HasErrors));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion


        #region INotifyDataErrorInfo

        readonly IDictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors => _errors?.Any(x => x.Value?.Any() == true) == true;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName) =>
            _errors.If(l => string.IsNullOrWhiteSpace(propertyName)).Select(l => l.SelectMany(x => x.Value))
                   ?? _errors.If(l => l.ContainsKey(propertyName)).If(l => l[propertyName].Any()).Select(l => l[propertyName])
                   ?? new List<string>();
        

        #endregion
    }
}
