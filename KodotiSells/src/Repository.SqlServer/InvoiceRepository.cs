using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.SqlServer
{
    public class InvoiceRepository : Repository, IInvoiceRepository
    {
        public InvoiceRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;          
        }

        public IEnumerable<Invoice> GetAll()
        {
            var result = new List<Invoice>();

            var command = CreateCommand("SELECT * FROM Invoices WITH(NOLOCK)");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(
                        new Invoice
                        {
                            IdInvoice = Convert.ToInt32(reader["IdInvoice"]),
                            Iva = Convert.ToDecimal(reader["Iva"]),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                            Total = Convert.ToDecimal(reader["Total"]),
                            IdClient = Convert.ToInt32(reader["IdClient"])
                        });
                }

            }

            return result;
        }

        public Invoice Get(int id)
        {
            var result = new Invoice();

            var command = CreateCommand("SELECT * FROM Invoices WHERE IdInvoice = @id");
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                result.IdInvoice = Convert.ToInt32(reader["IdInvoice"]);
                result.Iva = Convert.ToDecimal(reader["Iva"]);
                result.Subtotal = Convert.ToDecimal(reader["Subtotal"]);
                result.Total = Convert.ToDecimal(reader["Total"]);
                result.IdClient = Convert.ToInt32(reader["IdClient"]);
               
            }

            return result;
        }

        public void Create(Invoice model)
        {
            var query = "insert into Invoices(IdClient, Iva, SubTotal, Total) output INSERTED.IdInvoice values (@IdClient, @Iva, @Subtotal, @Total)";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdClient", model.IdClient);
            command.Parameters.AddWithValue("@Iva", model.Iva);
            command.Parameters.AddWithValue("@Subtotal", model.Subtotal);
            command.Parameters.AddWithValue("@Total", model.Total);

            model.IdInvoice = Convert.ToInt32(command.ExecuteScalar());
        }

        public void Update(Invoice model)
        {
            // en esta linea del query se puede implementar un procedimiento almacenado
            var query = "update Invoices set IdClient = @IdClient, Iva = @Iva, SubTotal = @Subtotal, Total = @Total WHERE IdInvoice = @IdInvoice";

            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdClient", model.IdClient);
            command.Parameters.AddWithValue("@Iva", model.Iva);
            command.Parameters.AddWithValue("@Subtotal", model.Subtotal);
            command.Parameters.AddWithValue("@Total", model.Total);
            command.Parameters.AddWithValue("@IdInvoice", model.IdInvoice);

            command.ExecuteNonQuery();
        }

                 
        public void Delete(int id)
        {
            var command = CreateCommand("DELETE FROM invoices WHERE IdInvoice = @id");
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

    }
}
