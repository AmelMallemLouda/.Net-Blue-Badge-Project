﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models
{
    public class VacationEdit
    {
        public int VacId { get; set; }
        public string VacationPackageName { get; set; }
        public string Flight { get; set; }
        public string Food { get; set; }
        public string Transportation { get; set; }
        public double Price { get; set; }
        public int HotelId { get; set; }
    }
}
