using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models.Entities
{
    public class SaleItem
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        public decimal UnitDiscount { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("SalesInvoice")]
        public int SaleInvoiceId { get; set; }


        public Product Product { get; set; }
        public SalesInvoice SalesInvoice { get; set; }
    }
}