using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models.Entities
{
    public class SalesInvoice
    {
        public int Id { get; set; }
        [Required]
        public int Receipt { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public string OrderType { get; set; }
        
        public decimal TotalBill { get; set; }
        
        public decimal TotalDiscount { get; set; }
       
        public decimal NetAmount { get; set; }      
       
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerAddress { get; set; }

        public decimal DeliveryCharges { get; set; }
    }
}