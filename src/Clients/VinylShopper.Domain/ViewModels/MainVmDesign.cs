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
                            Title = "title"
                        },
                    new Result()
                        {
                            Artist = "artist",
                            Format = "format",
                            Label = "label",
                            Price = "12 kr",
                            Title = "title2"
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