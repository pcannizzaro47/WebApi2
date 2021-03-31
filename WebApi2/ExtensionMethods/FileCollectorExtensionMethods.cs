using WebApi2.DTO;
using DAL.Models;

namespace WebApi2.ExtensionMethods
{
    public static class FileCollectorExtensionMethods
    {
        public static FileCollectorDTO ToDTO(this FileCollector fileCollector) =>
            new()
            {
                ID = fileCollector.Id,
                FileId = fileCollector.FileId,
                CollectorId = fileCollector.CollectorId
            };
    }
}
