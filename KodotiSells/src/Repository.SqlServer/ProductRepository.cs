using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.SqlServer
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;          
        }

        public Product Get(int id)
        {
            var command = CreateCommand("SELECT * FROM Clients WITH(NOLOCK) WHERE IdClient = @IdClient");
            command.Parameters.AddWithValue("@IdClient", id);
        
            using (var reader = command.ExecuteReader())
            {              
                reader.Read();

                return new Product
                {
                    IdProduct = Convert.ToInt32(reader["IdProduct"]),
                    Price = Convert.ToDecimal(reader["Price"]),
                    ProductName = reader["ProductName"].ToString()
                };
            }
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
