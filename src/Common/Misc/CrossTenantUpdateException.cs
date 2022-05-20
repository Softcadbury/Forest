namespace Common.Misc;

using System;

public class CrossTenantUpdateException : Exception
{
    public CrossTenantUpdateException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CrossTenantUpdateException(string message)
        : base(message)
    {
    }

    public CrossTenantUpdateException()
    {
    }

    public CrossTenantUpdateException(Guid currentTenantId, Guid[] tenantsIds)
        : base("Try to update entities with different tenant ids. " +
               $"Current tenant: {currentTenantId}, List of tenants used: {string.Join(", ", tenantsIds)}")
    {
    }
}