using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("Masini")]
    public class Masini
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CodMasina { get; set; }

        [StringLength(150)]
        public string Descriere { get; set; }

        [Required]
        [StringLength(10)]
        public string Linie { get; set; }

        public int? Adresa { get; set; }

        public bool? Buton { get; set; }

        public int? Realizare { get; set; }

        public int? BucatiButon { get; set; }

        public int? Grup { get; set; }

        public int IdSector { get; set; }

        public int? AdresaRotto { get; set; }

        public bool? Active { get; set; }

        [StringLength(50)]
        public string Matricola { get; set; }

        public DateTime? DataAcquisto { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public DateTime? LastTimeUsed { get; set; }

        public ICollection<Realizari> Realizari { get; set; } = new List<Realizari>();

        [ForeignKey("IdSector")]
        public Sector Sector { get; set; }

        public ICollection<Operatii> Operatiis { get; set; } = new List<Operatii>();

        public ICollection<DeviceInfo> DeviceInfo { get; set;  } = new List<DeviceInfo>();
    }
}
