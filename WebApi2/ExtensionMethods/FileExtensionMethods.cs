using WebApi2.DTO;
using DAL.Models;

namespace WebApi2.ExtensionMethods
{
    public static class FileExtensionMethods
    {
        public static FileDTO ToDTO(this File file) =>
            new()
            {
                ID = file.Id,
                CustomerCode = file.CustomerCode,
                Phone = file.Phone
            };
    }
}
