using Models;
using Service;
using System;
using System.Collections.Generic;
using UnitOfWork.SqlServer;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestService.TestConnection();
            //var InvoiceService = new InvoiceService();
            //var result = InvoiceService.GetAll();
            //var result = InvoiceService.Get(2);

            #region InvoiceService Old
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

            //InvoiceService.Delete(34);
            #endregion

            #region InvoiceServiceWP
            var UnitOfWork = new UnitOfWorkSqlServer();

            var invoiceService = new InvoiceServiceWP(UnitOfWork);

            var result = invoiceService.Get(1);
            var result2 = invoiceService.Get(2);

            var resultGetAll = invoiceService.GetAll();

            // crear orden           
            var invoice = new Invoice
            {
                IdClient = 1,
                Details = new List<InvoiceDetail>
                {
                    new InvoiceDetail
                    {
                        IdProduct = 1,
                        Quantity = 5,
                        Price = 1500
                    },
                     new InvoiceDetail
                    {
                        IdProduct = 8,
                        Quantity = 15,
                        Price = 125
                    }
                }
            };

            //invoiceService.Create(invoice);

            //Update invoice
            var invoice2 = new Invoice
            {
                IdInvoice = 37,
                IdClient = 1,
                Details = new List<InvoiceDetail>
                {
                    new InvoiceDetail
                    {
                        IdProduct = 1,
                        Quantity = 5,
                        Price = 1500
                    },
                     new InvoiceDetail
                    {
                        IdProduct = 8,
                        Quantity = 35,
                        Price = 125
                    }
                }
            };

            //invoiceService.Update(invoice2);
            #endregion

            Console.Read();
        }
    }
}
