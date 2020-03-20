using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events.Authorization
{
    class AuthorizationDestroyed
    {
        public Guid AuthorizationId { get; set; }
  

        public AuthorizationDestroyed() { }
    }
}
