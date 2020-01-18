using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Init()
        {

        }

        // Called without arguments. The argument is added by the compiler.
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected INavService NavService { get; private set; }
        protected BaseViewModel(INavService navService)
        {
            NavService = navService;
        }
    }

    public class BaseViewModel<TParameter> : BaseViewModel
    {
        public override void Init()
        {
            Init(default(TParameter));
        }
        public virtual void Init(TParameter parameter)
        {

        }

        protected BaseViewModel(INavService navService)
        : base(navService)
        {
        }
    }
}
