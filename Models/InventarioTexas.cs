using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("inventarioTexas")]
    public partial class InventarioTexas
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
        [InverseProperty(nameof(Productos.InventarioTexas))]
        public virtual Productos IdProductoNavigation { get; set; }
    }
}
