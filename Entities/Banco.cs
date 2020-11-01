using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Banco
    {
        [Key]
        public int BancoId { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<ProveedorBanco> ProveedorBancos { get; set; }
    }
}
