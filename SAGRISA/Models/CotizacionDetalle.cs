using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SAGRISA.Models;

[Table("CotizacionDetalle")]
public partial class CotizacionDetalle
{
    [Key]
    public int IdDetalle { get; set; }

    public int CodCotizacion { get; set; }

    public int CodProducto { get; set; }

    [StringLength(150)]
    public string? NombreProducto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? Subtotal { get; set; }

    [ForeignKey("CodCotizacion")]
    [InverseProperty("CotizacionDetalles")]
    public virtual Cotizacione CodCotizacionNavigation { get; set; } = null!;

    [ForeignKey("CodProducto")]
    [InverseProperty("CotizacionDetalles")]
    public virtual SagpreciosEnLinea CodProductoNavigation { get; set; } = null!;
}
