using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class InvoiceGuid : Value<InvoiceGuid>
    {
        public Guid Value { get; set; }
        protected InvoiceGuid() { }

        public InvoiceGuid(Guid id)
        {

            CheckValidity(id);
            Value = id;
        }

        public static implicit operator Guid(InvoiceGuid id) => id.Value;

        public static implicit operator InvoiceGuid(string id)
            => new InvoiceGuid(Guid.Parse(id));

        public static implicit operator InvoiceGuid(Guid id)
            => new InvoiceGuid(id);

        public static bool operator ==(InvoiceGuid a, InvoiceGuid b)
        {
            return a.Value.Equals(b.Value);
        }

        public static bool operator !=(InvoiceGuid a, InvoiceGuid b)
        {
            return !a.Value.Equals(b.Value);
        }

        protected override bool CheckValidity(object value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value),
                    "The id cannot be the default value");
            }
            return true;
        }

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
