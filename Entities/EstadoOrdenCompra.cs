using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class EstadoOrdenCompra
    {
        [Key]
        public int EstadoOrdenCompraId { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
    }
}
