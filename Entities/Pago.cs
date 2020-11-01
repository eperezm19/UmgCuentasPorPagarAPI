using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required]
        public string Referencia { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Importe { get; set; }

        public string Periodo { get; set; }

        public bool Conciliado { get; set; }

        [Required]
        public int FormaPagoId { get; set; }
        [Required]
        public int BancoId { get; set; }
        [Required]
        public int ProveedorId { get; set; }

        public int FacturaId { get; set; }

        public Proveedor Proveedor { get; set; }
        public Factura Factura { get; set; }
        public FormaPago FormaPago { get; set; }
        public Banco Banco { get; set; }

    }
}
