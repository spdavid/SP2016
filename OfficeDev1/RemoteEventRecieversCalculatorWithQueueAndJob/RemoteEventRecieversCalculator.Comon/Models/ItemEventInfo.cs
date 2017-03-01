using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteEventRecieversCalculator.Comon.Models
{
    [Serializable]
    public struct ItemEventInfo
    {
        public string WebUrl { get; set; }
        public int ItemId { get; set; }

    }
}
