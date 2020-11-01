using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Importe { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Pendiente { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Vence { get; set; }

        public string Periodo { get; set; }
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<IngresoCompra> IngresoCompras { get; set; }
    }
}
