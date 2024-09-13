namespace BCommerce.DataAccess.Shared.Enums
{
    public enum AuditType
    {
        None = 0,
        Create = 1,
        Update = 2,
        Delete = 3,
        LoggedIn = 4,
        LogOut = 5
    }

    public enum AuditName
    {
        Create,
        Update,
        Delete,
        Login,
        Logout,
        Error
    }

    public enum PropertyType
    {
        AuditType,
        CreatedOn,
        CreatedBy,
        ModifiedOn,
        ModifiedBy
    }
}
