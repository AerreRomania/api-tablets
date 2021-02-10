using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{

    [Table("CommessaTIM")]
    public partial class CommessaTIM
    {
        public int CommessaTimID { get; set; }

        [Required]
        [StringLength(25)]
        public string Commessa { get; set; }

        [Required]
        [StringLength(15)]
        public string Barcode { get; set; }

        [Required]
        [StringLength(25)]
        public string Article { get; set; }

        public string DesignCode { get; set; }

        [StringLength(15)]
        public string Color { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Lot { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }
    }
}
