using System;
using VinylShopper.Domain.Resources;
using Windows.UI.ApplicationSettings;

namespace VinylShopper.Win.Helpers
{
    public static class SettingsHelper
    {
        public static void AddSettingsCommands(SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Clear();

            var privacyPref = new SettingsCommand("privacyPref", ResourceProxy.GetLocalizedString("PrivacyPolicyTitle"), (uiCommand) =>
                {
                    Windows.System.Launcher.LaunchUriAsync(new Uri("http://ahamprivacypolicy.azurewebsites.net/"));
                });

            args.Request.ApplicationCommands.Add(privacyPref);
        }

    }
}