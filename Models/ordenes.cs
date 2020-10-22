using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("ordenes")]
    public partial class Ordenes
    {
        public Ordenes()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
        }

        [Key]
        [Column("idOrden")]
        public int IdOrden { get; set; }

        [InverseProperty("IdOrdenNavigation")]
        public virtual OrdenesCalifornia OrdenesCalifornia { get; set; }
        [InverseProperty("IdOrdenNavigation")]
        public virtual OrdenesNewYork OrdenesNewYork { get; set; }
        [InverseProperty("IdOrdenNavigation")]
        public virtual OrdenesTexas OrdenesTexas { get; set; }
        [InverseProperty("IdOrdenNavigation")]
        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }
    }
}
