using DAL.Models;

namespace DAL.Interfaces
{
    public interface ICollectorRepository
    {
        public Collector GetCollectorById(int id, bool includeFilesCollectors = true);
    }
}
