using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class OrdenCompra
    {
        [Key]
        public int OrdenCompraId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaRecepcion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Importe { get; set; }

        [Required]
        public int EstadoOrdenCompraId { get; set; }
        [Required]
        public int ProveedorId { get; set; }

        public Proveedor Proveedor { get; set; }
        public EstadoOrdenCompra EstadoOrdenCompra { get; set; }

        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
        public virtual ICollection<IngresoCompra> IngresoCompras { get; set; }
    }
}
