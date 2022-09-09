using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioJugador
    {
        public Jugador AddJugador (Jugador jugador, int Equipoid, int Posicionid);

        public IEnumerable<Jugador> GetAllJugadores();
    }
}