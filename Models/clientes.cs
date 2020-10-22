using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("clientes")]
    public partial class Clientes
    {
        public Clientes()
        {
            OrdenesCalifornia = new HashSet<OrdenesCalifornia>();
            OrdenesNewYork = new HashSet<OrdenesNewYork>();
            OrdenesTexas = new HashSet<OrdenesTexas>();
        }

        [Key]
        [Column("idCliente")]
        public int IdCliente { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(255)]
        public string Nombre { get; set; }
        [Required]
        [Column("apellido")]
        [StringLength(255)]
        public string Apellido { get; set; }
        [Column("telefono")]
        [StringLength(25)]
        public string Telefono { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("calle")]
        [StringLength(255)]
        public string Calle { get; set; }
        [Column("ciudad")]
        [StringLength(50)]
        public string Ciudad { get; set; }
        [Column("estado")]
        [StringLength(25)]
        public string Estado { get; set; }
        [Column("codPostal")]
        [StringLength(5)]
        public string CodPostal { get; set; }

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<OrdenesCalifornia> OrdenesCalifornia { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<OrdenesNewYork> OrdenesNewYork { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<OrdenesTexas> OrdenesTexas { get; set; }
    }
}
