using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly DataContext _dataContext = new DataContext();

        public Jugador AddJugador (Jugador jugador, int Equipoid, int Posicionid)
        {
            var EquipoEncontrado = _dataContext.Equipos.Find(Equipoid);
            var PosicionEncontrada = _dataContext.Posiciones.Find(Posicionid);
            jugador.Equipo = EquipoEncontrado;
            jugador.Posicion = PosicionEncontrada;
            var JugadorInsertado = _dataContext.Jugadores.Add(jugador);
            _dataContext.SaveChanges();
            return JugadorInsertado.Entity;
        }

        public IEnumerable<Jugador> GetAllJugadores()
        {
            var jugador = _dataContext.Jugadores

            .Include(e => e.Equipo)
            .Include(e => e.Posicion)
            .ToList();

            return jugador;
        }
    }
}