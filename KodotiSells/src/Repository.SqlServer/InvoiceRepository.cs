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

        public void Create(Invoice t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
      
        public IEnumerable<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Invoice t)
        {
            throw new NotImplementedException();
        }
    }
}
