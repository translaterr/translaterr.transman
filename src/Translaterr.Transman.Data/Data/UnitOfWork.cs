using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Abstractions.Data;
using Translaterr.Transman.Abstractions.Repositories;
using Translaterr.Transman.Data.Contexts;

namespace Translaterr.Transman.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;
        private readonly AppDbContext _appDbContext;

        private readonly ITenantsRepository _tenantsRepository;

        public UnitOfWork(ILogger<UnitOfWork> logger, AppDbContext appDbContext, ITenantsRepository tenantsRepository)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _tenantsRepository = tenantsRepository;
        }

        public ITenantsRepository TenantsRepository => _tenantsRepository;

        public async Task<bool> SaveChanges(CancellationToken cancellationToken)
        {
            using(_logger.BeginScope("UnitOfWork.SaveChanges()"))
            {
                try
                {
                    var changes = await _appDbContext.SaveChangesAsync(cancellationToken);
                    _logger.LogDebug("A total of {numChanges} was saved to the database", changes.ToString());
                }
                catch (DbUpdateException exception)
                {
                    _logger.LogError(exception, "Unable to save changes to database");
                    return false;
                }

                return true;
            }
        }
    }
}