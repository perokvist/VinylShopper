namespace VinylShopper.Domain.ViewModels
{
    public class ResultDesign : Result
    {
        public ResultDesign()
        {
            Title = "A long way home";
            Artist = "Fleetwood Mac";
            Label = "A records";
            Price = "7,95 E";
            Cover = "ApplicationIcon.png";
            Format = "12\"";
            Pressing = "Original";
            Store = new Store
                {
                    StoreName = "HHV",
                    StoreLogo = "http://www.hhv.de/assets/logos/hhv-b96bab0e4a7306d9e70ce4426870e3ca.png"
                };
        }
    }
}