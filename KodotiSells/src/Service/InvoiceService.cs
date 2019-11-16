using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using UnitOfWork.Interface;

namespace Service
{
    public class InvoiceService
    {
        //private IUnitOfWork _unitOfWork;
        //public InvoiceService(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        //public List<Invoice> GetAll()
        //{
        //    var result = new List<Invoice>();

        //    using (var context = new SqlConnection(Parameters.ConnectionString))
        //    {
        //        // abrir la conexion
        //        context.Open();

        //        //sqlCommand ejecuta comando sql
        //        // retorna un sqlDataClient
        //        var command = new SqlCommand("SELECT * FROM Invoices", context);

        //        //Este comando va a crear una clase nueva llamada 
        //        //sqlDataReader
        //        //esta clase contiene la informacion de las tablas o registros
        //        using (var reader = command.ExecuteReader())
        //        {
        //            //para poder acceder a cada registro hay que
        //            //leerlo fila por fila
        //            while (reader.Read())//este Read retorna un boolean el cual es true si tiene datos // cuando sea false el while se rompe
        //            {
        //                var invoice = new Invoice
        //                {
        //                    // el Read reconoce la fila actual
        //                    IdInvoice = Convert.ToInt32(reader["IdInvoice"]),
        //                    Iva = Convert.ToDecimal(reader["Iva"]),
        //                    Subtotal = Convert.ToDecimal(reader["Subtotal"]),
        //                    Total = Convert.ToDecimal(reader["Total"]),
        //                    IdClient = Convert.ToInt32(reader["IdClient"])
        //                };

        //                result.Add(invoice);
        //            }
        //        }                               

        //        // Set aditional properties
        //        foreach (var invoice in result)
        //        {
        //            //client
        //            SetClient(invoice, context);

        //            //Detail
        //            SetDetail(invoice, context);
        //        }
        //    }
        //    return result;
        //}

        //// obtener por id
        //public Invoice Get(int id)
        //{
        //    Invoice invoice;
        //    using (var context = new SqlConnection(Parameters.ConnectionString))
        //    {
        //        context.Open();

        //        var command = new SqlCommand("SELECT * FROM Invoices WHERE IdInvoice = @id", context);
        //        command.Parameters.AddWithValue("@id", id);

        //        using (var reader = command.ExecuteReader())
        //        {
        //            reader.Read();

        //            invoice = new Invoice
        //            {
        //                IdInvoice = Convert.ToInt32(reader["IdInvoice"]),
        //                Iva = Convert.ToDecimal(reader["Iva"]),
        //                Subtotal = Convert.ToDecimal(reader["Subtotal"]),
        //                Total = Convert.ToDecimal(reader["Total"]),
        //                IdClient = Convert.ToInt32(reader["IdClient"])
        //            };
        //        }


        //        //client
        //        SetClient(invoice, context);

        //        //Detail
        //        SetDetail(invoice, context);

        //    }
        //    return invoice;
        //}

        ////metodo para llenar las propiedades de navegacion de Invoice
        //private void SetClient(Invoice invoice, SqlConnection context)
        //{
        //    var command = new SqlCommand("SELECT * FROM Clients WHERE IdClient = @IdClient", context);
        //    command.Parameters.AddWithValue("@IdClient", invoice.IdClient);

        //    // Colocamos el using porque tenemos que cerrar un Read o Reader
        //    // antes de hacer otro Read
        //    using (var reader = command.ExecuteReader())
        //    {
        //        // No hace falta iterar el Read porque solo es una fila
        //        reader.Read();

        //        invoice.Client = new Client
        //        {
        //            IdClient = Convert.ToInt32(reader["IdClient"]),
        //            ClientName = reader["ClientName"].ToString()
        //        };
        //    }
        //}

        ////Asignar detalles
        //private void SetDetail(Invoice invoice, SqlConnection context)
        //{
        //    var command = new SqlCommand("SELECT * FROM InvoiceDetail WHERE IdInvoice = @IdInvoice", context);
        //    command.Parameters.AddWithValue("@IdInvoice", invoice.IdInvoice);

        //    using (var reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            invoice.Details.Add(new InvoiceDetail
        //            {
        //                IdInvoiceDetail = Convert.ToInt32(reader["IdInvoiceDetail"]),
        //                IdProduct = Convert.ToInt32(reader["IdProduct"]),
        //                Quantity = Convert.ToInt32(reader["Quantity"]),
        //                Iva = Convert.ToDecimal(reader["Iva"]),
        //                Subtotal = Convert.ToDecimal(reader["Subtotal"]),
        //                Total = Convert.ToDecimal(reader["Total"]),
        //                Invoice = invoice
        //            });
        //        }

        //    }

        //    foreach (var detail in invoice.Details)
        //    {
        //        // Product
        //        Setproduct(detail, context);
        //    }

        //}

        ////asginar product
        //private void Setproduct(InvoiceDetail detail, SqlConnection context)
        //{
        //    var command = new SqlCommand("SELECT * FROM Products WHERE IdProduct = @IdProduct", context);
        //    command.Parameters.AddWithValue("@IdProduct", detail.IdProduct);

        //    // Colocamos el using porque tenemos que cerrar un Read o Reader
        //    // antes de hacer otro Read
        //    using (var reader = command.ExecuteReader())
        //    {
        //        // No hace falta iterar el Read porque solo es una fila
        //        reader.Read();

