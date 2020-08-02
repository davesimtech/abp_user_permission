using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Dtos;
using TestProject.Permissions;
using TestProject.Users;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace TestProject.AppServices
{
    [Authorize]
    public class TestAppService : CrudAppService<AppUser, UserDto, Guid>, ITestAppService
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly IRepository<IdentityRole, Guid> _roleRepository;
        private IdentityUserManager _userManager;
        private IdentityRoleManager _roleManager;
        private ICurrentTenant _currentTenant;
        private IPermissionManager _permissionManager;

        public TestAppService(
            IRepository<AppUser, Guid> uRepo,
            IIdentityUserRepository userRepository,
            IRepository<IdentityRole, Guid> roleRepository,
            ICurrentTenant currentTenant,
            IdentityUserManager userManager,
            IPermissionManager permissionManager,
            IdentityRoleManager roleManager)
            : base(uRepo)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _currentTenant = currentTenant;
            _permissionManager = permissionManager;
        }


        public async Task SetPermissions(Guid userId)
        {
            await _permissionManager.SetForUserAsync(userId, TestProjectPermissions.Client_Create, true);
            await _permissionManager.SetForUserAsync(userId, TestProjectPermissions.Client_Edit, false);
            await _permissionManager.SetForUserAsync(userId, TestProjectPermissions.Client_View, false);
            await _permissionManager.SetForUserAsync(userId, TestProjectPermissions.Client_ViewFinance, true);
        }

        [HttpGet]
        [Authorize(TestProjectPermissions.Client_Create)]
        public bool CreateClient()
        {
            return true;
        }

        [HttpGet]
        [Authorize(TestProjectPermissions.Client_Edit)]
        public bool EditClient()
        {
            return true;
        }

        [HttpGet]
        [Authorize(TestProjectPermissions.Client_View)]
        public bool ViewClient()
        {
            return true;
        }

        [HttpGet]
        [Authorize(TestProjectPermissions.Client_ViewFinance)]
        public bool ViewClientFinance()
        {
            return true;
        }
    }
}
