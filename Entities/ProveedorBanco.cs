using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class ProveedorBanco
    {
        [Key]
        public int ProveedorBancoId { get; set; }
        [Required]
        public string NumeroCuenta { get; set; }
        [Required]
        public string NombreCuenta { get; set; }

        [Required]
        public int ProveedorId { get; set; }
        [Required]
        public int BancoId { get; set; }

        public Proveedor Proveedor { get; set; }
        public Banco Banco { get; set; }
    }
}
