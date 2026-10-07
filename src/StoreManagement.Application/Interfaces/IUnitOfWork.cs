namespace StoreManagement.Application.Interfaces;

/// <summary>
/// Represents a unit of work for persisting domain changes.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Saves all pending changes in the current unit of work.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The number of state entries written.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}