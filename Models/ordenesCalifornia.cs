using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikes.Models
{
    [Table("ordenesCalifornia")]
    public partial class OrdenesCalifornia
    {
        [Key]
        [Column("idOrden")]
        public int IdOrden { get; set; }
        [Column("idCliente")]
        public int? IdCliente { get; set; }
        [Column("estadoOrden")]
        public byte EstadoOrden { get; set; }
        [Column("fechaOrden", TypeName = "date")]
        public DateTime FechaOrden { get; set; }
        [Column("required_date", TypeName = "date")]
        public DateTime RequiredDate { get; set; }
        [Column("fechaEnvio", TypeName = "date")]
        public DateTime? FechaEnvio { get; set; }
        [Column("idTienda")]
        public int IdTienda { get; set; }
        [Column("idEmpleado")]
        public int IdEmpleado { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Clientes.OrdenesCalifornia))]
        public virtual Clientes IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdEmpleado))]
        [InverseProperty(nameof(EmpleadosCalifornia.OrdenesCalifornia))]
        public virtual EmpleadosCalifornia IdEmpleadoNavigation { get; set; }
        [ForeignKey(nameof(IdOrden))]
        [InverseProperty(nameof(Ordenes.OrdenesCalifornia))]
        public virtual Ordenes IdOrdenNavigation { get; set; }
        [ForeignKey(nameof(IdTienda))]
        [InverseProperty(nameof(TiendaCalifornia.OrdenesCalifornia))]
        public virtual TiendaCalifornia IdTiendaNavigation { get; set; }
    }
}
