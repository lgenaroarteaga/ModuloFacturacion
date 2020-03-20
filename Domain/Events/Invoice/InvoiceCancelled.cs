using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.Invoice
{
    public class InvoiceCancelled
    {
        DateTimeType CancellationDate { set; get; }

        public InvoiceCancelled(DateTime cancellationDate) {
            CancellationDate = cancellationDate;
        }
    }
}
