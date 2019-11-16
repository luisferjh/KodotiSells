using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.SqlServer
{
    public abstract class Repository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        // este metodo encapsula la logica del sqlCommand porque
        // se esta trabajando siempre con bloques de transacciones 
        // El sqlCommand necesita inicializar la transaccion
        protected SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _context, _transaction);
        }
    }
}
