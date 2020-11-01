using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostoUnit { get; set; }

        public virtual ICollection<ProductoProveedor> ProductoProveedores { get; set; }
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
    }
}
