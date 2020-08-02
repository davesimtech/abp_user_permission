using TestProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TestProject.Permissions
{
    public class TestProjectPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //Define your own permissions here. Example:
            //myGroup.AddPermission(TestProjectPermissions.MyPermission1, L("Permission:MyPermission1"));

            var clientGroup = context.AddGroup(PermissionGroup.Client);

            clientGroup.AddPermission(TestProjectPermissions.Client_Create);
            clientGroup.AddPermission(TestProjectPermissions.Client_Edit);
            clientGroup.AddPermission(TestProjectPermissions.Client_View);
            clientGroup.AddPermission(TestProjectPermissions.Client_ViewFinance);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TestProjectResource>(name);
        }
    }
}
