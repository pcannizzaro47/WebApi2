using System.ComponentModel.DataAnnotations;

namespace WebApi2.DTO
{
    public class FileDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(DAL.Models.File.MaxCustomerCodeLength)]

        public string CustomerCode { get; set; }
        [MaxLength(DAL.Models.File.MaxPhoneLength)]

        public string Phone { get; set; }
    }
}
