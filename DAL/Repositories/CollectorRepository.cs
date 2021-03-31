using System.Linq;
using DAL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CollectorRepository: ICollectorRepository
    {
        private readonly SqlServerDbContext _dbContext;

        public CollectorRepository(SqlServerDbContext dbContext) => _dbContext = dbContext;

        public Collector GetCollectorById(int id, bool includeFilesCollectors = true)
        {
            IQueryable<Collector> query = _dbContext.Collectors;

            if (includeFilesCollectors)
                query = query.Include(x => x.FileCollectors);

            return query.SingleOrDefault(x => x.Id == id);
        }
    }
}
