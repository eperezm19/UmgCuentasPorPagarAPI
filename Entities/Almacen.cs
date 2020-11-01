using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Almacen
    {
        [Key]
        public int AlmacenId { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public virtual ICollection<IngresoCompra> IngresoCompras { get; set; }
    }
}
