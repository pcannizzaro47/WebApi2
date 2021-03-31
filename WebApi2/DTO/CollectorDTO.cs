using System.ComponentModel.DataAnnotations;

namespace WebApi2.DTO
{
    public class CollectorDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(DAL.Models.Collector.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DAL.Models.Collector.MaxSurnameLength)]
        public string Surname { get; set; }
    }
}
