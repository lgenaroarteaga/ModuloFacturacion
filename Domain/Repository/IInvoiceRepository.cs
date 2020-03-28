using System;
using Domain;
using Domain.Entities;
using Domain.ValueObject;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IInvoiceRepository
    {
        
        Task<Invoice> Load(InvoiceGuid id);
        Task Add(Invoice entity);
        Task Delete(InvoiceGuid id);
        void Update(Invoice entity);
        Task<bool> Exists(InvoiceGuid id);

    }
}
