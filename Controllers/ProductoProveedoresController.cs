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
    public class ProductoProveedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var productoProveedor = await _context.ProductoProveedor.FindAsync(id);

                if (productoProveedor == null)
                {
                    return NotFound();
                }

                return productoProveedor;
            }
            else
            {
                var productoProveedores = await _context.ProductoProveedor.ToListAsync();

                if (productoProveedores == null)
                {
                    return NotFound();
                }

                return productoProveedores;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoProveedor productoProveedor)
        {
            if (id != productoProveedor.ProductoProveedorId)
            {
                return BadRequest();
            }

            _context.Entry(productoProveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoProveedorExists(id))
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
        public async Task<ActionResult<ProductoProveedor>> Post(ProductoProveedor productoProveedor)
        {
            _context.ProductoProveedor.Add(productoProveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = productoProveedor.ProductoProveedorId }, productoProveedor);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoProveedor>> Delete(int id)
        {
            var productoProveedor = await _context.ProductoProveedor.FindAsync(id);

            if (productoProveedor == null)
            {
                return NotFound();
            }

            _context.ProductoProveedor.Remove(productoProveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoProveedorExists(int id)
        {
            return _context.ProductoProveedor.Any(e => e.ProductoProveedorId == id);
        }
    }
}
