using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("Realizari")]
    public class Realizari
    {
        [Key]
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

        public DateTime? Closed { get; set; }

        public bool? pasiv { get; set; }

        public long? IdScanare { get; set; }

        public long? NextJobId { get; set; }

        [ForeignKey("IdAngajat")]
        public Angajati Angajati { get; set; }

        [ForeignKey("IdComanda")]
        public Comenzi Comenzi { get; set; }

        [ForeignKey("IdMasina")]
        public Masini Masini { get; set; }

        [ForeignKey("IdOperatie")]
        public Operatii Operatii { get; set; }

        public  ICollection<JobEfficiency> JobEfficiencies { get; set; } = new List<JobEfficiency>();
        public ICollection<Butoane> Butoane { get; set; } = new List<Butoane>();
        public ICollection<Pause> Pauses { get; set; } = new List<Pause>();
    }
}
