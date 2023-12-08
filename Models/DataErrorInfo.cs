using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class DataErrorInfo : NotifyPropertyChanged, IDataErrorInfo, INotifyDataErrorInfo
    {
        public Dictionary<string, string> ErrorDictionary { get; } = new Dictionary<string, string>();

        #region IDataErrorInfo
        public string this[string columnName] => ErrorDictionary.TryGetValue(columnName, out var error) ? error : string.Empty;

        public string Error => string.Join("\n", ErrorDictionary.Select(x => x.Value));
        #endregion IDataErrorInfo

        #region INotifyDataErrorInfo
        public bool HasErrors => ErrorDictionary.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return this[propertyName ?? string.Empty];
        }
        #endregion INotifyDataErrorInfo

        public void RaiseErrorChanged(string? propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged("");
        }
    }
}
