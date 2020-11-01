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
    public class PagosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PagosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var pago = await _context.Pago.FindAsync(id);

                if (pago == null)
                {
                    return NotFound();
                }

                return pago;
            }
            else
            {
                var pagos = await _context.Pago.ToListAsync();

                if (pagos == null)
                {
                    return NotFound();
                }

                return pagos;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, Pago pago)
        {
            if (id != pago.PagoId)
            {
                return BadRequest();
            }

            _context.Entry(pago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoExists(id))
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
        public async Task<ActionResult<Pago>> Post(Pago pago)
        {
            _context.Pago.Add(pago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = pago.PagoId }, pago);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Pago>> Delete(int id)
        {
            var pago = await _context.Pago.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            _context.Pago.Remove(pago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagoExists(int id)
        {
            return _context.Pago.Any(e => e.PagoId == id);
        }
    }
}
