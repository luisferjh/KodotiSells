using Models;
using Repository.Interfaces.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IInvoiceDetailRepository: IReadRepository<InvoiceDetail, int>
    {
    }
}
