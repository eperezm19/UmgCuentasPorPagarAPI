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
    public class AlmacenesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlmacenesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id = 0)
        {
            if (id > 0)
            {
                var almacen = await _context.Almacen.FindAsync(id);

                if (almacen == null)
                {
                    return NotFound();
                }

                return almacen;
            }
            else
            {
                var proveedores = await _context.Almacen.ToListAsync();

                if (proveedores == null)
                {
                    return NotFound();
                }

                return proveedores;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Almacen almacen)
        {
            if (id != almacen.AlmacenId)
            {
                return BadRequest();
            }

            _context.Entry(almacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenExists(id))
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
        public async Task<ActionResult<Almacen>> Post(Almacen almacen)
        {
            almacen.AlmacenId = 0;

            _context.Almacen.Add(almacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = almacen.AlmacenId }, almacen);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Almacen>> Delete(int id)
        {
            var almacen = await _context.Almacen.FindAsync(id);

            if (almacen == null)
            {
                return NotFound();
            }

            _context.Almacen.Remove(almacen);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool AlmacenExists(int id)
        {
            return _context.Almacen.Any(e => e.AlmacenId == id);
        }
    }
}
