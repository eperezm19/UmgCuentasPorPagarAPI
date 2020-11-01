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
    public class ProveedorBancosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProveedorBancosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var proveedorBanco = await _context.ProveedorBanco.FindAsync(id);

                if (proveedorBanco == null)
                {
                    return NotFound();
                }

                return proveedorBanco;
            }
            else
            {
                var proveedorBancos = await _context.ProveedorBanco.ToListAsync();

                if (proveedorBancos == null)
                {
                    return NotFound();
                }

                return proveedorBancos;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProveedorBanco proveedorBanco)
        {
            if (id != proveedorBanco.ProveedorBancoId)
            {
                return BadRequest();
            }

            _context.Entry(proveedorBanco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorBancoExists(id))
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
        public async Task<ActionResult<ProveedorBanco>> Post(ProveedorBanco proveedorBanco)
        {
            _context.ProveedorBanco.Add(proveedorBanco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = proveedorBanco.ProveedorBancoId }, proveedorBanco);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ProveedorBanco>> Delete(int id)
        {
            var proveedorBanco = await _context.ProveedorBanco.FindAsync(id);

            if (proveedorBanco == null)
            {
                return NotFound();
            }

            _context.ProveedorBanco.Remove(proveedorBanco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedorBancoExists(int id)
        {
            return _context.ProveedorBanco.Any(e => e.ProveedorBancoId == id);
        }
    }
}
