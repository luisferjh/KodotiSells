using Models;
using Repository.Interfaces.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IInvoiceDetailRepository: IReadRepository<InvoiceDetail, int>
    {
        IEnumerable<InvoiceDetail> GetAllByInvoiceId(int InvoiceId);
        void Create(IEnumerable<InvoiceDetail> model, int IdInvoice);
        void RemoveByIdInvoice(int id);
    }
}
