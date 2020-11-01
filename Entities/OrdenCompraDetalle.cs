using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class OrdenCompraDetalle
    {
        [Key]
        public int OrdenCompraDetalleId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Importe { get; set; }

        [Required]
        public int OrdenCompraId { get; set; }
        [Required]
        public int ProductoId { get; set; }

        public OrdenCompra OrdenCompra { get; set; }
        public Producto Producto { get; set; }
    }
}
