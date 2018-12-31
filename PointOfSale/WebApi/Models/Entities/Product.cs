using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]       
        public string Name { get; set; }
        
        public long BarCode { get; set; }
        
        public byte[] Image { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        
        public decimal PurchaseDiscount { get; set; }
        
        public decimal SaleDiscount { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}