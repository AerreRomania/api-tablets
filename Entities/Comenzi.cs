using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("Comenzi")]
    public class Comenzi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string NrComanda { get; set; }

        public int IdClient { get; set; }

        public int IdArticol { get; set; }

        public DateTime DataLansare { get; set; }

        public DateTime? DataLivrare { get; set; }

        public int Cantitate { get; set; }

        public int IdStare { get; set; }

        public DateTime? DVC { get; set; }

        public int IdSector { get; set; }

        public bool Active { get; set; }

        public int? Carico { get; set; }

        public int? Diff_t { get; set; }

        [StringLength(20)]
        public string Line { get; set; }

        public double? Minuti { get; set; }

        public int? GiorniLavorati { get; set; }

        [StringLength(100)]
        public string Tessitura { get; set; }

        [StringLength(100)]
        public string Confezione { get; set; }

        [StringLength(50)]
        public string Respinte { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        public int? Consegnato { get; set; }

        public int? Diff_c { get; set; }

        [StringLength(20)]
        public string Department { get; set; }

        public DateTime? DataProduzione { get; set; }

        public DateTime? RDD { get; set; }

        public DateTime? DataFine { get; set; }

        [ForeignKey("IdArticol")]
        public Articole Articole { get; set; }

        [ForeignKey("IdSector")]
        public Sector Sector { get; set; }

        public ICollection<Realizari> Realizari { get; set; } = new List<Realizari>();
    }
}
