using System;

namespace EJ_2_LAB
{
    //
    // 2.- Crear un programa para una Liberia que te permita registrar el nombre del libro y su precio, usando arreglos unidimensionales, realizar lo siguiente:
    //
    //      •	Registrar libros y su precio (precio tiene que ser si o si decimal positivo no enteros ni otro tipo de dato).
    //      •	Mostrar los libros y precio registrados.
    //      •	Buscar libro por nombre.
    //      •	Modificar el libro y precio, mediante el nombre.
    //      •	Crear un menú.
    //   
    internal class Program2
    {
        public string[] Libros = new string[0];
        public double[] Precios = new double[0];


        public void Menu()
        {
            Console.WriteLine(" ------------------------------------------ ");
            Console.WriteLine("| =========== MENÚ DE OPCIONES =========== |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|             1.- Registrar                |");
            Console.WriteLine("|             2.-  Mostrar                 |");
            Console.WriteLine("|             3.-   Buscar                 |");
            Console.WriteLine("|             4.- Modificar                |");
            Console.WriteLine("|             0.-   Salir                  |");
            Console.WriteLine("|                                          |");
            Console.WriteLine(" ------------------------------------------\n");
        }
        public void RegistrarP()
        {
            double precio;
            string dec;
            while (true)
            {
                Console.Write("\nIngrese el precio: "); dec = Console.ReadLine().Trim();
                if (double.TryParse(dec, out precio) && precio > 0 && dec.Contains(".")) { break; }
                Console.WriteLine("Precio no valido. Por favor, ingrese un precio decimal valido. (ejemplo: 99.99) ");
            }
            Array.Resize(ref Precios, Precios.Length + 1);
            Precios[Precios.Length - 1] = precio;
            Console.WriteLine("¡Precio registrado con exitos! :D \n");
        }
        public void RegistrarL()
        {
            string libro;
            Console.Write("\nIngrese el libro: "); libro = Console.ReadLine().ToUpper();

            Array.Resize(ref Libros, Libros.Length + 1);
            Libros[Libros.Length - 1] = libro;
            Console.WriteLine("¡Libro registrado con exito! :D \n");
        }

        public void Mostrar()
        {
            Console.SetCursorPosition(0, 0); Console.Write("POSICION");
            Console.SetCursorPosition(15, 0); Console.Write("PRECIO");
            Console.SetCursorPosition(30, 0); Console.Write("LIBRO");
            for (int i = 0; i < Libros.Length && i < Precios.Length; i++)
            {
                Console.SetCursorPosition(0, 2 + i); Console.Write(i + 1);
                Console.SetCursorPosition(15, 2 + i); Console.Write(Precios[i]);
                Console.SetCursorPosition(30, 2 + i); Console.Write(Libros[i]);
            }
        }
        public void Buscar()
        {
            Console.Write("\nIngrese el nombre del libro a buscar: "); string buscar = Console.ReadLine().ToUpper(); Console.Clear();
            int Indice = Array.IndexOf(Libros, buscar);
            if (Indice != -1)
            {
                Console.SetCursorPosition(0, 0); Console.Write("PRECIO");
                Console.SetCursorPosition(15, 0); Console.Write("LIBRO");
                Console.SetCursorPosition(0, 2); Console.Write(Precios[Indice]);
                Console.SetCursorPosition(15, 2); Console.Write(buscar);
            }
            else { Console.WriteLine("No existe"); }
        }
        public void Modificar()
        {
            Mostrar();
            Console.Write("\n\nIngrese el nombre del libro a buscar para modificar: "); string buscar = Console.ReadLine().ToUpper(); Console.Clear();
            int Indice = Array.IndexOf(Libros, buscar);
            double Pcambio;
            string Ncambio, dec;
            if (Indice != -1)
            {
                Console.Write("\n¿Desea modificar el precio o el nombre del libro? [P/L] -> "); char opc3 = char.ToUpper(Console.ReadKey().KeyChar);
                while (opc3 != 'P' && opc3 != 'L') { Console.Write("\n[ERROR][ERROR][ERROR][ERROR][ERROR][ERROR][ERROR][ERROR][ERROR]\nIngrese nuevamente la opcion: "); opc3 = char.ToUpper(Console.ReadKey().KeyChar); }
                switch (opc3)
                {
                    case 'P':
                        while (true)
                        {
                            Console.Write("\nIngrese el nuevo precio: ");
                            dec = Console.ReadLine().Trim();

                            if (double.TryParse(dec, out Pcambio) && Pcambio > 0 && dec.Contains("."))
                            {
                                Precios[Indice] = Pcambio;
                                Console.WriteLine("¡Precio modificado con éxito! :D \n");
                                break;
                            }
                            Console.WriteLine("Precio no válido. Por favor, ingrese un precio decimal válido. (ejemplo: 99.99) ");
                        }
                        Console.WriteLine("¡Precio modificado con exito! :D \n"); break;
                    case 'L':
                        Console.Write("\nIngrese el nuevo nombre del libro a modificar: ");
                        Ncambio = Console.ReadLine().ToUpper(); Libros[Indice] = Ncambio; Console.WriteLine("¡Libro modificado con exito! :D"); break;
                }
            }
            else { Console.WriteLine("No existe"); }

        }
        public static void Main(string[] args)
        {
            byte opcion1, opcion2;
            char Regresar;
            Program2 pro = new Program2();

            do
            {
                pro.Menu();

                Console.SetCursorPosition(9, 11); Console.Write("¿Que opcion desea? -> ");
                while (!byte.TryParse(Console.ReadLine(), out opcion1) || opcion1 > 4) { Console.Write("\n[ERROR][ERROR][ERROR][ERROR][ERROR]\nIngrese nuevamente que opcion desea: "); }
                switch (opcion1)
                {
                    case 0: Environment.Exit(0); break;
                    case 1:
                        Console.Write("\n1.- Registrar Libro\n2.- Registrar Precio\nIngrese una opcion: ");
                        while (!byte.TryParse(Console.ReadLine(), out opcion2) || opcion2 > 2) { Console.Write("\n[ERROR][ERROR][ERROR][ERROR][ERROR]\nIngrese nuevamente que opcion desea: "); }
                        switch (opcion2)
                        {
                            case 1: char opc1; do { Console.Clear(); pro.RegistrarL(); Console.Write("\n¿Desea seguir registrando libros? [S/N] -> "); opc1 = char.ToUpper(Console.ReadKey().KeyChar); } while (opc1 == 'S'); break;
                            case 2: char opc2; do { Console.Clear(); pro.RegistrarP(); Console.Write("\n¿Desea seguir registrando precios? [S/N] -> "); opc2 = char.ToUpper(Console.ReadKey().KeyChar); } while (opc2 == 'S'); break;

                        }
                        break;
                    case 2: Console.Clear(); pro.Mostrar(); break;
                    case 3: Console.Clear(); pro.Buscar(); break;
                    case 4: char opcM; do { Console.Clear(); pro.Modificar(); Console.Write("\n¿Desea seguir modificando? [S/N] -> "); opcM = char.ToUpper(Console.ReadKey().KeyChar); } while (opcM == 'S'); break;

                }
                Console.Write("\t\n\n¿Desea regresar al MENÚ? [S/N] -> "); Regresar = char.ToUpper(Console.ReadKey().KeyChar); Console.Clear();
            } while (Regresar == 'S');
        }
    }
}
