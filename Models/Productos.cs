using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("productos")]
    public partial class Productos
    {
        public Productos()
        {
            InventarioCalifornia = new HashSet<InventarioCalifornia>();
            InventarioNewYork = new HashSet<InventarioNewYork>();
            InventarioTexas = new HashSet<InventarioTexas>();
        }

        [Key]
        [Column("idProducto")]
        public int IdProducto { get; set; }
        [Required]
        [Column("nomProducto")]
        [StringLength(255)]
        public string NomProducto { get; set; }
        [Column("idMarca")]
        public int IdMarca { get; set; }
        [Column("idCategoria")]
        public int IdCategoria { get; set; }
        [Column("annoModelo")]
        public short AnnoModelo { get; set; }
        [Column("precioVenta", TypeName = "decimal(10,2)")]
        public decimal PrecioVenta { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categorias.Productos))]
        public virtual Categorias IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdMarca))]
        [InverseProperty(nameof(Marcas.Productos))]
        public virtual Marcas IdMarcaNavigation { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<InventarioCalifornia> InventarioCalifornia { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<InventarioNewYork> InventarioNewYork { get; set; }
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<InventarioTexas> InventarioTexas { get; set; }
    }
}
