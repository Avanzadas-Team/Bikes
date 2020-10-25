using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("marcas")]
    public partial class Marcas
    {
        public Marcas()
        {
            Productos = new HashSet<Productos>();
        }

        [Key]
        [Column("idMarca")]
        public int IdMarca { get; set; }
        [Required]
        [Column("nomMarca")]
        [StringLength(255)]
        public string NomMarca { get; set; }

        [InverseProperty("IdMarcaNavigation")]
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
