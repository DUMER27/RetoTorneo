using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
    public class Partido
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        [Display(Name = "Nombre del equipo local")]
        public Equipo Local { get; set; }
        public int MarcadorLocal { get; set; }
        [Display(Name = "Nombre del equipo visitante")]
        public Equipo Visitante { get; set; }
        public int MarcadorVisitante { get; set; }
    }
}