using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicTurn.Models
{
    [Table("ColaCanciones")]
    public class ColaCancion
    {
        [Key]
        public int ColaCancionId { get; set; }
        [Required, Range(1, Int32.MaxValue)]
        public int CancionId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaPeticion { get; set; } = DateTime.Now;

    }
}
