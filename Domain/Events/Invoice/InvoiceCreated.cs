using Domain.Entities;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.Invoice
{
    class InvoiceCreated 
    {
        public InvoiceGuid InvoiceID { get; set; }
        public NumericNonNegative InvoiceNumber { get; set; }
        public StringNotNull ClientName { get; set; }
        public StringNotNull TaxPayerIdentificationNumber { get; set; }
        public List<InvoiceDetail> DetailList { set; get; }
        public AuthorizationGuid AuthorizationId { get; set; }

        public InvoiceCreated(Guid authorizationId) {
            this.InvoiceID = new Guid();
        }
    }
}
