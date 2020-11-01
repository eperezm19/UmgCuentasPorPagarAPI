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
    public class FormaPagosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FormaPagosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var formaPago = await _context.FormaPago.FindAsync(id);

                if (formaPago == null)
                {
                    return NotFound();
                }

                return formaPago;
            }
            else
            {
                var formaPagos = await _context.FormaPago.ToListAsync();

                if (formaPagos == null)
                {
                    return NotFound();
                }

                return formaPagos;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FormaPago formaPago)
        {
            if (id != formaPago.FormaPagoId)
            {
                return BadRequest();
            }

            _context.Entry(formaPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagoExists(id))
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
        public async Task<ActionResult<FormaPago>> Post(FormaPago formaPago)
        {
            _context.FormaPago.Add(formaPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = formaPago.FormaPagoId }, formaPago);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<FormaPago>> Delete(int id)
        {
            var formaPago = await _context.FormaPago.FindAsync(id);

            if (formaPago == null)
            {
                return NotFound();
            }

            _context.FormaPago.Remove(formaPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormaPagoExists(int id)
        {
            return _context.FormaPago.Any(e => e.FormaPagoId == id);
        }
    }
}
