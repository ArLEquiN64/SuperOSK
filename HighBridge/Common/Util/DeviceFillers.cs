using System.Collections;
using System.Linq;
using AForge.Video.DirectShow;

namespace HighBridge.Common.Util
{
    class DeviceFilters
    {
        public string Name { set; get; }
        public string MonikerString { set; get; }

        public IEnumerable Get()
        {
            return from FilterInfo info in new FilterInfoCollection(FilterCategory.VideoInputDevice)
                   select new DeviceFilters { Name = info.Name, MonikerString = info.MonikerString };
        }

    }
}
