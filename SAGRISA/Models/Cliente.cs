using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SAGRISA.Models;

public partial class Cliente
{
    [Key]
    public int CodCliente { get; set; }

    [StringLength(100)]
    public string? NomCliente { get; set; }

    [StringLength(50)]
    public string? Clase { get; set; }

    public int? Vendedor { get; set; }

    [StringLength(100)]
    public string? Ciudad { get; set; }

    [Column("TPago")]
    [StringLength(50)]
    public string? Tpago { get; set; }

    [Column("LPrecios")]
    [StringLength(50)]
    public string? Lprecios { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? MontoCredito { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? TotalDeuda { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? SaldoCredito { get; set; }

    [StringLength(100)]
    public string? Correo { get; set; }

    [InverseProperty("CodClienteNavigation")]
    public virtual ICollection<Cotizacione> Cotizaciones { get; set; } = new List<Cotizacione>();

    [InverseProperty("CodClienteNavigation")]
    public virtual ICollection<SagvpedidoEncabezado> SagvpedidoEncabezados { get; set; } = new List<SagvpedidoEncabezado>();

    [ForeignKey("Vendedor")]
    [InverseProperty("Clientes")]
    public virtual SagusuariosMovil? VendedorNavigation { get; set; }
}
