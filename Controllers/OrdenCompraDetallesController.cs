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
    public class OrdenCompraDetallesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdenCompraDetallesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var ordenCompraDetalle = await _context.OrdenCompraDetalle.FindAsync(id);

                if (ordenCompraDetalle == null)
                {
                    return NotFound();
                }

                return ordenCompraDetalle;
            }
            else
            {
                var ordenCompraDetalles = await _context.OrdenCompraDetalle.ToListAsync();

                if (ordenCompraDetalles == null)
                {
                    return NotFound();
                }

                return ordenCompraDetalles;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrdenCompraDetalle ordenCompraDetalle)
        {
            if (id != ordenCompraDetalle.OrdenCompraDetalleId)
            {
                return BadRequest();
            }

            _context.Entry(ordenCompraDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenCompraDetalleExists(id))
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
        public async Task<ActionResult<OrdenCompraDetalle>> Post(OrdenCompraDetalle ordenCompraDetalle)
        {
            _context.OrdenCompraDetalle.Add(ordenCompraDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = ordenCompraDetalle.OrdenCompraDetalleId }, ordenCompraDetalle);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenCompraDetalle>> Delete(int id)
        {
            var ordenCompraDetalle = await _context.OrdenCompraDetalle.FindAsync(id);

            if (ordenCompraDetalle == null)
            {
                return NotFound();
            }

            _context.OrdenCompraDetalle.Remove(ordenCompraDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenCompraDetalleExists(int id)
        {
            return _context.OrdenCompraDetalle.Any(e => e.OrdenCompraDetalleId == id);
        }
    }
}
