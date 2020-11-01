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
    public class BancosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BancosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var banco = await _context.Banco.FindAsync(id);

                if (banco == null)
                {
                    return NotFound();
                }

                return banco;
            }
            else
            {
                var bancos = await _context.Banco.ToListAsync();

                if (bancos == null)
                {
                    return NotFound();
                }

                return bancos;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Banco banco)
        {
            if (id != banco.BancoId)
            {
                return BadRequest();
            }

            _context.Entry(banco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancoExists(id))
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
        public async Task<ActionResult<Banco>> Post(Banco banco)
        {
            _context.Banco.Add(banco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = banco.BancoId }, banco);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Banco>> Delete(int id)
        {
            var banco = await _context.Banco.FindAsync(id);

            if (banco == null)
            {
                return NotFound();
            }

            _context.Banco.Remove(banco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BancoExists(int id)
        {
            return _context.Banco.Any(e => e.BancoId == id);
        }
    }
}
