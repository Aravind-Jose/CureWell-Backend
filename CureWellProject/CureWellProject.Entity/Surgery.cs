﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWellProject.Entity
{
    public class Surgery
    {
        public int SurgeryId { get; set; }
        public int DoctorId { get; set; }
        public decimal EndTime { get; set; }
        public decimal StartTime { get; set; }
        public string SurgeryCategory { get; set; }
        public DateTime SurgeryDate { get; set; }
    }
}
