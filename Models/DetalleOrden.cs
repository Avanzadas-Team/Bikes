using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("detalleOrden")]
    public partial class DetalleOrden
    {
        [Key]
        [Column("idOrden")]
        public int IdOrden { get; set; }
        [Key]
        [Column("idItem")]
        public int IdItem { get; set; }
        [Column("idProducto")]
        public int IdProducto { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }
        [Column("precioVenta", TypeName = "decimal(10,2)")]
        public decimal PrecioVenta { get; set; }
        [Column("descuento", TypeName = "decimal(4,2)")]
        public decimal Descuento { get; set; }

        [ForeignKey(nameof(IdOrden))]
        [InverseProperty(nameof(Ordenes.DetalleOrden))]
        public virtual Ordenes IdOrdenNavigation { get; set; }
    }
}
