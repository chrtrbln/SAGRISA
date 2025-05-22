using System.ComponentModel.DataAnnotations;

namespace SAGRISA.ViewModels
{
    public class BusquedaViewModel
    {
        [Display(Name = "Buscar")]
        public string Termino { get; set; }

        public List<CotizacionListViewModel> Resultados { get; set; }

        public BusquedaViewModel()
        {
            Resultados = new List<CotizacionListViewModel>();
        }
    }
}
