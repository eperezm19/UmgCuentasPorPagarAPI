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
    public class OrdenComprasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdenComprasController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var ordenCompra = await _context.OrdenCompra.FindAsync(id);

                if (ordenCompra == null)
                {
                    return NotFound();
                }

                return ordenCompra;
            }
            else
            {
                var ordenCompras = await _context.OrdenCompra.ToListAsync();

                if (ordenCompras == null)
                {
                    return NotFound();
                }

                return ordenCompras;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrdenCompra ordenCompra)
        {
            if (id != ordenCompra.OrdenCompraId)
            {
                return BadRequest();
            }

            _context.Entry(ordenCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenCompraExists(id))
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
        public async Task<ActionResult<OrdenCompra>> Post(OrdenCompra ordenCompra)
        {
            _context.OrdenCompra.Add(ordenCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = ordenCompra.OrdenCompraId }, ordenCompra);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenCompra>> Delete(int id)
        {
            var ordenCompra = await _context.OrdenCompra.FindAsync(id);

            if (ordenCompra == null)
            {
                return NotFound();
            }

            _context.OrdenCompra.Remove(ordenCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenCompraExists(int id)
        {
            return _context.OrdenCompra.Any(e => e.OrdenCompraId == id);
        }
    }
}
