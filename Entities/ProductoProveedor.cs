using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class ProductoProveedor
    {
        [Key]
        public int ProductoProveedorId { get; set; }

        [Required]
        public int ProductoId { get; set; }
        [Required]
        public int ProveedorId { get; set; }

        public Producto Producto { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
