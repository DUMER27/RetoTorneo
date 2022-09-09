using System;
using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();

        public Partido AddPartido (Partido partido, DateTime fechahora, int LocalEquipoid, int MarcadorLocal, int VisitanteEquipoid, int MarcadorVisitante)
        {
            var LocalEncontrado = _dataContext.Equipos.Find(LocalEquipoid);
            var VisitanteEncontrado = _dataContext.Equipos.Find(VisitanteEquipoid);
            partido.Local = LocalEncontrado;
            partido.MarcadorLocal = MarcadorLocal;
            partido.Visitante = VisitanteEncontrado;
            partido.MarcadorVisitante = MarcadorVisitante;
            var PartidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return PartidoInsertado.Entity;
        }

        public IEnumerable<Partido> GetAllPartidos()
        {
            var Partidos = _dataContext.Partidos

            .Include(e => e.Local)
            .Include(e => e.Visitante)
            .ToList();

            return Partidos;
        }
    }
}