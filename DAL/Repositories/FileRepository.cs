using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using DAL.Models;
using System.Linq;

namespace DAL.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly SqlServerDbContext _dbContext;

        public FileRepository(SqlServerDbContext dbContext) => _dbContext = dbContext;

        public File AddFile(File file) => _dbContext.Files.Add(file).Entity;

        public File GetFileById(int id, bool includeFilesCollectors = true)
        {
            IQueryable<File> query = _dbContext.Files;

            if (includeFilesCollectors)
                query = query.Include(x => x.FilesCollectors);

            return query.SingleOrDefault(x => x.Id == id);
        }

        public File UpdateFile(File file)
        {
            var entityEntry = _dbContext.Files.Attach(file);
            entityEntry.State = EntityState.Modified;
            return entityEntry.Entity;
        }
        public void DeleteFile(File file) => _dbContext.Files.Remove(file);

        public void Save() => _dbContext.SaveChanges();
    }
}
