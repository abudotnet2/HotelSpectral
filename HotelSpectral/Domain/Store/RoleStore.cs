﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HotelSpectral.Domain.Store
{
    public class RoleStore : IRoleStore<string>
    {
        public RoleStore()
        {
        }

        public Task<IdentityResult> CreateAsync(string role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(string role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<string> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(string role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(string role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(string role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(string role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(string role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(string role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
