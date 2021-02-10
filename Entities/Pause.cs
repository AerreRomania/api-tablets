using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{

    [Table("Pause")]
    public partial class Pause
    {
        public int PauseID { get; set; }

        [Required]
        [StringLength(25)]
        public string Type { get; set; }

        public DateTime StartPause { get; set; }

        public DateTime EndPause { get; set; }

        public int RealizareID { get; set; }

        [ForeignKey("RealizareID")]
        public Realizari Realizari { get; set; }
    }
}
