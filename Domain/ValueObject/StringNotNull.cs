using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.ValueObject
{
    public class StringNotNull : Value<StringNotNull>
    {
        protected StringNotNull() { }
        public string Value { get; internal set; }
        internal StringNotNull(string value)
        {
            CheckValidity(value);
            Value = value;
        }
        public static StringNotNull FromString(string value) => new StringNotNull(value);
        protected override bool CheckValidity(object value)
        {
            if (value == null ||
            string.IsNullOrWhiteSpace(value.ToString()))
                throw new ArgumentException("Can't be an empty or null string the name");
            String strValue = (String)value;
            if (strValue.Length > 255)
                throw new ArgumentException("Can't be more than 255 characters long");
            return true;
        }

        public static implicit operator string(StringNotNull text) =>
           text.Value;

        public static implicit operator StringNotNull(string value)
        {
            return new StringNotNull(value);
        }
    }
}