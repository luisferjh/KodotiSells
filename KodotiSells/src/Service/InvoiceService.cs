using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Service
{
    public class InvoiceService
    {
        public List<Invoice> GetAll()
        {
            var result = new List<Invoice>();

            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                // abrir la conexion
                context.Open();

                //sqlCommand ejecuta comando sql
                // retorna un sqlDataClient
                var command = new SqlCommand("SELECT * FROM Invoices", context);

                //Este comando va a crear una clase nueva llamada 
                //sqlDataReader
                //esta clase contiene la informacion de las tablas o registros
                using (var reader = command.ExecuteReader())
                {
                    //para poder acceder a cada registro hay que
                    //leerlo fila por fila
                    while (reader.Read())//este Read retorna un boolean el cual es true si tiene datos // cuando sea false el while se rompe
                    {
                        var invoice = new Invoice
                        {
                            // el Read reconoce la fila actual
                            IdInvoice = Convert.ToInt32(reader["IdInvoice"]),
                            Iva = Convert.ToDecimal(reader["Iva"]),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                            Total = Convert.ToDecimal(reader["Total"]),
                            IdClient = Convert.ToInt32(reader["IdClient"])
                        };

                        result.Add(invoice);
                    }
                }                               

                // Set aditional properties
                foreach (var invoice in result)
                {
                    //client
                    SetClient(invoice, context);

                    //Detail
                    SetDetail(invoice, context);
                }
            }
            return result;
        }

        //metodo para llenar las propiedades de navegacion de Invoice
        private void SetClient(Invoice invoice, SqlConnection context)
        {
            var command = new SqlCommand("SELECT * FROM Clients WHERE IdClient = @IdClient", context);
            command.Parameters.AddWithValue("@IdClient", invoice.IdClient);

            // Colocamos el using porque tenemos que cerrar un Read o Reader
            // antes de hacer otro Read
            using (var reader = command.ExecuteReader())
            {
                // No hace falta iterar el Read porque solo es una fila
                reader.Read();

                invoice.Client = new Client
                {
                    IdClient = Convert.ToInt32(reader["IdClient"]),
                    ClientName = reader["ClientName"].ToString()
                };
            }                      
        }

        //Asignar detalles
        private void SetDetail(Invoice invoice, SqlConnection context)
        {
            var command = new SqlCommand("SELECT * FROM InvoiceDetail WHERE IdInvoice = @IdInvoice", context);
            command.Parameters.AddWithValue("@IdInvoice", invoice.IdInvoice);

            using (var reader = command.ExecuteReader())
            {               
                while (reader.Read())
                {
                    invoice.Details.Add(new InvoiceDetail
                    {
                        IdInvoiceDetail = Convert.ToInt32(reader["IdInvoiceDetail"]),
                        IdProduct = Convert.ToInt32(reader["IdProduct"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Iva = Convert.ToDecimal(reader["Iva"]),
                        Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        Invoice = invoice
                    });
                }
              
            }

            foreach (var detail in invoice.Details)
            {
                // Product
                Setproduct(detail, context);
            }

        }

        //asginar product
        private void Setproduct(InvoiceDetail detail, SqlConnection context)
        {
            var command = new SqlCommand("SELECT * FROM Products WHERE IdProduct = @IdProduct", context);
            command.Parameters.AddWithValue("@IdProduct", detail.IdProduct);

            // Colocamos el using porque tenemos que cerrar un Read o Reader
            // antes de hacer otro Read
            using (var reader = command.ExecuteReader())
            {
                // No hace falta iterar el Read porque solo es una fila
                reader.Read();

                detail.Product = new Product
                {
                    IdProduct = Convert.ToInt32(reader["IdProduct"]),
                    Price = Convert.ToDecimal(reader["Price"]),
                    ProductName = reader["ProductName"].ToString()
                };
            }
        }

        public Invoice Get(int id)
        {
            Invoice invoice;
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();

                var command = new SqlCommand("SELECT * FROM Invoices WHERE IdInvoice = @id", context);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();

                    invoice = new Invoice
                    {                      
                        IdInvoice = Convert.ToInt32(reader["IdInvoice"]),
                        Iva = Convert.ToDecimal(reader["Iva"]),
                        Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        IdClient = Convert.ToInt32(reader["IdClient"])
                    };
                }
             
               
                //client
                SetClient(invoice, context);

                //Detail
                SetDetail(invoice, context);
              
            }
            return invoice;
        }
    }

}
