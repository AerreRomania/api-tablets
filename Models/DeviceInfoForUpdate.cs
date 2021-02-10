﻿using System;

namespace SmartB.API.Models
{
    public class DeviceInfoForUpdate
    {
        public int DeviceID { get; set; }

        public int EmployeeID { get; set; }

        public int MachineID { get; set; }

        public DateTime UsedDate { get; set; }
    }
}
