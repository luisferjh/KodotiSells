using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Invoice
    {
        public int IdInvoice { get; set; }
        public int IdClient { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public Client Client { get; set; }
    }
}
