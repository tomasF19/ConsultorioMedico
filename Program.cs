using System;
using System.Collections;

namespace Clinica
{
    class Program
    {
        public static string menu() {
            Console.WriteLine("Ingrese el número de la opción que desea realizar: ");
            Console.WriteLine("1- Dar un turno");
            Console.WriteLine("2- Actualizar el diagnostico de un paciente");
            Console.WriteLine("3- Cancelar un turno");
            Console.WriteLine("4- Ver listado de los turnos dados");
            Console.WriteLine("5- Atender a un paciente");
            Console.WriteLine("6- Ver lista de obras sociales de los pacientes");
            Console.WriteLine("7- Ver Lista de pacientes");
            Console.WriteLine("8- Ver último diagnostico de un paciente");
            Console.WriteLine("9- Salir");
            string respuestaopcion = Console.ReadLine();
            return respuestaopcion;
        }

        /***********************************************************************************/
        public static void darTurno(Medico m1) {
            bool verificador = true;
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    if (m1.totalTurnosOcupados() == 9)
                    {
                        throw new Noquedanturnos();
                    }
                }
            }
            catch (Noquedanturnos) { return; }

            Console.WriteLine("Por favor ingrese el horario del turno: ");
            string horario = Console.ReadLine();
            for (int i = 0; i < 9; i++)
            {
                if ((m1.Turnosdias[i].Hora==horario)&&(m1.Turnosdias[i].Nombre==" "))
                {
                    Console.WriteLine("Ingrese el nombre del paciente: ");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el dni del paciente: ");
                    int dni = int.Parse(Console.ReadLine());
                    for (int k = 0; k < 9; k++)
                    {
                        if (m1.Turnosdias[k].Dnipac==dni)
                        {
                            Console.WriteLine("Este numero de DNI ya tiene turno");
                            return;
                        }

                    }

                    m1.darTurno(horario, nombre, dni);
                    verificador = false;
                    break;
                }

                if ((m1.Turnosdias[i].Hora==horario)&&(m1.Turnosdias[i].Nombre!=" "))
                {
                    Console.WriteLine("Este turno ya se encuentra ocupado, consulte la lista de turnos");
                    verificador = false;
                }

            }

