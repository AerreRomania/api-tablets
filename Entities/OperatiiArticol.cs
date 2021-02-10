using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("OperatiiArticol")]
    public class OperatiiArticol
    {
        [Key]
        public int Id { get; set; }

        public int IdArticol { get; set; }

        public int IdOperatie { get; set; }

        public double BucatiOra { get; set; }

        public int BucatiButon { get; set; }

        public int Ordine { get; set; }

        public int IdGrupe { get; set; }

        public int IdSector { get; set; }

        public bool? Extra { get; set; }

        public double? Centes { get; set; }

        [ForeignKey("IdArticol")]
        public  Articole Articole { get; set; }

        [ForeignKey("IdOperatie")]
        public  Operatii Operatii { get; set; }

        [ForeignKey("IdSector")]
        public  Sector Sector { get; set; }
    }
}
