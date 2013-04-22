using System.Collections.ObjectModel;

namespace VinylShopper.Domain.ViewModels
{
    public class MainVmDesign : MainVm
    {
        public MainVmDesign()
        {
            ResultList = new[]
                {
                    new Result()
                        {
                            Artist = "artist",
                            Format = "format",
                            Label = "label",
                            Price = "12 kr",
                            Title = "title",
                            Store = new Store
                                {
                                    StoreName = "HHV",
                                    StoreLogo = "http://www.hhv.de/assets/logos/hhv-b96bab0e4a7306d9e70ce4426870e3ca.png"
                                }
                        },
                    new Result()
                        {
                            Artist = "artist",
                            Format = "format",
                            Label = "label",
                            Price = "12 kr",
                            Title = "title2",
                            Store = new Store
                                {
                                    StoreName = "Virgin"
                                }
                        },
                    new Result()
                        {
                            Artist = "artist",
                            Format = "format",
                            Label = "label",
                            Price = "12 kr",
                            Title = "title3"
                        }
                };
        }
    }
}