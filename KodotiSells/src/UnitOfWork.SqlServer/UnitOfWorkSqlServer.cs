using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Interface;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkSqlServerAdapter();
        }
    }
}
