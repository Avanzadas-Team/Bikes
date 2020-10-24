using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("categorias")]
    public partial class Categorias
    {
        public Categorias()
        {
            Productos = new HashSet<Productos>();
        }

        [Key]
        [Column("idCategoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
