using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Commands.V1.Invoice
{
    public class CreateInvoice
    {

        public int InvoiceNumber { get; set; }
        public String ClientName { get; set; }
        public String TaxPayerIdentificationNumber { get; set; }
        public DateTime EmisionDate { get; set; }
        public String AuthorizationId { get; set; }
        
     }
}
