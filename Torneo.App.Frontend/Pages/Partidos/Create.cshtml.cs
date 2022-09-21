using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        public Partido partido {get; set;}
        public CreateModel(IRepositorioPartido repoPartido)
        {
            _repoPartido = repoPartido;
            
        }


        public void OnGet()
        {
            partido = new Partido();
           

        }
        
    }
}
