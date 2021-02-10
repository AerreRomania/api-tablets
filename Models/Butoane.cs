using System;

namespace SmartB.API.Models
{
    public class Butoane
    {
        public long Id { get; set; }

        public int Adresa { get; set; }

        public bool Buton { get; set; }

        public DateTime Data { get; set; }

        public int IdRealizare { get; set; }

        public int? IdDifetto { get; set; }
    }
}
