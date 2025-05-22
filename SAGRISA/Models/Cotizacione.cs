using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SAGRISA.Models;

public partial class Cotizacione
{
    [Key]
    public int CodCotizacion { get; set; }

    public int CodCliente { get; set; }

    public int CodVendedor { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaHora { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? PrecioTotal { get; set; }
    public string Estado { get; set; }

    [ForeignKey("CodCliente")]
    [InverseProperty("Cotizaciones")]
    public virtual Cliente CodClienteNavigation { get; set; } = null!;

    [ForeignKey("CodVendedor")]
    [InverseProperty("Cotizaciones")]
    public virtual SagusuariosMovil CodVendedorNavigation { get; set; } = null!;

    [InverseProperty("CodCotizacionNavigation")]
    public virtual ICollection<CotizacionDetalle> CotizacionDetalles { get; set; } = new List<CotizacionDetalle>();
}
