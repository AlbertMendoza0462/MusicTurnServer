
using Microsoft.EntityFrameworkCore;
using MusicTurn.DAL;
using MusicTurn.Models;

namespace MusicTurn.BLL
{
    public class CancionesBLL
    {
        private Context _context;
        public CancionesBLL(Context context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int cancionId)
        {
            var existe =  await _context.Canciones.AnyAsync(cancion => cancion.CancionId == cancionId);
            return existe;
        }

        public async Task<bool> Guardar(Cancion cancion)
        {
            return await Existe(cancion.CancionId) ? await Modificar(cancion) : await Insertar(cancion);
        }

        public async Task<bool> Insertar(Cancion cancion)
        {
            _context.Canciones.Add(cancion);

            bool paso = await _context.SaveChangesAsync() > 0;

            _context.Entry(cancion).State = EntityState.Detached;

            return paso;
        }

        public async Task<bool> Modificar(Cancion cancion)
        {
            _context.Entry(cancion).State = EntityState.Modified;

            bool paso = await _context.SaveChangesAsync() > 0;

            _context.Entry(cancion).State = EntityState.Detached;

            return paso;
        }

        public async Task<bool> Eliminar(Cancion cancion)
        {
            _context.Entry(cancion).State = EntityState.Deleted;

            bool paso = await _context.SaveChangesAsync() > 0;

            _context.Entry(cancion).State = EntityState.Detached;

            return paso;
        }

        public async Task<bool> EliminarTodas()
        {
            _context.Database.ExecuteSqlRaw($"DELETE FROM Canciones; UPDATE sqlite_sequence SET seq = 0 WHERE name = 'Canciones';");

            bool paso = await _context.SaveChangesAsync() > 0;

            return paso;
        }

        public async Task<Cancion?> Buscar(int cancionId)
        {
            return await _context.Canciones
                .Where(c => c.CancionId == cancionId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Cancion>> GetList()
        {
            return await _context.Canciones
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
