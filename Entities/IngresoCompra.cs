using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class IngresoCompra
    {
        [Key]
        public int IngresoCompraId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public string Periodo { get; set; }

        [Required]
        public int ProveedorId { get; set; }
        [Required]
        public int AlmacenId { get; set; }
        [Required]
        public int FacturaId { get; set; }
        [Required]
        public int OrdenCompraId { get; set; }

        public OrdenCompra OrdenCompra { get; set; }
        public Proveedor Proveedor { get; set; }
        public Almacen Almacen { get; set; }
        public Factura Factura { get; set; }
    }
}
