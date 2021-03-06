﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Meausure Meausure { get; set; }

    }
}