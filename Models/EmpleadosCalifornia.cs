using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("empleadosCalifornia")]
    public partial class EmpleadosCalifornia
    {
        public EmpleadosCalifornia()
        {
            OrdenesCalifornia = new HashSet<OrdenesCalifornia>();
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
        [InverseProperty(nameof(TiendaCalifornia.EmpleadosCalifornia))]
        public virtual TiendaCalifornia IdTiendaNavigation { get; set; }
        [InverseProperty("IdEmpleadoNavigation")]
        public virtual ICollection<OrdenesCalifornia> OrdenesCalifornia { get; set; }
    }
}
