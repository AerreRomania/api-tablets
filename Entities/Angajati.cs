using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("Angajati")]
    public class Angajati
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CodAngajat { get; set; }

        [Required]
        [StringLength(50)]
        public string Angajat { get; set; }

        [Required]
        [StringLength(1)]
        public string Sex { get; set; }

        public DateTime? DataNasterii { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [StringLength(150)]
        public string Adresa { get; set; }

        public DateTime? DataAngajarii { get; set; }

        public bool? status { get; set; }

        [StringLength(50)]
        public string Linie { get; set; }

        public int IdSector { get; set; }

        public bool? Active { get; set; }

        public DateTime? LastTimeLogged { get; set; }

        [ForeignKey("IdSector")]
        public Sector Sector { get; set; }

        [StringLength(10)]
        public string Mansione { get; set; }

        public ICollection<Realizari> Realizari { get; set; } = new List<Realizari>();
        public ICollection<DeviceInfo> DeviceInfo { get; set; } = new List<DeviceInfo>();
    }
}
 