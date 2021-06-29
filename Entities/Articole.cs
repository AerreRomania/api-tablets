using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("Articole")]
    public class Articole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Articol { get; set; }

        [StringLength(150)]
        public string Descriere { get; set; }

        public double? CostProductie { get; set; }

        public int? IdStagiune { get; set; }

        [StringLength(50)]
        public string Finete { get; set; }

        public double? Prezzo { get; set; }

        public int IdSector { get; set; }

        public double? Centes { get; set; }

        [StringLength(50)]
        public string? Stagione { get; set; }

        public bool Active { get; set; }

        [StringLength(600)]
        public string Note { get; set; }

        [ForeignKey("IdSector")]
        public  Sector Sector { get; set; }

        public  ICollection<OperatiiArticol> OperatiiArticols { get; set; } = new List<OperatiiArticol>();

        public  ICollection<Comenzi> Comenzis { get; set; } = new List<Comenzi>();
    }
}
