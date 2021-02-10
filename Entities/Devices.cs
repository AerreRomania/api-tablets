using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("Devices")]
    public class Devices
    {
        [Key]
        public int DeviceID { get; set; }

        [Required]
        [StringLength(250)]
        public string SN { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        [Required]
        [StringLength(250)]
        public string Model { get; set; }

        [Required]
        [StringLength(100)]
        public string Platform { get; set; }

        [Required]
        [StringLength(50)]
        public string Version { get; set; }
        
        public bool Active { get; set; }
    }
}
