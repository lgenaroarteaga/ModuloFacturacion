using System;
using Domain.Entities;
using Domain.ValueObject;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAuthorizationRepository
    {

        Task<Authorization> Load(AuthorizationGuid id);
        Task Delete(AuthorizationGuid id);
        Task Add(Authorization entity);
        void Update(Authorization entity);
        Task<bool> Exists(AuthorizationGuid id);

    }
}
