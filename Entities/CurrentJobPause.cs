using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartB.API.Entities
{
    public class CurrentJobPause
    {
        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }
    }
}
