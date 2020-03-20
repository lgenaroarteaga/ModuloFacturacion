using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Domain.ValueObject
{
    public class NumericString : Value<NumericString>
    {
        protected NumericString() { }

        public string Value { get; internal set; }

        public static NumericString FromInt(int value) => new NumericString(value.ToString());
        public static NumericString FromString(string value) => new NumericString(value);

        internal NumericString(string value)
        {
            CheckValidity(value);
            Value = value.Trim();
        }

        protected override bool CheckValidity(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                throw new ArgumentException("Can't be an empty or null string the name");
            if (!Regex.IsMatch(value.ToString().Trim(), @"^\d+$"))
                throw new ArgumentException("String is not a numeric value");
            String strValue = (String)value;
            if (strValue.Trim().Length > 255)
                throw new ArgumentException("Can't be more than 255 characters long");
            return true;
        }

        public static implicit operator NumericString(string value)
        {
            return new NumericString(value);
        }
    }
}