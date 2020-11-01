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
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                return usuario;
            }
            else
            {
                var usuarios = await _context.Usuario.ToListAsync();

                if (usuarios == null)
                {
                    return NotFound();
                }

                return usuarios;
            }

        }

        [HttpPost]
        public async Task<object> Post(Usuario usuario)
        {
            if (usuario != null && usuario.Correo != null && usuario.Contraseña != null)
            {
                Usuario user = null;
                user = await _context.Usuario.Where(u => u.Correo == usuario.Correo && u.Contraseña == usuario.Contraseña).FirstOrDefaultAsync();
                
                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            else
            {
                return NotFound();
            }

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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


        //[HttpPost]
        //public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        //{
        //    _context.Usuario.Add(usuario);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("Get", new { id = usuario.UsuarioId }, usuario);
        //}


        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }
    }
}
