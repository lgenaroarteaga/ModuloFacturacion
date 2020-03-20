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
        public Guid Id { get; set; }
        public NumericNonNegative InvoiceNumber { get; set; }
        public StringNotNull ClientName { get; set; }
        public StringNotNull TaxPayerIdentificationNumber { get; set; }
        public DateTimeType EmisionDate { get; set; }
        public List<InvoiceDetail> DetailList { set; get; }
        public Authorization Authorization { get; set; }

        public Invoice(string clientName, string taxPayerIdentificationNumber, List<InvoiceDetail> detailList, Authorization authorization)
        {
            Id = new Guid();
            ClientName = clientName;
            TaxPayerIdentificationNumber = taxPayerIdentificationNumber;
            DetailList = detailList;
            EmisionDate = DateTime.Now;
            Authorization = authorization;
            InvoiceNumber = authorization.LastEmmitedNumber.Value + 1;
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
            throw new NotImplementedException();
        }
    }


}