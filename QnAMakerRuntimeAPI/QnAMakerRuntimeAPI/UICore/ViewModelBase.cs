using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QnAMakerRuntimeAPI.UICore
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1030:Use events where appropriate", Justification = "This is raising an event")]
        public void RaisePropertyChanged(string propertyName)
        {
            var pc = this.PropertyChanged;
            if(pc != null)
            {
                pc.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
