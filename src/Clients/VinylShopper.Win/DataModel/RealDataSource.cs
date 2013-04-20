using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace VinylShopper.Win.Data
{
    public class RealDataSource
    {
        private static IEnumerable<SampleDataGroup> _groups;

        public static bool HasGroups { get { return _groups != null; } }

        public static void SetGroups(IEnumerable<SampleDataGroup> realDataGroups)
        {
            Debug.Assert(_groups == null, "should only set groups once!");
            _groups = realDataGroups;
        }


        public static SampleDataItem GetItem(string id)
        {
            var group = _groups.First(g => g.Items.Any(i => i.UniqueId == id));
            return group.Items.First(i => i.UniqueId == id);
        }

        public static SampleDataGroup GetGroup(string id)
        {
            return _groups.First(g => g.UniqueId == id);
        }

        public static void Reset()
        {
            _groups = null;
        }
    }
}