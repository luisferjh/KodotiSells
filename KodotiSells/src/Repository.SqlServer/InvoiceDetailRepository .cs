using Models;
using Repository.Interfaces;
using Repository.Interfaces.Actions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.SqlServer
{
    public class InvoiceDetailRepository : Repository, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;          
        }

        public InvoiceDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceDetail> GetAllByInvoiceId(int InvoiceId)
        {
            var result = new List<InvoiceDetail>();
            var command = CreateCommand("SELECT * FROM InvoiceDetail WITH(NOLOCK) WHERE IdInvoice = @IdInvoice");
            command.Parameters.AddWithValue("@IdInvoice", InvoiceId);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new InvoiceDetail
                    {
                        IdInvoiceDetail = Convert.ToInt32(reader["IdInvoiceDetail"]),
                        IdProduct = Convert.ToInt32(reader["IdProduct"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Iva = Convert.ToDecimal(reader["Iva"]),
                        Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                        Total = Convert.ToDecimal(reader["Total"])                        
                    });
                }
            }
            return result;
        }
    }
}
