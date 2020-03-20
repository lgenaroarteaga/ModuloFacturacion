using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events.Authorization
{
    class AuthorizationCreated
    {

        public Guid AuthorizationId { get; set; }
        public String AuthorizationNumber { set; get; }
        public String TaxEmitterNumber { set; get; }
        public String Name { set; get; }
        public int LastEmmitedNumber { set; get; }
        public DateTime ExpirationDate { set; get; }

        public AuthorizationCreated() { }

    }
}
