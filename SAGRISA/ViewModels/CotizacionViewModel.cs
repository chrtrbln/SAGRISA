using System.ComponentModel.DataAnnotations;

namespace SAGRISA.ViewModels
{
    public class CotizacionViewModel
    {
        public int CodCotizacion { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        [Display(Name = "Cliente")]
        public int CodCliente { get; set; }

        [Display(Name = "Nombre del Cliente")]
        public string NombreCliente { get; set; }

        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        public string CodVendedor { get; set; }
        public string NombreVendedor { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FechaHora { get; set; }

        [Display(Name = "Total")]
        public decimal PrecioTotal { get; set; }

        public string Estado { get; set; }

        public List<ProductoViewModel> Productos { get; set; }

        public CotizacionViewModel()
        {
            Productos = new List<ProductoViewModel>();
        }
    }
}
