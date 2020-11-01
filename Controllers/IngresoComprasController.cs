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
    public class IngresoComprasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IngresoComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var ingresoCompra = await _context.IngresoCompra.FindAsync(id);

                if (ingresoCompra == null)
                {
                    return NotFound();
                }

                return ingresoCompra;
            }
            else
            {
                var ingresoCompras = await _context.IngresoCompra.ToListAsync();

                if (ingresoCompras == null)
                {
                    return NotFound();
                }

                return ingresoCompras;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IngresoCompra ingresoCompra)
        {
            if (id != ingresoCompra.IngresoCompraId)
            {
                return BadRequest();
            }

            _context.Entry(ingresoCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresoCompraExists(id))
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
        public async Task<ActionResult<IngresoCompra>> Post(IngresoCompra ingresoCompra)
        {
            _context.IngresoCompra.Add(ingresoCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = ingresoCompra.IngresoCompraId }, ingresoCompra);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<IngresoCompra>> Delete(int id)
        {
            var ingresoCompra = await _context.IngresoCompra.FindAsync(id);

            if (ingresoCompra == null)
            {
                return NotFound();
            }

            _context.IngresoCompra.Remove(ingresoCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngresoCompraExists(int id)
        {
            return _context.IngresoCompra.Any(e => e.IngresoCompraId == id);
        }
    }
}
