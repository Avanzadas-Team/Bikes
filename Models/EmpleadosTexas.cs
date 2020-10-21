using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("empleadosTexas")]
    public partial class EmpleadosTexas
    {
        public EmpleadosTexas()
        {
            OrdenesTexas = new HashSet<OrdenesTexas>();
        }

        [Key]
        [Column("idEmpleado")]
        public int IdEmpleado { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("telefono")]
        [StringLength(25)]
        public string Telefono { get; set; }
        [Column("activo")]
        public byte Activo { get; set; }
        [Column("idTienda")]
        public int IdTienda { get; set; }
        [Column("idJefe")]
        public int? IdJefe { get; set; }

        [ForeignKey(nameof(IdTienda))]
        [InverseProperty(nameof(TiendaTexas.EmpleadosTexas))]
        public virtual TiendaTexas IdTiendaNavigation { get; set; }
        [InverseProperty("IdEmpleadoNavigation")]
        public virtual ICollection<OrdenesTexas> OrdenesTexas { get; set; }
    }
}
