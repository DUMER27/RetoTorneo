using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        public Partido partido { get; set; }
        public DateTime FechaHora { get; set; }
        public CreateModel(IRepositorioPartido repoPartido)

        {
            _repoPartido = repoPartido;
            DateTime FechaHora = DateTime.Now; // 12/20/2015 11:48:09 AM
        }


        public void OnGet()
        {
            partido = new Partido();


        }
        //public IActionResult OnPost(Partido partido)
 //       {
 //           _repoPartido.AddPartido(partido, FechaHora);
 //           return RedirectToPage("Index");

 //       }
    }
}