using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("inventarioNewYork")]
    public partial class InventarioNewYork
    {
        [Key]
        [Column("idTienda")]
        public int IdTienda { get; set; }
        [Key]
        [Column("idProducto")]
        public int IdProducto { get; set; }
        [Column("cantidad")]
        public int? Cantidad { get; set; }

        [ForeignKey(nameof(IdProducto))]
        [InverseProperty(nameof(Productos.InventarioNewYork))]
        public virtual Productos IdProductoNavigation { get; set; }
    }
}
