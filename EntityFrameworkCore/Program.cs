using EntityFrameworkCore.Ejercicio;
using System;

namespace EntityFrameworkCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            EjemplosMenu();
        }
        private static void EjemplosMenu()
        {
           
            string aux = string.Empty;
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" Base de Datos");
                Console.WriteLine("1- Guardar Estudiante en Base de Dato.");
                Console.WriteLine("2- Hacer Query.");
                Console.WriteLine("3- Consultar Estudiante");
                Console.WriteLine("3- Hacer doble Query.");
                Console.WriteLine("4- Hacer query usando SQL.");
                Console.WriteLine("5- Actualizar  entidad.");
                Console.WriteLine("6- Borrar data de una entidad.");
                Console.WriteLine("7- Actualizar data  en un escenario desconectado.");
                Console.WriteLine("8- Borrar data  en un escenario desconectado.");
                Console.WriteLine("9- Hacer ChangeTracker.");
                Console.WriteLine("10- Salir.");
                Console.WriteLine("Opción:");

                aux = Console.ReadLine();
                
                Console.Clear();

                switch (opc)
                {
                    case 1:
                        {
                            Tutorial.GuardarStudent();
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        {
                            Tutorial.SimpleQuery();
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        {
                            Tutorial.ConsultaStudents();
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        {
                            Tutorial.QuerryUsingSql();
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        {
                            Tutorial.UpdatingData();
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        {
                            Tutorial.DeletingData();
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        {
                            Tutorial.UpdatingOnDisconnectedScenario();
                            Console.ReadKey();
                        }
                        break;
                    case 8:
                        {
                            Tutorial.DeletingOnDisconnectedScenario();
                            Console.ReadKey();
                        }
                        break;
                    case 9:
                        {
                            Tutorial.ChangeTracker();
                            Console.ReadKey();
                        }
                        break;
                  
                    
                    case 10:
                        break;
                }
            }
            while (opc != 10);
        }

        

    }
}
