using System;

namespace Practica_4_Base_de_datos
{
    class Principal
    {
        bool salir;

        Principal()
        {
        }

        public void menu()
        {
            Contacto contacto = new Contacto();
            int opcion;
            string id, nombre, telefono;
            Console.Write("1.- Ver todos los contactos"+
                "\n2.- Agregar contacto"+
                "\n3.- Editar contacto"+
                "\n4.- Eliminar contacto"+
                "\n5.- Salir"+
                "\n\nElegir la opcion: ");
            try
            {
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1: contacto.mostrarTodos();
                        break;
                    case 2: Console.Write("Dame el nombre: ");
                        nombre = Console.ReadLine();
                        Console.Write("Dame el telefono: ");
                        telefono = Console.ReadLine();
                        contacto.insertarRegistroNuevo(nombre, telefono);
                        break;
                    case 3: Console.Write("Dame el id: ");
                        id = Console.ReadLine();
                        if (contacto.consultaId(id).Length > 0)
                        {
                            Console.Write("Dame el nombre: ");
                            nombre = Console.ReadLine();
                            Console.Write("Dame el telefono: ");
                            telefono = Console.ReadLine();
                            contacto.editarRegistro(id, nombre, telefono);
                        }
                        else
                            Console.WriteLine("El id no existe");
                        break;
                    case 4: Console.Write("Dame el id: ");
                        id = Console.ReadLine();
                        if (contacto.consultaId(id).Length > 0)
                        {
                            Console.WriteLine("Contacto eliminado");
                            contacto.eliminarRegistroPorId(id);
                        }
                        else
                            Console.WriteLine("El id no existe");
                        break;
                    case 5: Console.WriteLine("Bye");
                        salir = true;
                        break;
                    default: Console.WriteLine("Opcion invalida");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Debe ingresar un entero");
            }

        }


        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Agenda";
            Console.SetWindowSize(50, 30);
            Principal principal = new Principal();
            do
            {
                Console.Clear();
                principal.menu();
                Console.ReadKey();
            } while (!principal.salir);
        }
    }
}