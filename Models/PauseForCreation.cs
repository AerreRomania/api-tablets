using System;

namespace SmartB.API.Models
{
    public class PauseForCreation
    {
        public string Type { get; set; }

        public DateTime StartPause { get; set; }

        public DateTime EndPause { get; set; }

        public int RealizareID { get; set; }
    }
}
