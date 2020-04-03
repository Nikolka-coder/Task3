using System;
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
        public string Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExcpiryDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        Meausure Meausure { get; set; }
        public string Logo { get; set; }

    }
}