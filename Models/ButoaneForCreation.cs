using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Models
{
    public class ButoaneForCreation
    {
        public int Adresa { get; set; }

        public bool Buton { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Data { get; set; }

        public int IdRealizare { get; set; }

        public int? IdDifetto { get; set; }
    }
}
