namespace VinylShopper.Domain.ViewModels
{
    public class VmBase
    {
        public bool IsBusy { get; set; }
        public string BusyText { get; set; }

        public void SetBusy(string text)
        {
            IsBusy = true;
            BusyText = text;
        }

        public void ClearBusy(string text)
        {
            IsBusy = false;
            BusyText = null;
        }
    }
}