using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SAGRISA.Models;

[Table("SAGPreciosEnLinea")]
public partial class SagpreciosEnLinea
{
    [Key]
    public int CodProducto { get; set; }

    [StringLength(150)]
    public string? NomProducto { get; set; }

    [StringLength(100)]
    public string? Bodega { get; set; }

    public int? Existencia { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? Pbase { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? Costo { get; set; }

    [Column(TypeName = "decimal(10, 3)")]
    public decimal? Peso { get; set; }

    [StringLength(50)]
    public string? ListaPrecio { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? PorcentajeDesc { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? PrecioVenta { get; set; }

    [StringLength(50)]
    public string? Pais { get; set; }

    [StringLength(50)]
    public string? Clase { get; set; }

    [Column("PrecioSinIVA", TypeName = "decimal(12, 2)")]
    public decimal? PrecioSinIva { get; set; }

    public int? CantDecimales { get; set; }

    [InverseProperty("CodProductoNavigation")]
    public virtual ICollection<CotizacionDetalle> CotizacionDetalles { get; set; } = new List<CotizacionDetalle>();
}
