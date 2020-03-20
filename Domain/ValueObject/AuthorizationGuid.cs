using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObject
{
    public class AuthorizationGuid : Value<AuthorizationGuid>
    {
        public Guid Value { get; set; }
        protected AuthorizationGuid() { }

        public AuthorizationGuid(Guid id)
        {

            CheckValidity(id);
            Value = id;
        }

        public static implicit operator Guid(AuthorizationGuid id) => id.Value;

        public static implicit operator AuthorizationGuid(string id)
            => new AuthorizationGuid(Guid.Parse(id));

        public static implicit operator AuthorizationGuid(Guid id)
            => new AuthorizationGuid(id);

        public static bool operator ==(AuthorizationGuid a, AuthorizationGuid b)
        {
            return a.Value.Equals(b.Value);
        }

        public static bool operator !=(AuthorizationGuid a, AuthorizationGuid b)
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
