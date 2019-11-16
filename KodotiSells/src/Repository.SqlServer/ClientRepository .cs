using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.SqlServer
{
    public class ClientRepository : Repository, IClientRepository
    {
        public ClientRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;          
        }

        public Client Get(int id)
        {
            var command = CreateCommand("SELECT * FROM Clients WITH(NOLOCK) WHERE IdClient = @IdClient");
            command.Parameters.AddWithValue("@IdClient", id);
        
            using (var reader = command.ExecuteReader())
            {              
                reader.Read();

                return new Client
                {
                    IdClient = Convert.ToInt32(reader["IdClient"]),
                    ClientName = reader["ClientName"].ToString()
                };
            }
        }

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
