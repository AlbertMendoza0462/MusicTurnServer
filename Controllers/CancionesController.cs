using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicTurn.BLL;
using MusicTurn.DAL;
using MusicTurn.Models;

namespace MusicTurn.Controllers
{
    [Route("api/canciones")]
    [ApiController]
    public class CancionesController : ControllerBase
    {
        private readonly CancionesBLL cancionesBLL;

        public CancionesController(CancionesBLL canBLL)
        {
            cancionesBLL = canBLL;
        }

        // GET: api/Canciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> GetCanciones()
        {
            return await cancionesBLL.GetList();
        }

        // GET: api/Canciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> GetCanciones(int id)
        {
            var cancion = await cancionesBLL.Buscar(id);

            if (cancion == null)
            {
                return NotFound();
            }

            return cancion;
        }

        // POST: api/Canciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostCanciones(Cancion cancion)
        {
            return await cancionesBLL.Guardar(cancion);
        }

        // POST: api/Canciones/insertarLista
        [HttpPost("insertarLista")]
        public async Task<ActionResult<bool>> PostListaCanciones(List<Cancion> canciones)
        {
            await cancionesBLL.EliminarTodas();

            foreach (var cancion in canciones)
            {
                bool guardo = await cancionesBLL.Guardar(cancion);
                if (!guardo) return false;
            }

            return true;
        }

        // DELETE: api/Canciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCanciones(int id)
        {
            var cancion = await cancionesBLL.Buscar(id);
            if (cancion == null)
            {
                return NotFound();
            }

            return await cancionesBLL.Eliminar(cancion);
        }

        private Task<bool> CancionesExists(int id)
        {
            return cancionesBLL.Existe(id);
        }
    }
}
