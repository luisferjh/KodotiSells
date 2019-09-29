using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class InvoiceDetail
    {
        public int IdInvoiceDetail { get; set; }
        public int IdInvoice { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
