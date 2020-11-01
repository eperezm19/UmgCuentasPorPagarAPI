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
    public class FacturasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FacturasController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var factura = await _context.Factura.FindAsync(id);

                if (factura == null)
                {
                    return NotFound();
                }

                return factura;
            }
            else
            {
                var facturas = await _context.Factura.ToListAsync();

                if (facturas == null)
                {
                    return NotFound();
                }

                return facturas;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Factura factura)
        {
            if (id != factura.FacturaId)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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
        public async Task<ActionResult<Factura>> Post(Factura factura)
        {
            _context.Factura.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = factura.FacturaId }, factura);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Factura>> Delete(int id)
        {
            var factura = await _context.Factura.FindAsync(id);


            if (factura == null)
            {
                return NotFound();
            }

            _context.Factura.Remove(factura);
            await _context.SaveChangesAsync();

            return factura;
        }

        private bool FacturaExists(int id)
        {
            return _context.Factura.Any(e => e.FacturaId == id);
        }
    }
}
