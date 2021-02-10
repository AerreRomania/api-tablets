using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartB.API.Entities
{
    [Table("DeviceInfo")]
    public class DeviceInfo
    {
        [Key]
        public int DeviceInfoID { get; set; }

        public int DeviceID { get; set; }

        public int EmployeeID { get; set; }

        public int MachineID { get; set; }

        public DateTime UsedDate { get; set; }

        [ForeignKey("EmployeeID")]
        public  Angajati Angajati { get; set; }

        [ForeignKey("DeviceID")]
        public  Devices Device { get; set; }

        [ForeignKey("MachineID")]
        public  Masini Masini { get; set; }
    }
}
