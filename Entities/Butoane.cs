using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartB.API.Entities
{
    [Table("Butoane")]
    public class Butoane
    {
        [Key]
        public long Id { get; set; }

        public int Adresa { get; set; }

        public bool Buton { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Data { get; set; }

        public int IdRealizare { get; set; }

        public int? IdDifetto { get; set; }

        [ForeignKey("IdRealizare")]
        public  Realizari Realizari { get; set; }

    }
}
