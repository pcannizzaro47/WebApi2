using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Pratiche")]
    public class File
    {
        public const int MaxCustomerCodeLength = 30;
        public const int MaxPhoneLength = 20;

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCustomerCodeLength)]
        [Column("CodiceCliente")]
        public string CustomerCode { get; set; }
        
        [MaxLength(MaxPhoneLength)]
        [Column("Telefono")]
        public string Phone { get; set; }

        public ICollection<FileCollector> FilesCollectors { get; set; } = new List<FileCollector>();
    }
}
