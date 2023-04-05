using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicTurn.Models
{
    [Table("Canciones")]
    public class Cancion
    {
        public Cancion()
        {
        }

        public Cancion(int cancionId, string nombre)
        {
            CancionId = cancionId;
            Nombre = nombre;
        }

        [Key]
        public int CancionId { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