        //        detail.Product = new Product
        //        {
        //            IdProduct = Convert.ToInt32(reader["IdProduct"]),
        //            Price = Convert.ToDecimal(reader["Price"]),
        //            ProductName = reader["ProductName"].ToString()
        //        };
        //    }
        //}

        ////crear un invoice
        //public void Create(Invoice model)
        //{
        //    PrepareOrder(model);

        //    using (var transaction = new TransactionScope())
        //    {
        //        using (var context = new SqlConnection(Parameters.ConnectionString))
        //        {
        //            context.Open();

        //            //Header
        //            AddHeader(model, context);

        //            //Details
        //            AddDetail(model, context);
        //        }
        //        transaction.Complete();
        //    }          
        //}

        //private void AddHeader(Invoice model, SqlConnection context)
        //{
        //    // en esta linea del query se puede implementar un procedimiento almacenado
        //    var query = "insert into Invoices(IdClient, Iva, SubTotal, Total) output INSERTED.IdInvoice values (@IdClient, @Iva, @Subtotal, @Total)";
        //    var command = new SqlCommand(query, context);

        //    command.Parameters.AddWithValue("@IdClient", model.IdClient);
        //    command.Parameters.AddWithValue("@Iva", model.Iva);
        //    command.Parameters.AddWithValue("@Subtotal", model.Subtotal);
        //    command.Parameters.AddWithValue("@Total", model.Total);

        //    model.IdInvoice = Convert.ToInt32(command.ExecuteScalar());
        //}

        //private void AddDetail(Invoice model, SqlConnection context)
        //{
        //    foreach (var detail in model.Details)
        //    {
        //        var query = "insert into InvoiceDetail(IdInvoice, IdProduct, Quantity, Price, Iva, SubTotal, Total) values (@IdInvoice, @IdProduct, @Quantity, @Price, @Iva, @Subtotal, @Total)";
        //        var command = new SqlCommand(query, context);

        //        command.Parameters.AddWithValue("@IdInvoice", model.IdInvoice);
        //        command.Parameters.AddWithValue("@IdProduct", detail.IdProduct);
        //        command.Parameters.AddWithValue("@Quantity", detail.Quantity);
        //        command.Parameters.AddWithValue("@Price", detail.Price);
        //        command.Parameters.AddWithValue("@Iva", detail.Iva);
        //        command.Parameters.AddWithValue("@Subtotal", detail.Subtotal);
        //        command.Parameters.AddWithValue("@Total", detail.Total);

        //        command.ExecuteNonQuery();
        //    }
           
        //}

        //private void PrepareOrder(Invoice model)
        //{                       
        //    foreach (var detail in model.Details)
        //    {
        //        detail.Total = detail.Quantity * detail.Price;
        //        detail.Iva = detail.Total * Parameters.IvaRate;
        //        detail.Subtotal = detail.Total - detail.Iva;
        //    }

        //    model.Total = model.Details.Sum(x => x.Total);
        //    model.Iva = model.Details.Sum(x => x.Iva);
        //    model.Subtotal = model.Details.Sum(x => x.Subtotal);
        //}

        //// Actualizar invoice
        //public void Update(Invoice model)
        //{
        //    PrepareOrder(model);
        //    using (var transaction = new TransactionScope())
        //    {
        //        using (var context = new SqlConnection(Parameters.ConnectionString))
        //        {
        //            context.Open();

        //            //Header
        //            UpdateHeader(model, context);

        //            //Remove Details
        //            RemoveDetail(model.IdInvoice, context);

        //            //Details
        //            AddDetail(model, context);
        //        }
        //        transaction.Complete();
        //    }                       
        //}

        //private void UpdateHeader(Invoice model, SqlConnection context)
        //{
        //    // en esta linea del query se puede implementar un procedimiento almacenado
        //    var query = "update Invoices set IdClient = @IdClient, Iva = @Iva, SubTotal = @Subtotal, Total = @Total WHERE IdInvoice = @IdInvoice";
   
        //    var command = new SqlCommand(query, context);

        //    command.Parameters.AddWithValue("@IdClient", model.IdClient);
        //    command.Parameters.AddWithValue("@Iva", model.Iva);
        //    command.Parameters.AddWithValue("@Subtotal", model.Subtotal);
        //    command.Parameters.AddWithValue("@Total", model.Total);
        //    command.Parameters.AddWithValue("@IdInvoice", model.IdInvoice);

        //    command.ExecuteNonQuery();
        //}

        //private void RemoveDetail(int IdInvoice, SqlConnection context)
        //{
        //    var query = "delete from InvoiceDetail WHERE IdInvoice = @IdInvoice";

        //    var command = new SqlCommand(query, context);
        //    command.Parameters.AddWithValue("@IdInvoice", IdInvoice);

        //    command.ExecuteNonQuery();
        //}

        ////Eliminar
        //public void Delete(int Id)
        //{
        //    using (var context = new SqlConnection(Parameters.ConnectionString))
        //    {
        //        context.Open();

        //        var query = "delete from Invoices WHERE IdInvoice = @Id";

        //        var command = new SqlCommand(query, context);
        //        command.Parameters.AddWithValue("@Id", Id);

        //        command.ExecuteNonQuery();
        //    }
        //}
       
    }

}
