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
        public NumericString InvoiceNumber { get; set; }
        public DateTimeType InvoiceDate { get; set; }

        public InvoiceCreated(string invoiceNumber, DateTime invoiceDate ) {
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
        }

    }
}
