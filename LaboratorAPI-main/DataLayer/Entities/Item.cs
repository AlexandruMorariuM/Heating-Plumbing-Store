﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Item : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; } 
        public int StockCount { get; set; }
    }
}
