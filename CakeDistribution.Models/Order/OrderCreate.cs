﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDistribution.Models.Order
{
    public class OrderCreate
    {
        public string ItemOrdered { get; set; }
        public int CustomerId { get; set; }
    }
}
