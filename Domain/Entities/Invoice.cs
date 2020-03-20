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
        public List<InvoiceDetail> DetailList { set; get; }
        public AuthorizationGuid AuthorizationId { get; set; }
        public StatusInvoice Status { get; set; }
        public NumericString BookEntry;
        public DateTimeType BookDate { get; set; }

        public Invoice(int invoiceNumber, string clientName, string taxPayerIdentificationNumber, List<InvoiceDetail> detailList, Guid authorizationId)
        {
            InvoiceId = new Guid();
            InvoiceNumber = InvoiceNumber;
            ClientName = clientName;
            TaxPayerIdentificationNumber = taxPayerIdentificationNumber;
            DetailList = detailList;
            EmisionDate = DateTime.Now;
            AuthorizationId = authorizationId;
            Status = StatusInvoice.Declared;
            
        }

        public void AddToDetailList(InvoiceDetail invoiceDetail) {
            DetailList.Add(invoiceDetail);
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
                    DetailList = e.DetailList;
                    EmisionDate = DateTime.Now;
                    AuthorizationId = e.AuthorizationId;
                    Status = StatusInvoice.Declared;
                    break;
                case Domain.Events.Invoice.InvoiceCancelled e:
                    Status = StatusInvoice.Canceled;
                    break;
                case Domain.Events.Invoice.InvoicePosted e:
                    Status = StatusInvoice.Issued;
                    BookEntry = e.BookEntry;
                    BookDate = e.BookDate;
                    break;
                    
                
            }
        }
    }


}