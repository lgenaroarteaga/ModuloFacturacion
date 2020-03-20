using Framework;
using Domain.Exceptions;
using Domain.ValueObject;
using Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Authorization: AgregateRoot<AuthorizationGuid>
    {
        public Guid AuthorizationId { get;  set; }
        public NumericString AuthorizationNumber { set; get; } 
        public NumericString TaxEmitterNumber { set; get; }
        public StringNotNull Name { set; get; }
        public NumericNonNegative LastEmmitedNumber { set; get; }
        public DateTime ExpirationDate { set; get; }
        public StatusAuthorization Status { get; private set; }
        public Authorization(string authorizationNumber, string taxEmitterNumber, string name, int lastEmittedNumber, DateTime expirationDate ) {
            Id = new Guid();
            AuthorizationNumber = authorizationNumber;
            TaxEmitterNumber = taxEmitterNumber;
            Name = name;
            LastEmmitedNumber = lastEmittedNumber;
            ExpirationDate = expirationDate;
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Domain.Events.Authorization.AuthorizationCreated e:
                    Id = new AuthorizationGuid(e.AuthorizationId);
                    AuthorizationId = Id.Value;
                    AuthorizationNumber = NumericString.FromString(e.AuthorizationNumber);
                    TaxEmitterNumber  = NumericString.FromString(e.TaxEmitterNumber);
                    Name = StringNotNull.FromString(e.Name);
                    LastEmmitedNumber = NumericNonNegative.FromInt(e.LastEmmitedNumber);
                    ExpirationDate = e.ExpirationDate;
                    Status = StatusAuthorization.Enabled;
                    break;
  
                case Domain.Events.Authorization.AuthorizationDestroyed e:
                    Status = StatusAuthorization.Disabled;
                    break;
            }

        }

        protected override void ValidateStatus()
        {
            //bool valid = AuthorizationId != null;
            //switch (Status)
            //{
            //    case StatusAuthorization.Disabled:

            //    case StatusAuthorization.Enabled:

            //}

            //if (!valid)
            //    throw new AuthorizationInvalidEntityException(this,
            //        $"Post-checks failed in state {Status}");
        }
    }
   
}