using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    class AuthorizationInvalidEntityException : Exception
    {
        public AuthorizationInvalidEntityException(object entity, string message)
           : base($"Entity {entity.GetType().Name} state change rejected, {message}")
        {
        }
    }
}
