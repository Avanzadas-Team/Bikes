using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("tiendaNewYork")]
    public partial class TiendaNewYork
    {
        public TiendaNewYork()
        {
            EmpleadosNewYork = new HashSet<EmpleadosNewYork>();
            OrdenesNewYork = new HashSet<OrdenesNewYork>();
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
        public virtual ICollection<EmpleadosNewYork> EmpleadosNewYork { get; set; }
        [InverseProperty("IdTiendaNavigation")]
        public virtual ICollection<OrdenesNewYork> OrdenesNewYork { get; set; }
    }
}
