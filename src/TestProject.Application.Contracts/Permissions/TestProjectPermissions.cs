using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestProject.Permissions
{
    public static class PermissionGroup
    {
        public const string Client = "Client";
    }

    public static class PermissionType
    {
        public const string Create = "Create";
        public const string Edit = "Edit";
        public const string View = "View";
        public const string ViewFinance = "ViewFinance";
    }

    public static class TestProjectPermissions
    {
        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        public const string Client_Create = PermissionGroup.Client + "." + PermissionType.Create;
        public const string Client_Edit = PermissionGroup.Client + "." + PermissionType.Edit;
        public const string Client_View = PermissionGroup.Client + "." + PermissionType.View;
        public const string Client_ViewFinance = PermissionGroup.Client + "." + PermissionType.ViewFinance;
    }


    public static class TestProjectPermissionHelper
    {
        public static List<string> GetAllPermissionGroups()
        {
            Type type = typeof(PermissionGroup);

            return type.GetFields(BindingFlags.Public | BindingFlags.Static)
                      .Where(f => f.FieldType == typeof(string))
                      .Select(f => (string)f.GetValue(null)).ToList();
        }

        public static List<string> GetAllPermissionTypes()
        {
            Type type = typeof(PermissionType);

            return type.GetFields(BindingFlags.Public | BindingFlags.Static)
                      .Where(f => f.FieldType == typeof(string))
                      .Select(f => (string)f.GetValue(null)).ToList();
        }

        public static List<string> GetAllPermissions()
        {
            Type type = typeof(TestProjectPermissions);

            return type.GetFields(BindingFlags.Public | BindingFlags.Static)
                      .Where(f => f.FieldType == typeof(string))
                      .Select(f => (string)f.GetValue(null)).ToList();
        }
    }

}