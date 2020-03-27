using Domain.Enums;
using Domain.ValueObject;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class Invoice: AgregateRoot<InvoiceGuid>
    {
        public Guid InvoiceId { get; set; }
        public NumericNonNegative InvoiceNumber { get; set; }
        public StringNotNull ClientName { get; set; }
        public StringNotNull TaxPayerIdentificationNumber { get; set; }
        public DateTimeType EmisionDate { get; set; }
        
        public AuthorizationGuid AuthorizationId { get; set; }
        public StatusInvoice Status { get; set; }
        public List<InvoiceDetail> Detail;
        
        public Invoice(int invoiceNumber, string clientName, string taxPayerIdentificationNumber, Guid authorizationId)
        {
            InvoiceId = new Guid();
            InvoiceNumber = invoiceNumber;
            ClientName = clientName;
            TaxPayerIdentificationNumber = taxPayerIdentificationNumber;
            EmisionDate = DateTime.Now;
            AuthorizationId = authorizationId;
            Status = StatusInvoice.Declared;
            Detail = new List<InvoiceDetail>();
        }

        protected override void ValidateStatus()
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Domain.Events.Invoice.InvoiceCreated e:

                    Id =e.InvoiceID;
                    InvoiceNumber = e.InvoiceNumber;
                    ClientName = e.ClientName;
                    TaxPayerIdentificationNumber = e.TaxPayerIdentificationNumber;
                    EmisionDate = DateTime.Now;
                    AuthorizationId = e.AuthorizationId;
                    Status = StatusInvoice.Declared;
                    break;
                case Domain.Events.Invoice.InvoiceCancelled e:
                    Status = StatusInvoice.Canceled;
                    break;
                case Domain.Events.Invoice.InvoicePosted e:
                    Status = StatusInvoice.Issued;
                    break;
            }
        }
    }


}