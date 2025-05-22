using System.ComponentModel.DataAnnotations;

namespace SAGRISA.ViewModels
{
    public class ProductoViewModel
    {
        public string CodProducto { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        [Display(Name = "Producto")]
        public string NomProducto { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero")]
        [Display(Name = "Cantidad")]
        public decimal Cantidad { get; set; }

        [Display(Name = "Inventario")]
        public decimal Existencia { get; set; }

        [Display(Name = "Precio por unidad")]
        public decimal PrecioUnitario { get; set; }

        [Display(Name = "Precio base")]
        public decimal PrecioBase { get; set; }

        [Display(Name = "Subtotal")]
        public decimal Subtotal { get; set; }
    }
}
