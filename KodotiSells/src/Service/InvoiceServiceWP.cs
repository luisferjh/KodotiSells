using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using UnitOfWork.Interface;

namespace Service
{
    public class InvoiceServiceWP
    {
        private IUnitOfWork _unitOfWork;
        public InvoiceServiceWP(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Invoice> GetAll()
        {
            var result = new List<Invoice>();

            using (var context = _unitOfWork.Create())
            {
                result = context.Repositories.InvoiceRepository.GetAll().ToList();              

                foreach (var item in result)
                {
                    item.Client = context.Repositories.ClientRepository.Get(item.IdClient);
                    item.Details = context.Repositories.InvoiceDetailRepository.GetAllByInvoiceId(item.IdInvoice).ToList();
                    foreach (var detail in item.Details)
                    {
                        detail.Product = context.Repositories.ProductRepository.Get(detail.IdProduct);                      
                    }
                }                

                return result;
            }
        }

        // obtener por id
        public Invoice Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repositories.InvoiceRepository.Get(id);
                result.Client = context.Repositories.ClientRepository.Get(result.IdClient);
                result.Details = context.Repositories.InvoiceDetailRepository.GetAllByInvoiceId(result.IdInvoice).ToList();

                foreach (var item in result.Details)
                {
                    item.Product = context.Repositories.ProductRepository.Get(item.IdProduct);
                }

                return result;
            }
        }
       
             
        //crear un invoice
        public void Create(Invoice model)
        {
            PrepareOrder(model);

            using (var context = _unitOfWork.Create())
            {
                //Header
                context.Repositories.InvoiceRepository.Create(model);

                //Details
                context.Repositories.InvoiceDetailRepository.Create(model.Details, model.IdInvoice);

                context.SaveChanges();
            }            
        }     
      
        private void PrepareOrder(Invoice model)
        {                       
            foreach (var detail in model.Details)
            {
                detail.Total = detail.Quantity * detail.Price;
                detail.Iva = detail.Total * Parameters.IvaRate;
                detail.Subtotal = detail.Total - detail.Iva;
            }

            model.Total = model.Details.Sum(x => x.Total);
            model.Iva = model.Details.Sum(x => x.Iva);
            model.Subtotal = model.Details.Sum(x => x.Subtotal);
        }

        // Actualizar invoice
        public void Update(Invoice model)
        {
            PrepareOrder(model);

            using (var context = _unitOfWork.Create())
            {
                //Header
                context.Repositories.InvoiceRepository.Update(model);

                //Details
                context.Repositories.InvoiceDetailRepository.RemoveByIdInvoice(model.IdInvoice);
                context.Repositories.InvoiceDetailRepository.Create(model.Details, model.IdInvoice);

                context.SaveChanges();
            }
        }
   

        //Eliminar
        public void Delete(int Id)
        {
            using (var context = _unitOfWork.Create())
            {
                context.Repositories.InvoiceRepository.Delete(Id);

                // Confirm changes
                context.SaveChanges();
            }
        }
       
    }

}
