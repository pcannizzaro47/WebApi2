using WebApi2.DTO;

namespace WebApi2.ManagementServices
{
    public interface IManagementService
    {
        FileDTO AddFile(FileDTO file);

        FileDTO GetFileById(int id, bool includeFilesCollectors = true);

        FileDTO UpdateFile(FileDTO file);

        void DeleteFileById(int id);

        FileCollectorDTO AssignFile(int idFile, int idCollector);

        void UnassignFile(int idFile, int idCollector);
    }
}
