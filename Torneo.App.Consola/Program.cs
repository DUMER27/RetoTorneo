using System;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("============================");
                Console.WriteLine("=========   MENU   =========");
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar Director Tecnico");
                Console.WriteLine("3. Insertar Equipo");
                Console.WriteLine("4. Insertar Posicion");
                Console.WriteLine("5. Insertar Jugador");
                Console.WriteLine("6. Mostrar Municipios");
                Console.WriteLine("7. Mostrar Posiciones");
                Console.WriteLine("8. Mostrar DT");
                Console.WriteLine("9. Mostrar Equipos");
                Console.WriteLine("10. Mostrar Jugadores");
                Console.WriteLine("11. Insertar Partido");
                Console.WriteLine("12. Mostrar Partidos");
                Console.WriteLine("0. Salir");
                Console.WriteLine("============================");
                opcion = Int32.Parse(Console.ReadLine());
                Console.WriteLine("============================");
                switch (opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;
                    case 2:
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break;
                    case 4:
                        AddPosicion();
                        break;
                    case 5:
                        AddJugador();
                        break;
                    case 6:
                        Console.WriteLine("======== MUNICIPIOS ========");
                        GetAllMunicipios();
                        break;
                    case 7:
                        Console.WriteLine("======== POSICIONES ========");
                        GetAllPosiciones();
                        break;
                    case 8:
                        Console.WriteLine("============ DT ============");
                        GetAllDirectoresTecnicos();
                        break;
                    case 9:
                        Console.WriteLine("========== EQUIPOS ==========");
                        GetAllEquipos();
                        break;
                    case 10:
                        Console.WriteLine("========= JUGADORES =========");
                        GetAllJugadores();
                        break;
                    case 11:
                        AddPartido();
                        break;
                    case 12:
                        Console.WriteLine("========= PARTIDOS =========");
                        GetAllPartidos();
                        break;                   
                }
            } while (opcion != 0);
        }

        private static void AddMunicipio()
        {
            Console.WriteLine("Ingrese el nombre del Municipio");
            string nombre = Console.ReadLine(); 
            var municipio = new Municipio 
            { 
                Nombre = nombre,
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void AddDT()
        {
            Console.WriteLine("Ingrese el nombre del Director Tecnico");
            string nombre = Console.ReadLine(); 
            Console.WriteLine("Ingrese el documento del Director Tecnico");
            string documento = Console.ReadLine(); 
            Console.WriteLine("Ingrese el telefono del Director Tecnico");
            string telefono = Console.ReadLine(); 

            var directorTecnico = new DirectorTecnico
            { 
                Nombre = nombre,
                Documento = documento,
                Telefono = telefono,

            };
            _repoDT.AddDT(directorTecnico);
        }

        private static void AddEquipo()
        {
            Console.WriteLine("Ingrese el nombre del Equipo");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del Municipio");
            GetAllMunicipios();
            int idMunicipio = Int32.Parse(Console.ReadLine());
            GetAllDirectoresTecnicos();
            Console.WriteLine("Ingrese el ID del Director Tecnico");
            int idDT = Int32.Parse(Console.ReadLine());
            var equipo = new Equipo 
            { 
                Nombre = nombre,
            };
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
        }

        private static void AddPosicion()
        {
            Console.WriteLine("Ingrese la posicion");
            string nombre = Console.ReadLine(); 
            var posicion = new Posicion 
            { 
                Nombre = nombre,
            };
            _repoPosicion.AddPosicion(posicion);
        }

        private static void AddJugador()
        {
            Console.WriteLine("Ingrese el nombre del Jugador");
            string nombre = Console.ReadLine(); 
            Console.WriteLine("Ingrese el numero del Jugador");
            int numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del Equipo");
            GetAllEquipos();
            int Equipoid = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID de la posicion");
            GetAllPosiciones();
            int Posicionid = Int32.Parse(Console.ReadLine());  

            var jugador = new Jugador
            { 
                Nombre = nombre,
                Numero = numero,

            };
            _repoJugador.AddJugador(jugador, Equipoid, Posicionid);
        }

        private static void AddPartido()
        {
            Console.WriteLine("Ingrese la fecha");
            DateTime fechaHora = DateTime.Parse(Console.ReadLine());
            GetAllEquipos();
            Console.WriteLine("Ingrese el ID del equipo Local");
            int LocalEquipoid = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Marcador del local");
            int MarcadorLocal = Int32.Parse(Console.ReadLine());
            GetAllEquipos();
            Console.WriteLine("Ingrese el ID del equipo visitante");
            int VisitanteEquipoid = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Marcador del Visitante");
            int MarcadorVisitante = Int32.Parse(Console.ReadLine());
            var partido = new Partido
            {
                FechaHora = fechaHora,
            };
            _repoPartido.AddPartido (partido, fechaHora, LocalEquipoid, MarcadorLocal, VisitanteEquipoid, MarcadorVisitante);
        }

        private static void GetAllMunicipios()
        {
            foreach (var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine(municipio.Id + " - " + municipio.Nombre);
            }
        }

        private static void GetAllPosiciones()
        {
            foreach (var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine(posicion.Id + " - " + posicion.Nombre);
            }
        }

        private static void GetAllDirectoresTecnicos()
        {
            foreach (var directorTecnico in _repoDT.GetAllDirectoresTecnicos())
            {
                Console.WriteLine(directorTecnico.Id + " - " + directorTecnico.Nombre);
            }
        }

        private static void GetAllEquipos()
        {
            foreach (var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine(equipo.Id + " - " + equipo.Nombre + " - " + equipo.Municipio.Nombre + " - " + equipo.DirectorTecnico.Nombre);
            }
        }

        private static void GetAllJugadores()
        {
            foreach (var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine(jugador.Id + " - " + jugador.Nombre + " - " + jugador.Equipo.Nombre + " - " + jugador.Posicion.Nombre);
            }
        }

        private static void GetAllPartidos()
        {
            foreach (var Partido in _repoPartido.GetAllPartidos())
            {
                Console.WriteLine(Partido.Id + " - " + Partido.FechaHora + " - " + Partido.Local.Nombre + " - " + Partido.MarcadorLocal + " - " +
                Partido.Visitante.Nombre + " - " + Partido.MarcadorVisitante);
            }
        }

    }
}
