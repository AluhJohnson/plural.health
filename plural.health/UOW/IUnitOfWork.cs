
using plural.health.Contracts;

namespace plural.health.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepo { get; }
        
        Task<int> CompletedAsync(string? term);
    }
}
