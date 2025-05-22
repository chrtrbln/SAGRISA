using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SAGRISA.Models;

[Table("SAGVPedidoEncabezado")]
public partial class SagvpedidoEncabezado
{
    [Key]
    public int NumPedido { get; set; }

    public int? CodCliente { get; set; }

    public int? CodVendedor { get; set; }

    [StringLength(50)]
    public string? Tpago { get; set; }

    public DateOnly? FechaPedido { get; set; }

    public DateOnly? FechaEntrega { get; set; }

    public string? Observacion { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? TotalPedido { get; set; }

    [StringLength(50)]
    public string? Pais { get; set; }

    [StringLength(100)]
    public string? IdDireccion { get; set; }

    [StringLength(50)]
    public string? EstCorr { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechHoraInsert { get; set; }

    [StringLength(50)]
    public string? Origen { get; set; }

    [Column("idBac")]
    [StringLength(50)]
    public string? IdBac { get; set; }

    [Column("idClieCaf")]
    [StringLength(50)]
    public string? IdClieCaf { get; set; }

    [StringLength(50)]
    public string? EstadoBac { get; set; }

    [Column("orderCaf")]
    [StringLength(50)]
    public string? OrderCaf { get; set; }

    [ForeignKey("CodCliente")]
    [InverseProperty("SagvpedidoEncabezados")]
    public virtual Cliente? CodClienteNavigation { get; set; }

    [ForeignKey("CodVendedor")]
    [InverseProperty("SagvpedidoEncabezados")]
    public virtual SagusuariosMovil? CodVendedorNavigation { get; set; }
}
