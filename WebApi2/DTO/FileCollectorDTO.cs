using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2.DTO
{
    public class FileCollectorDTO
    {
        public int ID { get; set; }

        public int FileId { get; set; }

        public int CollectorId { get; set; }
    }
}
