using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("tiendaCalifornia")]
    public partial class TiendaCalifornia
    {
        public TiendaCalifornia()
        {
            EmpleadosCalifornia = new HashSet<EmpleadosCalifornia>();
            OrdenesCalifornia = new HashSet<OrdenesCalifornia>();
        }

        [Key]
        [Column("idTienda")]
        public int IdTienda { get; set; }
        [Required]
        [Column("nomTienda")]
        [StringLength(255)]
        public string NomTienda { get; set; }
        [Column("telefono")]
        [StringLength(25)]
        public string Telefono { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("calle")]
        [StringLength(255)]
        public string Calle { get; set; }
        [Column("ciudad")]
        [StringLength(255)]
        public string Ciudad { get; set; }
        [Column("estado")]
        [StringLength(10)]
        public string Estado { get; set; }
        [Column("codPostal")]
        [StringLength(5)]
        public string CodPostal { get; set; }

        [InverseProperty("IdTiendaNavigation")]
        public virtual ICollection<EmpleadosCalifornia> EmpleadosCalifornia { get; set; }
        [InverseProperty("IdTiendaNavigation")]
        public virtual ICollection<OrdenesCalifornia> OrdenesCalifornia { get; set; }
    }
}
