using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Esattori")]
    public class Collector
    {
        public const int MaxNameLength = 30;
        public const int MaxSurnameLength = 30;

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        [Column("Nome")]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxSurnameLength)]
        [Column("Cognome")]
        public string Surname { get; set; }

        public ICollection<FileCollector> FileCollectors { get; set; } = new List<FileCollector>();
    }
}
