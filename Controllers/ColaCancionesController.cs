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
    [Route("api/canciones/cola")]
    [ApiController]
    public class ColaCancionesController : ControllerBase
    {
        private readonly ColaCancionesBLL colaCancionesBLL;

        public ColaCancionesController(ColaCancionesBLL colCanBLL)
        {
            colaCancionesBLL = colCanBLL;
        }

        // GET: api/Canciones/cola
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> GetColaCanciones()
        {
            return await colaCancionesBLL.GetList();
        }

        // GET: api/Canciones/cola/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColaCancion>> GetColaCanciones(int id)
        {
            var colaCancion = await colaCancionesBLL.Buscar(id);

            if (colaCancion == null)
            {
                return NotFound();
            }

            return colaCancion;
        }

        // POST: api/Canciones/cola
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostCanciones(ColaCancion colaCancion)
        {
            return await colaCancionesBLL.Guardar(colaCancion);
        }

        // DELETE: api/Canciones/cola/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteColaCanciones(int id)
        {
            var colaCancion = await colaCancionesBLL.Buscar(id);
            if (colaCancion == null)
            {
                return NotFound();
            }

            return await colaCancionesBLL.Eliminar(colaCancion);
        }

        // DELETE: api/Canciones/cola/primera
        [HttpDelete("primera")]
        public async Task<ActionResult<bool>> DeleteColaCancionesPrimera()
        {
            return await colaCancionesBLL.EliminarPrimera();
        }

        private Task<bool> ColaCancionesExists(int id)
        {
            return colaCancionesBLL.Existe(id);
        }
    }
}
