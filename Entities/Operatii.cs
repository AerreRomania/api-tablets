using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("Operatii")]
    public class Operatii
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CodOperatie { get; set; }

        [Required]
        [StringLength(50)]
        public string Operatie { get; set; }

        public int PozRaport { get; set; }

        public bool isPasiv { get; set; }

        public int IdSector { get; set; }

        public bool Active { get; set; }

        public double? CostoFase { get; set; }

        public double? PrezzoFase { get; set; }

        [StringLength(50)]
        public string Descrizione { get; set; }

        
        public int? MachineID { get; set; }

        public ICollection<Realizari> Realizari { get; set; } = new List<Realizari>();

        [ForeignKey("MachineID")]
        public  Masini Masini { get; set; } = new Masini();

        public ICollection<OperatiiArticol> OperatiiArticols { get; set; } = new List<OperatiiArticol>();

        [ForeignKey("IdSector")]
        public  Sector Sector { get; set; }
    }
}
