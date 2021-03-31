using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("PraticheEsattori")]
    public class FileCollector
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(File))]
        [Column("PraticaId")]
        public int FileId { get; set; }

        [ForeignKey(nameof(Collector))]
        [Column("EsattoreId")]
        public int CollectorId { get; set; }

        public File File { get; set; }

        public Collector Collector { get; set; }
    }
}
