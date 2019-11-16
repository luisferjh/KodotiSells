using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Interface
{
    public interface IUnitOfWorkRepository
    {
        IInvoiceRepository InvoiceRepository { get; }
        IInvoiceDetailRepository InvoiceDetailRepository{ get; }
        IProductRepository ProductRepository { get; }
        IClientRepository ClientRepository { get; }
    }
}
