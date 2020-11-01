using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public ProveedoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<object> Get(int id = 0)
        {
            if (id > 0)
            {
                var proveedor = context.Proveedor.FirstOrDefault(p => p.ProveedorId == id);

                if (proveedor == null)
                {
                    return NotFound();
                }

                return proveedor;
            }
            else
            {
                var proveedores = context.Proveedor
                .ToList();

                if (proveedores == null)
                {
                    return NotFound();
                }

                return proveedores;
            }
            
        }


        [HttpPost]
        public ActionResult<Proveedor> Post([FromBody] Proveedor proveedor)
        {
            proveedor.ProveedorId = 0;

            context.Proveedor.Add(proveedor);
            context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = proveedor.ProveedorId }, proveedor);

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Proveedor proveedor)
        {

            if (id != proveedor.ProveedorId)
            {
                return BadRequest();
            }

            context.Entry(proveedor).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var proveedor = context.Proveedor.FirstOrDefault(p => p.ProveedorId == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            context.Proveedor.Remove(proveedor);
            context.SaveChanges();

            return NoContent();
        }

    }
}
