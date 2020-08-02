using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace TestProject
{
    public class DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IIdentityRoleRepository _identityRoleRepository;
        private readonly ILookupNormalizer _lookupNormalizer;
        private readonly IdentityUserManager _userManager;
        private readonly IdentityRoleManager _roleManager;
        private readonly ICurrentTenant _currentTenant;
        private readonly IPermissionManager _permissionManager;

        private string _defaultTenant = "localhost";
        private string _adminUserName = "testuser";
        private string _adminEmail = "test@user.co.uk";
        private string _adminPassword = "1q2w3E*";

        private string _clientRoleName = "Client";

        public DataSeedContributor(
            IGuidGenerator guidGenerator,
            IRepository<Tenant> tenantRepository,
            ITenantManager tenantManager,
            IIdentityRoleRepository identityRoleRepository,
            ILookupNormalizer lookupNormalizer,
            IdentityUserManager userManager,
            IdentityRoleManager roleManager,
            ICurrentTenant currentTenant,
            IPermissionManager permissionManager
            )
        {
            _guidGenerator = guidGenerator;
            _tenantRepository = tenantRepository;
            _tenantManager = tenantManager;
            _lookupNormalizer = lookupNormalizer;
            _identityRoleRepository = identityRoleRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _currentTenant = currentTenant;
            _permissionManager = permissionManager;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            var defaultTenant = await _tenantRepository.FindAsync(t => t.Name == _defaultTenant);

            if (defaultTenant == null)
            {
                defaultTenant = await _tenantManager.CreateAsync(_defaultTenant);

                await _tenantRepository.InsertAsync(defaultTenant);
            }



            using (_currentTenant.Change(defaultTenant.Id))
            {
                var existingUser = await _userManager.FindByEmailAsync(_adminEmail);
                if (existingUser == null)
                {
                    existingUser = new Volo.Abp.Identity.IdentityUser(Guid.NewGuid(), _adminUserName, _adminEmail, defaultTenant.Id);

                    await _userManager.CreateAsync(existingUser, _adminPassword);
                }

                var clientRole = await _identityRoleRepository.FindByNormalizedNameAsync(_lookupNormalizer.NormalizeName(_clientRoleName));
                if (clientRole == null)
                {
                    clientRole = new Volo.Abp.Identity.IdentityRole(
                        _guidGenerator.Create(),
                        _clientRoleName,
                        defaultTenant.Id)
                    {
                        IsStatic = true,
                        IsPublic = true
                    };

                    (await _roleManager.CreateAsync(clientRole)).CheckErrors();

                    await _permissionManager.SetForRoleAsync(_clientRoleName, TestProjectPermissions.Client_Create, true);
                    await _permissionManager.SetForRoleAsync(_clientRoleName, TestProjectPermissions.Client_Edit, true);
                    await _permissionManager.SetForRoleAsync(_clientRoleName, TestProjectPermissions.Client_View, true);
                    await _permissionManager.SetForRoleAsync(_clientRoleName, TestProjectPermissions.Client_ViewFinance, true);
                }
            }
        }
    }
}
