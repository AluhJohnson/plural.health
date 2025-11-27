
using plural.health.Contracts;
using plural.health.Data;
using plural.health.Infractures.Repository;
using plural.health.UOW;

namespace Kefeta.Web.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        //public IHomeRepository homeRepo { get; private set; }
        public IUserRepository userRepo { get; private set; }
       
        
        public UnitOfWork(ApplicationDbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            //homeRepo = new HomeRepository(_context, _logger);
            userRepo = new UserRepository(_context, _logger);
            
        }
        public async Task<int> CompletedAsync(string? term)
        {
            return await _context.SaveChangesAsync(term);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
