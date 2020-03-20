using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.ValueObject
{
    public class NumericNonNegative: Value<NumericNonNegative>
    {
        protected NumericNonNegative() {}

        public int Value{ get; internal set; }

        public static NumericNonNegative FromInt(int value) => new NumericNonNegative(value);
        public static NumericNonNegative FromString(string value) => new NumericNonNegative(int.Parse(value));

        internal NumericNonNegative(int value) {
            CheckValidity(value);
            Value = value;
        }

        protected override bool CheckValidity(object value)
        {
            int result =0;
            if (!int.TryParse(value.ToString(), out result) | (result < 0))
                throw new ArgumentException("Value is not numeric or it is negative");
            return true;
            
        }

        public static implicit operator NumericNonNegative(int value)
        {
            return new NumericNonNegative(value);
        }
    }
}