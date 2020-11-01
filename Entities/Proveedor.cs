using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string NIT { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<ProveedorBanco> ProveedorBancos { get; set; }
        public virtual ICollection<ProductoProveedor> ProductoProveedores { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
        public virtual ICollection<IngresoCompra> IngresoCompras { get; set; }
    }
}
