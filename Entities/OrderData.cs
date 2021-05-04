using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartB.API.Entities
{
    public class OrderData
    {
       
        public string Line { get; set; }
        public string Employee { get; set; }
        public string Commessa { get; set; }
        public string Article { get; set; }
        public double Norm { get; set; }
        public int ClickWorth { get; set; }
        public string Operation { get; set; }

        public DateTime ClickTime { get; set; }

        public int ArticleOperation { get; set; }

        public int BucatiButton { get; set; }

        public DateTime FirstClick { get; set; }
    }
}
