using System.ComponentModel;
using System.Runtime.CompilerServices;
using VinylShopper.Domain.Annotations;

namespace VinylShopper.Domain.ViewModels
{
    public class VmBase : INotifyPropertyChanged
    {
        public bool IsBusy { get; set; }
        public string BusyText { get; set; }

        public void SetBusy(string text)
        {
            IsBusy = true;
            BusyText = text;
        }

        public void ClearBusy()
        {
            IsBusy = false;
            BusyText = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}