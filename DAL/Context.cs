using MusicTurn.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicTurn.DAL
{
    public class Context: DbContext
    {
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<ColaCancion> ColaCanciones { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
