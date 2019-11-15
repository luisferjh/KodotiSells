using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UnitOfWork.Interface;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository:IUnitOfWorkRepository
    {
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {

        }
    }
}
