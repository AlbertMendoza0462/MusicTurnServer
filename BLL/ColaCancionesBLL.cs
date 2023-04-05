
using Microsoft.EntityFrameworkCore;
using MusicTurn.DAL;
using MusicTurn.Models;

namespace MusicTurn.BLL
{
    public class ColaCancionesBLL
    {
        private Context _context;
        public ColaCancionesBLL(Context context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int colaCancionId)
        {
            var existe =  await _context.ColaCanciones.AnyAsync(colaCancion => colaCancion.ColaCancionId == colaCancionId);
            return existe;
        }

        public async Task<bool> Guardar(ColaCancion colaCancion)
        {
            return await Existe(colaCancion.ColaCancionId) ? await Modificar(colaCancion) : await Insertar(colaCancion);
        }

        public async Task<bool> Insertar(ColaCancion colaCancion)
        {
            _context.ColaCanciones.Add(colaCancion);

            bool paso = await _context.SaveChangesAsync() > 0;

            _context.Entry(colaCancion).State = EntityState.Detached;

            return paso;
        }

        public async Task<bool> Modificar(ColaCancion colaCancion)
        {
            _context.Entry(colaCancion).State = EntityState.Modified;

            bool paso = await _context.SaveChangesAsync() > 0;

            _context.Entry(colaCancion).State = EntityState.Detached;

            return paso;
        }

        public async Task<bool> Eliminar(ColaCancion colaCancion)
        {
            _context.Entry(colaCancion).State = EntityState.Deleted;

            bool paso = await _context.SaveChangesAsync() > 0;

            _context.Entry(colaCancion).State = EntityState.Detached;

            return paso;
        }

        public async Task<bool> EliminarPrimera()
        {
            int paso = _context.Database.ExecuteSqlRaw(@$"
                PRAGMA temp_store = 2;
	            CREATE TEMP TABLE _Variable(Id INTEGER PRIMARY KEY);
	            INSERT INTO _Variable (Id) VALUES ((SELECT ColaCancionId FROM ColaCanciones LIMIT 1));
	            DELETE FROM ColaCanciones WHERE ColaCancionID = (SELECT Id FROM _Variable);
	            DROP TABLE _Variable;
            ");

            await _context.SaveChangesAsync();

            return paso > 0;
        }

        public async Task<bool> EliminarTodas()
        {
            _context.Database.ExecuteSqlRaw($"DELETE FROM ColaCanciones; UPDATE sqlite_sequence SET seq = 0 WHERE name = 'ColaCanciones';");

            bool paso = await _context.SaveChangesAsync() > 0;

            return paso;
        }

        public async Task<ColaCancion?> Buscar(int colaCancionId)
        {
            return await _context.ColaCanciones
                .Where(c => c.ColaCancionId == colaCancionId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Cancion>> GetList()
        {
            return await _context.ColaCanciones
                .Select(c => new Cancion (
                    c.CancionId,
                    c.Nombre
                ))
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
