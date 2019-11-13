using Models;
using Service;
using System;
using System.Collections.Generic;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestService.TestConnection();
            var InvoiceService = new InvoiceService();
            //var result = InvoiceService.GetAll();
            //var result = InvoiceService.Get(2);

            //crear una orden
            //var invoice = new Invoice
            //{
            //    IdClient = 1,
            //    Details = new List<InvoiceDetail>
            //    {
            //        new InvoiceDetail
            //        {
            //            IdProduct = 1,
            //            Quantity = 5,
            //            Price = 1500
            //        },
            //         new InvoiceDetail
            //        {
            //            IdProduct = 8,
            //            Quantity = 15,
            //            Price = 125
            //        }
            //    }
            //};

            //InvoiceService.Create(invoice);

            //var invoice = new Invoice
            //{
            //    IdInvoice = 34,
            //    IdClient = 1,
            //    Details = new List<InvoiceDetail>
            //    {
            //        new InvoiceDetail
            //        {
            //            IdProduct = 1,
            //            Quantity = 5,
            //            Price = 1500
            //        },
            //         new InvoiceDetail
            //        {
            //            IdProduct = 8,
            //            Quantity = 35,
            //            Price = 125
            //        }
            //    }
            //};

            //InvoiceService.Update(invoice);

            InvoiceService.Delete(34);

            Console.Read();
        }
    }
}
