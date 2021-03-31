using DAL.Models;

namespace DAL.Interfaces
{
    public interface IFileRepository
    {
        File AddFile(File file);

        File GetFileById(int id, bool includeFilesCollectors = true);

        File UpdateFile(File file);

        void DeleteFile(File file);

        void Save();
    }
}
