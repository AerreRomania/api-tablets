using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartB.API.Entities
{
    public class EmployeeEfficiency
    {
        public string Employee { get; set; }

        public int MachineNumber { get; set; }

        public string OrderName { get; set; }

        public string Operation { get; set; }

        public int Efficiency { get; set; }

        public string Article { get; set; }

        public double HourNorm { get; set; }

        public string Line { get; set; }

        public int PiecesDone { get; set; }

        public string Confection { get; set; }

        public string Groups { get; set; }

        public int Position { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime StartTime { get; set; }

        public string Color { get; set; }

        public string Gradient { get; set; }

        public string Size { get; set; }
    }
}
