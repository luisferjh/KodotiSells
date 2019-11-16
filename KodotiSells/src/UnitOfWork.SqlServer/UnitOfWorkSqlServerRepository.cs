using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Repository.Interfaces;
using Repository.SqlServer;
using UnitOfWork.Interface;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository:IUnitOfWorkRepository
    {
        public IInvoiceRepository InvoiceRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IClientRepository ClientRepository { get; }
        public IInvoiceDetailRepository InvoiceDetailRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            InvoiceRepository = new InvoiceRepository(context, transaction);
            InvoiceDetailRepository = new InvoiceDetailRepository(context, transaction);
            ProductRepository = new ProductRepository(context, transaction);
            ClientRepository = new ClientRepository(context, transaction);
        }

    }
}