            if (verificador)
            {
                Console.WriteLine("Ingresó el horario en formato incorrecto");
            }
        }


        /***********************************************************************************/

        public static void actualizaDiagnostico(Medico m1) {
            Console.WriteLine("Ingrese el dni del paciente a actualizar su diagnostico: ");
            try
            {
                int dni = int.Parse(Console.ReadLine());
                bool paciente = false;
                foreach (Paciente item in m1.Pacientes) 
                {
                    if (item.Dni==dni) 
                    {
                        Console.WriteLine("Ingrese el nuevo diagnostico del paciente: ");
                        item.agregarDiag(Console.ReadLine());
                        paciente = true;
                    }
                }
                if (!paciente)
                {
                    Console.WriteLine("No se encuentra el paciente");
                }
                else
                {
                    Console.WriteLine("Diagnostico del paciente actualizado!");
                }

            }
            catch (FormatException)
            {

                Console.WriteLine("Entrada incorrecta");
            }
        
        }


        /***********************************************************************************/

        public static void cancelarunTurno(Medico m1) {
            Console.WriteLine("Ingrese el horario del turno que desea cancelar: ");
            string opcion = Console.ReadLine();
            bool existeturno = false;
            for (int i = 0; i < 9; i++)
            {
                if (m1.Turnosdias[i].Hora==opcion) 
                {
                    if (m1.Turnosdias[i].Nombre!="atendido" )
                    {
                        m1.cancelarTurno(opcion);
                        existeturno = true;
                    }
                    else
                    {
                        Console.WriteLine("Este turno ya se atendió");
                        existeturno = true;
                    }

                }

            }
            if (!existeturno) 
            {
                Console.WriteLine("Entrada incorrecta");
            }


        }


        //*************************************************************************************

        public static void listaTurnosDados(Medico m1) {
            Console.WriteLine("TURNOS EN EL DIA");
            Console.WriteLine("{0,10}{1,10}{2,12}", "Turno"," Nombre"," dni ");
            foreach (Turno item in m1.listaTurnos())
            {
                Console.WriteLine("{0,10}{1,10}{2,12}", item.Hora, item.Nombre, item.Dnipac);
            }
            Console.WriteLine("------------------------");
        }

        public static void atenderPaciente(Medico m1)
        {
            Console.WriteLine("Ingresa el horario en el turno que se va a atender: ");
            string opcion = Console.ReadLine();
            bool existeturno = false;
            int dni = 0;
            string nombre;
            for (int i = 0; i < 9; i++)
            {
                if ((m1.Turnosdias[i].Hora==opcion)&&(m1.Turnosdias[i].Nombre!=" ")&&(m1.Turnosdias[i].Nombre!="atendido"))
                {
                    existeturno = true;
                    dni = m1.Turnosdias[i].Dnipac;
                    nombre = m1.Turnosdias[i].Nombre = "atendido";
                    Paciente pp;
                    string espaciente = m1.corroborarPaciente(pp = new Paciente(dni));
                    m1.Turnosdias[i].Dnipac = 0;
                    m1.Turnosdias[i].Nombre = "atendido";

                    if (espaciente=="v")
                    {
                        Console.WriteLine("El paciente se encuentra en la lista");
                        Console.WriteLine("Ingrese el diagnostico del paciente");
                        foreach (Paciente item in m1.Pacientes)
                        {
                            if (item.Dni==dni)
                            {
                                item.agregarDiag(Console.ReadLine());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Paciente nuevo que agregar a la lista");
                        int numafiliado;
                        Console.WriteLine("Ingrese apellido");
                        string ape = Console.ReadLine();
                        Console.WriteLine("Ingrese obra social");
                        string social = Console.ReadLine();
                        Console.WriteLine("Ingrese numero afiliado a obra social");
                        try
                        {
                            numafiliado = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Entrada en numero afiliado con error");
                            break;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("El formato que se ingreso el numero afiliado es erroneo");
                            break;
                        }

                        Paciente nuevo = new Paciente(nombre, ape, social, dni, numafiliado);

                        Console.WriteLine("Ingrese el diagnostico: ");
                        nuevo.agregarDiag(Console.ReadLine());
                        m1.agregarPac(nuevo);
                        Console.WriteLine("El paciente fue agregado exitosamente");
                    }
                
                }
                if ((m1.Turnosdias[i].Hora==opcion)&&(m1.Turnosdias[i].Nombre==" "))
                {
                    Console.WriteLine("El turno está libre");
                    existeturno = true;
                }
            }
            if (!existeturno)
            {
                Console.WriteLine("ERROR");
            }
        }

        //*************************************************************************************

        public static void listaObrasSociales(Medico m1)
        {
            Console.WriteLine("LISTA DE LAS OBRAS SOCIALES DE PACIENTES REGISTRADOS");
            ArrayList diagnostico = new ArrayList();
            foreach (Paciente item in m1.Pacientes)
            {
                if (diagnostico.IndexOf(item.Obrasocial)== -1)
                {
                    diagnostico.Add(item.Obrasocial);
                }
            }
            diagnostico.Sort();
            foreach (string  item in diagnostico)
            {
                Console.WriteLine("- "+item.ToUpper());
            }
            Console.WriteLine("-------------------------------------");
        }

        public static void listaDePacientes(Medico m1) {
            Console.WriteLine("LISTA DE PACIENTES");
            Console.WriteLine("{0,15}{1,10}{2,12}{3,15}{4,10}", "NOMBRE", "APELLIDO", "DNI", "OBRASOCIAL", "  Nº AFILIADO");
            foreach (Paciente p in m1.todosPac())
            {
                Console.WriteLine("{0,15}{1,10}{2,12}{3,15}{4,10}", p.Nombre, p.Ape, p.Dni, p.Obrasocial, p.Nroafiliado);
            }
            Console.WriteLine("---------------------------------------------------------------");     
        
        }

        //*************************************************************************************

        public static void ultimoDiagnostico(Medico m1) {
            Console.WriteLine("Ingresa el dni del paciente que desea consultar: ");
            bool figura = false;
            try
            {
                int opcion = int.Parse(Console.ReadLine());
                foreach (Paciente p in m1.Pacientes)
                {
                    if (p.Dni==opcion)
                    {
                        if (p.Diagnosticos.Count!=0)
                        {
                            Console.WriteLine("El ultimo diagnostico: ");
                            Console.WriteLine("- " + p.Diagnosticos[(p.Diagnosticos.Count) - 1]);
                            figura = true;
                        }
                        else
                        {
                           
                                Console.WriteLine("No posee ningún diagnóstico");
                                figura = true;
                        }
                    }
                }
                if (!figura) 
                    Console.WriteLine("El dni ingresado no se encuentra en la lista de paciente del médico");

            }
            catch (FormatException)
            {
                Console.WriteLine("DNI ingresado de forma erronea");
            }
            catch (OverflowException)
            {
                Console.WriteLine("DNI ingresado de forma erronea");
               
            }
            
            
            
            
        }

        //*************************************************************************************

        static void Main(string[] args)
        {
            string respuesta;
            Medico m1 = new Medico("Tomas","Fuentes", 40123876, 1234);

            Paciente p1 = new Paciente("Matias", "Gomez", "pami", 234456, 12938123);
            Paciente p2 = new Paciente("Alan", "Quiñones", "osde", 5674676, 567678);
            Paciente p3 = new Paciente("Maria", "Gonzales", "ioma", 234345, 1765323);
            Paciente p4 = new Paciente("Maira", "Mendez", "pami", 274556, 89063);
            Paciente p5 = new Paciente("Lucas", "Guiterrez", "pami", 92467, 3457123);

            m1.agregarPac(p1);
            m1.agregarPac(p2);
            m1.agregarPac(p3);
            m1.agregarPac(p4);
            m1.agregarPac(p5);

            m1.darTurno("08:00", "Matias", 234456);
            m1.darTurno("08:30", "Maria", 234345);
            m1.darTurno("09:00", "Lucas", 92467);
            m1.darTurno("09:30", "Alan", 5674676);
            m1.darTurno("10:00", "Maira", 274556);

            p1.agregarDiag("Fiebre");
            p2.agregarDiag("Dolor de espalda");
            p3.agregarDiag("Resfrío");


            do
            {
                string m = menu();
                switch (m)
                {
                    case "1":
                        Console.Clear(); 
                        listaTurnosDados(m1); 
                        darTurno(m1);
                        break;
                    case "2":
                        Console.Clear();
                        listaDePacientes( m1);
                        actualizaDiagnostico( m1);
                        break;
                    case "3":
                        Console.Clear();
                        listaTurnosDados(m1);
                        cancelarunTurno(m1);
                        break;
                    case "4":
                        Console.Clear();
                        listaTurnosDados(m1);
                        break;
                    case "5":
                        Console.Clear();
                        listaTurnosDados(m1);
                        atenderPaciente(m1);
                        break;
                    case "6":
                        Console.Clear();
                        listaObrasSociales(m1);
                        break;
                    case "7":
                        Console.Clear();
                        listaDePacientes(m1);
                        break;
                    case "8":
                        Console.Clear();
                        listaDePacientes(m1);
                        ultimoDiagnostico(m1);
                        break;
                    case "9":
                        Console.Clear();
                        Console.WriteLine("Que tenga buenos días!");
                        respuesta = "no";
                        continue;
                    default:
                        Console.WriteLine("Número ingresado no valido");
                        break;
                   
                }
                Console.WriteLine("Desea realizar otra opción?: ");
                respuesta = Console.ReadLine();
                Console.Clear();
            } while (respuesta=="si");





        }
    }
}
