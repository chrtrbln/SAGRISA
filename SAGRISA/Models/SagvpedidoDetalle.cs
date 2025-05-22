using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SAGRISA.Models;

[Keyless]
[Table("SAGVPedidoDetalle")]
public partial class SagvpedidoDetalle
{
    public int? NumPedido { get; set; }

    public int? CodCliente { get; set; }

    public int? CodProducto { get; set; }

    [StringLength(150)]
    public string? NomProducto { get; set; }

    [StringLength(100)]
    public string? Presentacion { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? PrecioTotal { get; set; }

    public int? CodVendedor { get; set; }

    [StringLength(100)]
    public string? Bodega { get; set; }

    [StringLength(50)]
    public string? Origen { get; set; }

    [ForeignKey("CodCliente")]
    public virtual Cliente? CodClienteNavigation { get; set; }

    [ForeignKey("CodProducto")]
    public virtual SagpreciosEnLinea? CodProductoNavigation { get; set; }

    [ForeignKey("CodVendedor")]
    public virtual SagusuariosMovil? CodVendedorNavigation { get; set; }

    [ForeignKey("NumPedido")]
    public virtual SagvpedidoEncabezado? NumPedidoNavigation { get; set; }
}
