using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Models
{
    public class Realizari
    {
        public int Id { get; set; }

        public int IdAngajat { get; set; }

        public int IdMasina { get; set; }

        public int IdComanda { get; set; }

        public int IdOperatie { get; set; }
        public DateTime Creat { get; set; }

        public int Cantitate { get; set; }

        public DateTime? LastWrite { get; set; }

        public bool Inchis { get; set; }

        public DateTime? FirstWrite { get; set; }

    }
}
