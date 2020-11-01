using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoOrdenComprasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstadoOrdenComprasController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var estadoOrdenCompra = await _context.EstadoOrdenCompra.FindAsync(id);

                if (estadoOrdenCompra == null)
                {
                    return NotFound();
                }

                return estadoOrdenCompra;
            }
            else
            {
                var estadoOrdenCompras = await _context.EstadoOrdenCompra.ToListAsync();

                if (estadoOrdenCompras == null)
                {
                    return NotFound();
                }

                return estadoOrdenCompras;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EstadoOrdenCompra estadoOrdenCompra)
        {
            if (id != estadoOrdenCompra.EstadoOrdenCompraId)
            {
                return BadRequest();
            }

            _context.Entry(estadoOrdenCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoOrdenCompraExists(id))
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


        [HttpPost]
        public async Task<ActionResult<EstadoOrdenCompra>> Post(EstadoOrdenCompra estadoOrdenCompra)
        {
            _context.EstadoOrdenCompra.Add(estadoOrdenCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = estadoOrdenCompra.EstadoOrdenCompraId }, estadoOrdenCompra);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoOrdenCompra>> Delete(int id)
        {
            var estadoOrdenCompra = await _context.EstadoOrdenCompra.FindAsync(id);

            if (estadoOrdenCompra == null)
            {
                return NotFound();
            }

            _context.EstadoOrdenCompra.Remove(estadoOrdenCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoOrdenCompraExists(int id)
        {
            return _context.EstadoOrdenCompra.Any(e => e.EstadoOrdenCompraId == id);
        }
    }
}
