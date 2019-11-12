using Service;
using System;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestService.TestConnection();
            var InvoiceService = new InvoiceService();
            //var result = InvoiceService.GetAll();
            var result = InvoiceService.Get(2);
            Console.Read();
        }
    }
}
