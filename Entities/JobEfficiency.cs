using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("JobEfficiency")]
    public  class JobEfficiency
    {
        [Key]
        public int EfficiencyID { get; set; }

        public long SpentTime { get; set; }

        public double Efficiency { get; set; }

        public int RealizariID { get; set; }

        [ForeignKey("RealizariID")]
        public virtual Realizari Realizari { get; set; }
    }
}
