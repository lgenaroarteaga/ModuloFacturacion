using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.ValueObject
{
    public class DecimalNonNegative : Value<DecimalNonNegative>
    {
        protected DecimalNonNegative() { }

        public decimal Value { get; internal set; }

        internal DecimalNonNegative(decimal value)
        {
            CheckValidity(value);
            Value = value;
        }

        public static DecimalNonNegative FromDecimal(decimal value) => new DecimalNonNegative(value);
        public static DecimalNonNegative FromString(string value) => new DecimalNonNegative(decimal.Parse(value));

        protected override bool CheckValidity(object value)
        {
            decimal result = 0;
            if (!decimal.TryParse(value.ToString(), out result) | (result < 0))
                throw new ArgumentException("Value is not numeric or it is negative");
            return true;
        }

        public static implicit operator DecimalNonNegative(decimal value)
        {
            return new DecimalNonNegative(value);
        }
    }
}