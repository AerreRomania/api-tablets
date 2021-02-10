using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartB.API.Entities
{
    public class Sector
    {
        [Key]
        public int SectorID { get; set; }

        [Required]
        [StringLength(100)]
        public string SectorName { get; set; }

        public ICollection<Angajati> Angajati { get; set; } = new List<Angajati>();

        public ICollection<Articole> Articole { get; set; } = new List<Articole>();

        public ICollection<Comenzi> Comenzi { get; set; } = new List<Comenzi>();

        public ICollection<Masini> Masini { get; set; } = new List<Masini>();

        public ICollection<Operatii> Operatii { get; set; } = new List<Operatii>();

        public ICollection<OperatiiArticol> OperatiiArticol { get; set; } = new List<OperatiiArticol>();
    }
}
