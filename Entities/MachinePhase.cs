using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("MachinePhase")]
    public class MachinePhase
    {
        [Key]
        public int MashinePhaseID { get; set; }

        [Required]
        [StringLength(100)]
        public string MashineName { get; set; }

        public int SectorID { get; set; }

        [ForeignKey("SectorID")]
        public  Sector Sector { get; set; }

        public  ICollection<Operatii> Operatiis { get; set; } = new List<Operatii>();
    }
}
