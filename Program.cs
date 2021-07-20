//Rodrigo Montenegro
//MICRITOS

using System;
using System.Collections;

namespace Micritos
{
    public class MenuException : Exception
    {
    }

    internal class Administrador
    {
        private static ArrayList choferes = new ArrayList();
        private static ArrayList itinerarios = new ArrayList();
        private static ArrayList recorridos = new ArrayList();
        private static ArrayList Terminales = new ArrayList();
        private static ArrayList unidades = new ArrayList();
        private static ArrayList usuarios = new ArrayList();
        private static ArrayList vendidos = new ArrayList();
        //static ArrayList ter_partida = new ArrayList();
        //static ArrayList ter_arribo = new ArrayList();

        public static void altadechoferes()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el DNI");
                int dni = int.Parse(Console.ReadLine());
                if (nombre != "" & apellido != "")
                {
                    if (dni.ToString() != "")
                    {
                        if (verificarDNIchofer(dni))
                        {
                            Console.WriteLine("Ya existe un chofer con ese DNI en la empresa");
                        }
                        else
                        {
                            Chofer.cant_c++;
                            int num_legajo = Chofer.cant_c;
                            Chofer c = new Chofer(nombre, apellido, dni, num_legajo);
                            choferes.Add(c);

                            Console.WriteLine("El chofer fue dado de alta correctamente. Su legajo es el numero " + c.num_legajo);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error, mal ingresado");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static void altaderecorridos()
        {
            try
            {
                Console.WriteLine("Seleccione las terminales del recorrido, ingrese 0 para finalizar");
                ArrayList Terminalescopia = (ArrayList)Terminales.Clone();
                Recorrido r = new Recorrido();
                int mayorLargo = 0;
                if (Terminalescopia.Count > r.terminales.Count)
                {
                    mayorLargo = Terminalescopia.Count;
                }
                else
                {
                    mayorLargo = r.terminales.Count;
                }
                for (int i = 0; i < mayorLargo; i++)
                {
                    if (Terminalescopia.Count > i)
                    {
                        Console.WriteLine(i + 1 + ")" + Terminalescopia[i]);
                    }

                    if (r.terminales.Count > i)
                    {
                        Console.Write(r.terminales[i]);
                    }
                }
                Console.WriteLine("");
                int opc = int.Parse(Console.ReadLine());
                while (opc != 0)
                {
                    r.entraTerminal((Terminal)Terminalescopia[opc - 1]);

                    Terminalescopia.Remove(Terminalescopia[opc - 1]);
                    Console.Clear();
                    titulo();
                    submenu1();
                    Console.WriteLine("Seleccione las terminales del recorrido, ingrese 0 para finalizar");
                    if (Terminalescopia.Count > r.terminales.Count)
                    {
                        mayorLargo = Terminalescopia.Count;
                    }
                    else
                    {
                        mayorLargo = r.terminales.Count;
                    }

                    for (int i = 0; i < mayorLargo; i++)
                    {
                        if (Terminalescopia.Count > i)
                        {
                            Console.Write(i + 1 + ")" + Terminalescopia[i]);
                        }
                        Console.Write("                         ");
                        if (r.terminales.Count > i)
                        {
                            Console.Write(r.terminales[i]);
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("");
                    opc = int.Parse(Console.ReadLine());
                }
                recorridos.Add(r);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error,mal ingresado");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error, indice fuera de rango");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }

            Console.WriteLine("Presione una tecla para continuar");
        }

        public static void altadeterminales()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la terminal");
                string nombre_terminal = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre de la ciudad");
                string ciudad = Console.ReadLine();
                if (nombre_terminal != "" & ciudad != "")
                {
                    Terminal t = new Terminal(nombre_terminal, ciudad);
                    Terminales.Add(t);
                    const string mensaje = "La terminal fue dada de alta correctamente";
                    Console.WriteLine(mensaje);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static void altadeusuarios()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el DNI");
                int dni = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la fecha de nacimiento");
                string fecha_nacimiento = Console.ReadLine();
                if (nombre != "" & apellido != "" & fecha_nacimiento != "")
                {
                    if (dni.ToString() != "")
                    {
                        if (verificarDNIusuario(dni))
                        {
                            Console.WriteLine("Ya existe un usuario con ese DNI en el sistema");
                        }
                        else
                        {
                            Usuario.cant++;
                            int num_usuario = Usuario.cant;
                            Usuario u = new Usuario(nombre, apellido, dni, fecha_nacimiento, num_usuario);
                            usuarios.Add(u);

                            Console.WriteLine("El usuario fue dado de alta con el numero " + Usuario.cant);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static void altedeomnibus()
        {
            try
            {
                Console.WriteLine("Ingrese la marca");
                string marca = Console.ReadLine();
                Console.WriteLine("Ingrese el modelo");
                int modelo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la capacidad");
                int capacidad = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el tipo");
                string tipo = Console.ReadLine();

                if (marca != "" & tipo != "")
                {
                    if (modelo.ToString() != "" & capacidad.ToString() != "")
                    {
                        Omnibus o = new Omnibus(marca, modelo, capacidad, tipo);

                        Omnibus.num_omnibus++;
                        unidades.Add(o);
                        Console.WriteLine("El omnibus fue dado de alta correctamente. A la unidad se le asigno el numero " + Omnibus.num_omnibus);
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error, mal ingresado");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error, numero demasiado grande");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static void asignarrecorridos()
        {
            try
            {
                Console.WriteLine("Seleccione el chofer");
                Console.WriteLine("");
                for (int i = 0; i < choferes.Count; i++)
                {
                    Console.WriteLine(i + 1 + ")" + "" + choferes[i] + "(" + i + 1 + ")");
                }
                int opc = int.Parse(Console.ReadLine());
                Chofer chofer = (Chofer)choferes[opc - 1];
                if (opc <= choferes.Count)
                {
                    chofer = (Chofer)choferes[opc - 1];
                }
                else
                {
                    Console.WriteLine("MAL INGRESADO");
                }

                Console.Clear();
                titulo();
                Console.WriteLine("Seleccione el omnibus");
                Console.WriteLine("");
                for (int x = 0; x < unidades.Count; x++)
                {
                    Console.WriteLine(x + 1 + ")" + "" + (x + 1) + "" + unidades[x]);
                }
                int opc1 = int.Parse(Console.ReadLine());
                Omnibus unidad = (Omnibus)unidades[opc1 - 1];
                if (opc1 <= unidades.Count)
                {
                    unidad = (Omnibus)unidades[opc1 - 1];
                }
                else
                {
                    Console.WriteLine("MAL INGRESADO");
                }

                Console.Clear();
                titulo();

                Console.WriteLine("Seleccione el recorrido");
                Console.WriteLine("");

                for (int x = 0; x < recorridos.Count; x++)
                {
                    Console.WriteLine(x + 1 + ")" + recorridos[x]);
                }

                int opc3 = int.Parse(Console.ReadLine());
                Recorrido recorrido = (Recorrido)recorridos[opc3 - 1];
                if (opc3 < recorridos.Count)
                {
                    recorrido = (Recorrido)recorridos[opc3 - 1];
                }
                else
                {
                    Console.WriteLine("MAL INGRESADO");
                }

                Console.Clear();
                titulo();
                const string lunes = "Lunes";
                const string martes = "Martes";
                const string miercoles = "Miercoles";
                const string jueves = "Jueves";
                const string viernes = "Viernes";
                const string sabado = "Sabado";
                const string domingo = "Domingo";

                Console.WriteLine("Seleccione el dia donde hacer el recorrido");
                Console.WriteLine("");
                Console.WriteLine("1) Lunes");
                Console.WriteLine("2) Martes");
                Console.WriteLine("3) Miercoles");
                Console.WriteLine("4) Jueves");
                Console.WriteLine("5) Viernes");
                Console.WriteLine("6) Sabado");
                Console.WriteLine("7) Domingo");
                int d = int.Parse(Console.ReadLine());
                string dia = "";

                switch (d)
                {
                    case 1:
                        dia = lunes;
                        break;

                    case 2:
                        dia = martes;
                        break;

                    case 3:
                        dia = miercoles;
                        break;

                    case 4:
                        dia = jueves;
                        break;

                    case 5:
                        dia = viernes;
                        break;

                    case 6:
                        dia = sabado;
                        break;

                    case 7:
                        dia = domingo;
                        break;

                    default:
                        Console.WriteLine("Mal ingresado");
                        break;
                }
                if (verificarChoferDia(dia, chofer.ToString()))
                {
                    Console.WriteLine("El chofer ya hace un viaje ese dia");
                }
                else
                {
                    if (verificarOmnibusDia(dia, unidad.ToString()))
                    {
                        Console.WriteLine("El omnibus ya esta reservado ese dia");
                    }
                    else
                    {
                        Itinerario iti = new Itinerario(chofer, unidad, recorrido, dia);
                        itinerarios.Add(iti);
                        Console.WriteLine("La asignacion del recorrido fue dada de alta correctamente");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(e);
                Console.ReadKey();
                submenu2();
            }

            submenu2();
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static void compradepasajes()
        {
            try
            {
                Console.WriteLine("Ingrese el numero de usuario");
                int numU = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el DNI del usuario");
                int dni = int.Parse(Console.ReadLine());
                Console.Clear();
                titulo();

                if (verificarDNIusuario(dni))
                {
                    Console.WriteLine("Seleccione la terminal de partida");
                    for (int x = 0; x < Terminales.Count; x++)
                    {
                        Console.WriteLine(x + 1 + ")" + Terminales[x]);
                    }
                    int opc = int.Parse(Console.ReadLine());
                    if (opc <= Terminales.Count)
                    {
                        Terminal salida = (Terminal)Terminales[opc - 1];
                        Console.Clear();
                        titulo();
                        Console.WriteLine("Seleccione la terminal de arribo");
                        for (int x = 0; x < Terminales.Count; x++)
                        {
                            Console.WriteLine(x + 1 + ")" + Terminales[x]);
                        }
                        int op = int.Parse(Console.ReadLine());
                        if (op <= Terminales.Count)
                        {
                            Terminal llegada = (Terminal)Terminales[op - 1];
                            if (salida == llegada)
                            {
                                Console.WriteLine("La terminal de partida y la de arribo son la misma");
                            }
                            else
                            {
                                for (int x = 0; x < itinerarios.Count; x++)
                                {
                                    foreach (Itinerario i in itinerarios)
                                    {
                                        int paradas = 0;
                                        Recorrido r = i.recorridopublico;
                                        if (r.verificarTerminal(salida.ToString()) & r.verificarTerminal(llegada.ToString()))
                                        {
                                            Console.Clear();
                                            titulo();
                                            Console.WriteLine("Seleccione el itinerario");
                                            Omnibus om = i.unidadpublico;
                                            Console.WriteLine(x + 1 + ")" + " " + "Saliendo de " + salida + " y llegando a " + llegada + " (" + paradas + " paradas intermedias, " + i.diapublico + ", " + om.tipopublico);

                                            int o = int.Parse(Console.ReadLine());
                                            if (o <= itinerarios.Count)
                                            {
                                                string pasaje = itinerarios[o - 1].ToString();
                                                vendidos.Add(pasaje);

                                                Console.WriteLine("¿Cuantos pasajes desea?");
                                                int cant = int.Parse(Console.ReadLine());

                                                salida.cant_Origenpublico += cant;
                                                llegada.cant_Arribopublico += cant;
                                                vendidos.Add(cant);
                                                Usuario u = devolverUsuario(dni);
                                                Pasaje.cantPasajes = cant + Pasaje.cantPasajes;
                                                Console.WriteLine("La venta se ha realizado con exito");
                                                if (u != null)
                                                {
                                                    u.cant_comprados += cant;
                                                }
                                                Console.ReadKey();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No existe ningun recorrido con las terminales de partida y arribo solicitadas");
                                            submenu3();
                                            Console.ReadKey(true);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El usuario solicitado no existe en el sistema");
                    submenu3();
                    Console.ReadKey(true);
                }
                titulo();

                submenu3();
                Console.WriteLine("Presione una tecla para continuar");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
                submenu3();
                Console.WriteLine("Presione una tecla para continuar");
            }
        }

        public static void consultarTerArribo()
        {
            Console.WriteLine("Listado de terminales como arribo");
            foreach (Terminal llegada in Terminales)
            {
                Console.WriteLine(llegada.ciudadpublico + " " + "(" + llegada.cant_Arribopublico + ")");
            }
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static void consultarTerPartida()
        {
            Console.WriteLine("Listado de terminales como partida");
            foreach (Terminal salida in Terminales)
            {
                Console.WriteLine(salida.ciudadpublico + " " + "(" + salida.cant_Origenpublico + ")");
            }
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static void consultarUsuarios()
        {
            Console.WriteLine("Listado de ventas por usuarios");
            foreach (Usuario u in usuarios)
            {
                Console.WriteLine(u.nombrepublico + " " + u.apellidopublico + " " + "(" + u.cant_compradospublico + ")");
            }
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static Usuario devolverUsuario(int dni)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.dnipublico == dni)
                {
                    return u;
                }
            }
            return null;
        }

        public static void Main(string[] args)
        {
            try
            {
                titulo();
                Console.WriteLine("¿A que modulo desea ingresar?");
                Console.WriteLine(" ");
                Console.WriteLine("1) Armado de recorridos");
                Console.WriteLine("2) Gestion de choferes");
                Console.WriteLine("3) Ventas de pasajes");
                Console.WriteLine("4) Estadisticas");
                Console.WriteLine("5) Salir del sistema");
                Console.WriteLine(" ");
                int modulo = int.Parse(Console.ReadLine());
                Console.Clear();
                titulo();
                while (modulo != 5)
                {
                    try
                    {
                        switch (modulo)
                        {
                            case 1:
                                Console.WriteLine(" ");
                                Console.WriteLine("1) Alta de terminales");
                                Console.WriteLine("2) Alta omnibus");
                                Console.WriteLine("3) Alta de recorridos");
                                Console.WriteLine("4) Volver");
                                int op = int.Parse(Console.ReadLine());
                                while (op != 4)
                                {
                                    switch (op)
                                    {
                                        case 1:
                                            altadeterminales();
                                            break;

                                        case 2:
                                            altedeomnibus();
                                            break;

                                        case 3:
                                            altaderecorridos();
                                            break;

                                        case 4:
                                            break;

                                        default:
                                            Console.WriteLine("mal ingresado");

                                            break;
                                    }

                                    op = int.Parse(Console.ReadLine());
                                }
                                break;

                            case 2:
                                Console.Clear();
                                titulo();
                                Console.WriteLine("");
                                Console.WriteLine("1) Alta de choferes");
                                Console.WriteLine("2) Asignacion de recorridos");
                                Console.WriteLine("3) Volver");
                                int opci = int.Parse(Console.ReadLine());

                                while (opci != 3)
                                {
                                    switch (opci)
                                    {
                                        case 1:
                                            altadechoferes();
                                            break;

                                        case 2:
                                            asignarrecorridos();
                                            break;

                                        case 3:

                                            break;

                                        default:
                                            Console.WriteLine("Mal ingresado");
                                            break;
                                    }
                                    opci = int.Parse(Console.ReadLine());
                                }
                                break;

                            case 3:
                                Console.Clear();
                                titulo();
                                Console.WriteLine("");
                                Console.WriteLine("1) Alta de usuarios");
                                Console.WriteLine("2) Compra de pasajes");
                                Console.WriteLine("3) Volver");
                                int op1 = int.Parse(Console.ReadLine());

                                while (op1 != 3)
                                {
                                    switch (op1)
                                    {
                                        case 1:
                                            altadeusuarios();
                                            break;

                                        case 2:
                                            compradepasajes();
                                            break;

                                        case 3:

                                            break;

                                        default:
                                            Console.WriteLine("MAL INGRESADO");
                                            break;
                                    }
                                    op1 = int.Parse(Console.ReadLine());
                                }
                                break;

                            case 4:
                                Console.Clear();
                                titulo();
                                Console.WriteLine("");
                                Console.WriteLine("1) Consultar total de pasajes vendidos");
                                Console.WriteLine("2) Consultar usuarios");
                                Console.WriteLine("3) Consultar terminal como partida");
                                Console.WriteLine("4) Consultar terminal como arribo");
                                Console.WriteLine("5) Volver");
                                int op2 = int.Parse(Console.ReadLine());

                                while (op2 != 5)
                                {
                                    switch (op2)
                                    {
                                        case 1:
                                            totalPasajesVendidos();
                                            break;

                                        case 2:
                                            consultarUsuarios();
                                            break;

                                        case 3:
                                            consultarTerPartida();
                                            break;

                                        case 4:
                                            consultarTerArribo();
                                            break;

                                        case 5:
                                            break;

                                        default:
                                            Console.WriteLine("MAL INGRESADO");
                                            break;
                                    }
                                    op2 = int.Parse(Console.ReadLine());
                                }

                                break;

                            case 5:
                                Console.WriteLine("5) Salir del sistema");
                                break;

                            default:
                                throw new MenuException();
                        }
                        menu();
                        modulo = int.Parse(Console.ReadLine());
                    }
                    catch (MenuException)
                    {
                        menu();
                        Console.WriteLine("Mal ingresado, ingrese de 1 a 5");
                        modulo = int.Parse(Console.ReadLine());
                    }
                }

                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }

        public static void menu()
        {
            Console.Clear();
            titulo();
            Console.WriteLine("¿A que modulo desea ingresar?");
            Console.WriteLine(" ");
            Console.WriteLine("1) Armado de recorridos");
            Console.WriteLine("2) Gestion de choferes");
            Console.WriteLine("3) Ventas de pasajes");
            Console.WriteLine("4) Estadisticas");
            Console.WriteLine("5) Salir del sistema");
            Console.WriteLine(" ");
        }

        public static void submenu1()
        {
            Console.Clear();
            titulo();
            Console.WriteLine(" ");
            Console.WriteLine("1) Alta de terminales");
            Console.WriteLine("2) Alta omnibus");
            Console.WriteLine("3) Alta de recorridos");
            Console.WriteLine("4) Volver");
        }

        public static void submenu2()
        {
            Console.WriteLine("");
            Console.WriteLine("1) Alta de choferes");
            Console.WriteLine("2) Asignacion de recorridos");
            Console.WriteLine("3) Volver");
        }

        public static void submenu3()
        {
            Console.Clear();
            titulo();
            Console.WriteLine("");
            Console.WriteLine("1) Alta de usuarios");
            Console.WriteLine("2) Compra de pasajes");
            Console.WriteLine("3) Volver");
        }

        public static void submenu4()
        {
            Console.Clear();
            titulo();
            Console.WriteLine("");
            Console.WriteLine("1) Consultar total de pasajes vendidos");
            Console.WriteLine("2) Consultar usuarios");
            Console.WriteLine("3) Consultar terminal como partida");
            Console.WriteLine("4) Consultar terminal como arribo");
            Console.WriteLine("5) Volver");
        }

        public static void titulo()
        {
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("*****                               Micritos                              *****");
            Console.WriteLine("*******************************************************************************");

            Console.WriteLine(" ");
        }

        public static void totalPasajesVendidos()
        {
            Console.WriteLine("En total se han vendido " + Pasaje.cantPasajes + " pasajes");
            Console.WriteLine("Presione una tecla para continuar");
        }

        public static bool verificarChoferDia(string dia, string chofer)
        {
            foreach (Itinerario i in itinerarios)
            {
                if (i.diapublico == dia & i.choferpublico.ToString() == chofer)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool verificarDNIchofer(int dni)
        {
            foreach (Chofer c in choferes)
            {
                if (c.dnipublico == dni)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool verificarDNIusuario(int dni)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.dnipublico == dni)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool verificarOmnibusDia(string dia, string unidad)
        {
            foreach (Itinerario i in itinerarios)
            {
                if (i.diapublico == dia & i.unidadpublico.ToString() == unidad)
                {
                    return true;
                }
            }
            return false;
        }
    }

    internal class Chofer : Persona
    {
        public static int cant_c = 0;
        public int num_legajo;

        public Chofer(string nombre, string apellido, int dni, int numlegajo)
            : base(nombre, apellido, dni)
        {
            this.num_legajo = numlegajo;
        }
    }

    internal class Itinerario
    {
        private Chofer c;
        private string dia;
        private Omnibus o;
        private Recorrido r;

        public Itinerario(Chofer chofer, Omnibus unidad, Recorrido recorrido, string dia)
        {
            this.c = chofer;
            this.o = unidad;
            this.r = recorrido;
            this.dia = dia;
        }

        public Chofer choferpublico
        {
            get
            {
                return c;
            }
        }

        public string diapublico
        {
            get
            {
                return dia;
            }
        }

        public Recorrido recorridopublico
        {
            get
            {
                return r;
            }
        }

        public Omnibus unidadpublico
        {
            get
            {
                return o;
            }
        }
    }

    internal class Omnibus
    {
        public static int num_omnibus = 0;
        private int capacidad;
        private string marca;
        private int modelo;
        private string tipo;

        public Omnibus(string marca, int modelo, int capacidad, string tipo)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.capacidad = capacidad;
            this.tipo = tipo;
        }

        public string tipopublico
        {
            get
            {
                return tipo;
            }
        }

        public override string ToString()
        {
            return string.Format("[ {0}- {1}- {2}- {3}]", marca, modelo, capacidad, tipo);
        }
    }

    internal class Pasaje
    {
        public static int cantPasajes = 0;
    }

    internal class Persona
    {
        protected string apellido;
        protected int dni;
        protected string nombre;

        public Persona(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        public int dnipublico
        {
            get
            {
                return dni;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}]", nombre, apellido, dni);
        }
    }

    internal class Recorrido
    {
        public ArrayList terminales;

        public Recorrido()
        {
            terminales = new ArrayList();
        }

        public void entraTerminal(Terminal t)
        {
            terminales.Add(t);
        }

        public override string ToString()
        {
            String res = "";
            foreach (Terminal r in terminales)
            {
                res += r + "" + "-";
            }
            return res;
        }

        public bool verificarTerminal(string ter)
        {
            foreach (Terminal t in terminales)
            {
                if (t.ToString() == ter)
                {
                    return true;
                }
            }
            return false;
        }
    }

    internal class Terminal
    {
        public static int cant_Arribo = 0;
        public static int cant_Origen = 0;
        private string nombre_terminal, ciudad;

        public Terminal(string nombre_terminal, string ciudad)
        {
            this.nombre_terminal = nombre_terminal;
            this.ciudad = ciudad;
        }

        public int cant_Arribopublico
        {
            get
            {
                return cant_Arribo;
            }
            set
            {
                cant_Arribo = value;
            }
        }

        public int cant_Origenpublico
        {
            get
            {
                return cant_Origen;
            }
            set
            {
                cant_Origen = value;
            }
        }

        public string ciudadpublico
        {
            get
            {
                return ciudad;
            }
        }

        public override string ToString()
        {
            return this.ciudad;
        }
    }

    internal class Usuario : Persona
    {
        public static int cant = 0;
        public int cant_comprados = 0;
        public int num_usuario;
        private string fecha_de_nacimiento;

        public Usuario(string nombre, string apellido, int dni, string fecha_de_nacimiento, int num_usuario)
            : base(nombre, apellido, dni)
        {
            this.fecha_de_nacimiento = fecha_de_nacimiento;
            this.num_usuario = num_usuario;
        }

        public string apellidopublico
        {
            get
            {
                return apellido;
            }
        }

        public int cant_compradospublico
        {
            get
            {
                return cant_comprados;
            }
            set
            {
                cant_comprados = value;
            }
        }

        public string nombrepublico
        {
            get
            {
                return nombre;
            }
        }
    }
}