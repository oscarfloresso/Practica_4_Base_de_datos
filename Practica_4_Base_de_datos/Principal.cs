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
            int opcion;
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
                    case 1: 
                        break;
                    case 2: 
                        break;
                    case 3: 
                        break;
                    case 4: 
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
