using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrosVentaAspnet5.Models;

namespace LibrosVentaAspnet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly TodoContext _context;

        public LibrosController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            // Default
            // return await _context.Libros.ToListAsync();

            // LINQ Method syntax
            var crudo =_context
                .Libros
                .Join(
                    _context.Clientes,
                    libro => libro.ClienteId,
                    cliente => cliente.Id,
                    (libro, cliente) => new Libro {
                        Id = libro.Id,
                        Nombre = libro.Nombre,
                        ClienteId = libro.ClienteId,
                        Cliente = cliente
                    }
                );

            // LINQ Query syntax
            // var crudo = from libro in _context.Set<Libro>()
            //     join cliente in _context.Set<Cliente> ()
            //         on libro.ClienteId equals cliente.Id
            //     select new Libro {
            //         Id = libro.Id,
            //         Nombre = libro.Nombre,
            //         ClienteId = libro.ClienteId,
            //         Cliente = cliente
            //     };

            var lista = await crudo.ToListAsync();

            return lista;
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(long id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(long id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(long id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroExists(long id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
