using System;

namespace SmartB.API.Models
{
    public class RealizariForUpdate
    {
        public DateTime? FirstWrite { get; set; }
        public int Cantitate { get; set; }

        public DateTime? LastWrite { get; set; }

        public bool Inchis { get; set; }

        public DateTime? Closed { get; set; }
    }
}
