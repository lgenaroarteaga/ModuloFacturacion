using Domain.ValueObject;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.Invoice
{
    class InvoicePosted 
    {
        public NumericString BookEntry { get; set; }

        public DateTimeType BookDate { get; set; }

        public InvoicePosted(string bookEntry, DateTime bookDate)
        {
            BookEntry = bookEntry;
            BookDate = bookDate;

        }
    }
}
