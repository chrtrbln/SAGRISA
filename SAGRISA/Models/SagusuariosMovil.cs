using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SAGRISA.Models;

[Table("SAGUsuariosMovil")]
public partial class SagusuariosMovil
{
    [StringLength(50)]
    public string? Pin { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? Pais { get; set; }

    [Key]
    public int CodVendedor { get; set; }

    [InverseProperty("VendedorNavigation")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [InverseProperty("CodVendedorNavigation")]
    public virtual ICollection<Cotizacione> Cotizaciones { get; set; } = new List<Cotizacione>();

    [InverseProperty("CodVendedorNavigation")]
    public virtual ICollection<SagvpedidoEncabezado> SagvpedidoEncabezados { get; set; } = new List<SagvpedidoEncabezado>();
}
