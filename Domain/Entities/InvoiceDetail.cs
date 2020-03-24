using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class InvoiceDetail
    {
        public Guid Id { get; set; }
        public StringNotNull Detail { set; get; }
        public DecimalNonNegative UnitaryCost { set; get; }
        public NumericNonNegative Amount { set; get; }
        public InvoiceGuid InvoiceId { set; get; }
        public InvoiceDetail(string detail, decimal unitaryCost, int amount, Guid invoiceGuid)
        {
            Id = new Guid();
            Detail = detail;
            UnitaryCost = unitaryCost;
            Amount = amount;
            InvoiceId = invoiceGuid;
        }
    }
}