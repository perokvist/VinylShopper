using System;
using System.Resources;

namespace VinylShopper.Domain.Resources
{
    public class ResourceProxy
    {
        private static ResourceManager _resman = null;

        public static string GetLocalizedString(string key)
        {
            if (_resman == null)
                _resman = new System.Resources.ResourceManager(typeof(sv_se.AppResources)); //("WESE.EC.Mobile.Windows.Common.MyStrings.sv_se.Resources", System.Reflection.Assembly. typeof(ResourceProxy).GetTypeInfo().Assembly);

            string retval = _resman.GetString(key);
            if (String.IsNullOrEmpty(retval))
                retval = "";

            return retval;
        }
    }
}
