using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Bingo
{
    class Program
    {
        //Varibles Estaticas
        static ArrayList BINGO = new ArrayList();//Arraylist que contiene los numeros que han salido

        static object[,] Carton = new object[6, 5];
        public static void Imprimir()
        {
            for (int f = 0; f < Carton.GetLength(0); f++)
            {
                for (int c = 0; c < Carton.GetLength(1); c++)
                {
                    
                    Console.Write(String.Format("{0}\t", Carton[f, c]));
                }
               
                Console.Write(Environment.NewLine + Environment.NewLine);
               
            }
            
        }

        /// <summary>
        /// Crea el carton
        /// </summary>
        public static void CrearCarton()
        {
            ArrayList Numeros = new ArrayList();
            Random rnd = new Random();
            int B, I, N, G, O = 0;
            Carton[0, 0] = 'B';
            Carton[0, 1] = 'I';
            Carton[0, 2] = 'N';
            Carton[0, 3] = 'G';
            Carton[0, 4] = 'O';
            B = rnd.Next(1, 15);
            Numeros.Add(B);
            Carton[1, 0] = B;

            I = rnd.Next(16, 30);
            Numeros.Add(I);
            Carton[1, 1] = I;

            N = rnd.Next(31, 45);
            Numeros.Add(N);
            Carton[1, 2] = N;

            G = rnd.Next(46, 60);
            Numeros.Add(G);
            Carton[1, 3] = G;

            O = rnd.Next(61, 75);
            Numeros.Add(O);
            Carton[1, 4] = O;

            for (int i = 2; i <= 5; i++)
            {

                while (Numeros.Contains(B))
                {
                    B = rnd.Next(1, 15);
                }
                Numeros.Add(B);
                Carton[i, 0] = B;
                while (Numeros.Contains(I))
                {
                    I = rnd.Next(16, 30);
                }
                Numeros.Add(I);
                Carton[i, 1] = I;
                while (Numeros.Contains(N))
                {
                    N = rnd.Next(31, 45);
                }
                Numeros.Add(N);
                Carton[i, 2] = N;
                while (Numeros.Contains(G))
                {
                    G = rnd.Next(46, 60);
                }
                Numeros.Add(G);
                Carton[i, 3] = G;
                while (Numeros.Contains(O))
                {
                    O = rnd.Next(61, 75);
                }
                Numeros.Add(O);
                Carton[i, 4] = O;
            }
            Carton[3, 2] = ' ';
        }

        /// <summary>
        /// YaSalio
        /// Este metodo determina si el nuevo numero ya habia salido
        /// </summary>
        /// <param name="numero">es el nuevo numero</param>
        /// <param name="Vector">es el arraylist BINGO</param>
        /// <returns></returns>
        public static bool YaSalio(int numero, ArrayList Vector)
        {
            for (int i = 0; i < Vector.Count; i++)
            {
                if (Vector[i].Equals(numero))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Este metodo elige el nuevo numero y determina si ya salio e imprime la posicion en la que se encuentra
        /// </summary>
        public static void NumeroSale()
        {
            Random rnd = new Random();
            int numero = 0;
            do
            {
                numero = rnd.Next(1, 75);
            } while (YaSalio(numero, BINGO) == true);
            BINGO.Add(numero);
            if (numero <= 15)
            {
                Console.WriteLine("En la columna de la B, Numero: " + numero);
            }
            else if (numero >= 16 && numero <= 30)
            {
                Console.WriteLine("En la columna de la I, Numero: " + numero);
            }
            else if (numero >= 31 && numero <= 45)
            {
                Console.WriteLine("En la columna de la N, Numero: " + numero);
            }
            else if (numero >= 46 && numero <= 60)
            {
                Console.WriteLine("En la columna de la G, Numero: " + numero);
            }
            else
            {
                Console.WriteLine("En la columna de la O, Numero: " + numero);
            }
        }

        public static void ValidarCartonClasico(object carton, ArrayList N)
        {


           
                for (int f = 0; f < Carton.GetLength(0); f++)
                {
                    for (int c = 0; c < Carton.GetLength(1); c++)

                    {
                        int dato = Carton[f, c].GetHashCode();
                        if (YaSalio(dato, N))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write("  " + Carton[f, c] + "  ");
                    }
                    Console.WriteLine();
                }

           

        }

        /// <summary>
        /// metodo para verificar la posicion de los numeros esten correctos 
        /// </summary>
        /// <param name="x">Posicion en el Carton</param>
        /// <param name="y">Posicion en el Carton</param>
        /// <param name="type">Tipo del modo de juego</param>
        /// <returns>retorna true si los numeros estan en la posicion correcta </returns>
        public static bool VerificarCarton(int x, int y, int type)
        {
            switch (type)
            {
                //4 Esquinas
                case 1:
                    if (Carton[x, y].Equals(Carton[1, 0])
                        || Carton[x, y].Equals(Carton[1, 4])
                        || Carton[x, y].Equals(Carton[5, 0])
                        || Carton[x, y].Equals(Carton[5, 4]))
                    {
                        return true;
                    }
                    return false;
                case 2:
                    // X
                    if (Carton[x, y].Equals(Carton[1, 0])
                         || Carton[x, y].Equals(Carton[2, 1])
                         || Carton[x, y].Equals(Carton[4, 3])
                         || Carton[x, y].Equals(Carton[5, 4])
                         || Carton[x, y].Equals(Carton[1, 4])
                         || Carton[x, y].Equals(Carton[2, 3])
                         || Carton[x, y].Equals(Carton[4, 1])
                         || Carton[x, y].Equals(Carton[5, 0]))
                    {
                        return true;
                    }
                    return false;

                case 3:
                    //H
                    if (Carton[x, y].Equals(Carton[1, 0])
                        || Carton[x, y].Equals(Carton[2, 0])
                        || Carton[x, y].Equals(Carton[3, 0])
                        || Carton[x, y].Equals(Carton[4, 0])
                        || Carton[x, y].Equals(Carton[5, 0])
                        || Carton[x, y].Equals(Carton[3, 1])
                        || Carton[x, y].Equals(Carton[3, 3])
                        || Carton[x, y].Equals(Carton[3, 4])
                        || Carton[x, y].Equals(Carton[1, 4])
                        || Carton[x, y].Equals(Carton[2, 4])
                        || Carton[x, y].Equals(Carton[4, 4])
                        || Carton[x, y].Equals(Carton[5, 4]))
                    {
                        return true;
                    }
                    return false;

                case 4:
                    //O
                    if (Carton[x, y].Equals(Carton[2, 0])
                        || Carton[x, y].Equals(Carton[3, 0])
                        || Carton[x, y].Equals(Carton[4, 0])
                        || Carton[x, y].Equals(Carton[5, 1])
                        || Carton[x, y].Equals(Carton[5, 2])
                        || Carton[x, y].Equals(Carton[5, 3])
                        || Carton[x, y].Equals(Carton[1, 1])
                        || Carton[x, y].Equals(Carton[1, 2])
                        || Carton[x, y].Equals(Carton[1, 3])
                        || Carton[x, y].Equals(Carton[2, 4])
                        || Carton[x, y].Equals(Carton[3, 4])
                        || Carton[x, y].Equals(Carton[4, 4]))
                    {
                        return true;
                    }
                    return false;

            
                default:
                    return false;
            }

            
        }

        public static bool MenuCarton(int x, int y, int opcion)
        {


            switch (opcion)
            {
                case 1:
                    if (VerificarCarton(x, y, 1) == true)
                    {
                        return true;
                    }
                    return false;

                case 2:
                    if (VerificarCarton(x, y, 2) == true)
                    {
                        return true;
                    }
                    return false;

                case 3:
                    if (VerificarCarton(x, y, 3) == true)
                    {
                        return true;
                    }
                    return false;

                case 4:
                    if (VerificarCarton(x, y, 4) == true)
                    {
                        return true;
                    }
                    return false;

                default:
                    return false;
            }
        }

        public static void ValidarCarton(object carton, ArrayList N, int Tipo)
        {
            for (int f = 0; f < Carton.GetLength(0); f++)
            {
                for (int c = 0; c < Carton.GetLength(1); c++)
                {
                    int d = Carton[f, c].GetHashCode();
                    if (YaSalio(d, N) == true && MenuCarton(f, c, Tipo) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(String.Format("{0}\t", Carton[f, c]));
                }

                Console.Write(Environment.NewLine + Environment.NewLine);
               
            }
        }
        


        public static void TextoMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bienvenido al BINGO!");
            Console.WriteLine("1.Juego Clasico (Carton LLeno)");
            Console.WriteLine("2.Juego 4 Esquinas");
            Console.WriteLine("3.Juego X");
            Console.WriteLine("4.Juego H");
            Console.WriteLine("5.Juego O");
            Console.WriteLine("Introduzca un Numero:");
        }

        public static void Menu()
        {
            
            int menu = 0;
            do
            {
                TextoMenu();
                BINGO.Clear();
                Console.WriteLine("Introduzca un Numero");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                { 
                    
                    case 1:
                        CrearCarton();
                        Imprimir();
                        for (int i = 0; i < 30; i++)
                        {
                            NumeroSale();
                        }
                        ValidarCartonClasico(Carton, BINGO);
                        Console.ReadKey();
                        break;

                    case 2:
                        CrearCarton();
                        Imprimir();
                        for (int i = 0; i < 70; i++)
                        {
                            NumeroSale();
                        }
                        ValidarCarton(Carton, BINGO, 1);
                        Console.ReadKey();
                        break;

                    case 3:
                        CrearCarton();
                        Imprimir();
                        for (int i = 0; i < 70; i++)
                        {
                            NumeroSale();
                        }
                        ValidarCarton(Carton, BINGO, 2);
                        Console.ReadKey();
                        break;

                    case 4:
                        CrearCarton();
                        Imprimir();
                        for (int i = 0; i < 70; i++)
                        {
                            NumeroSale();
                        }
                        ValidarCarton(Carton, BINGO, 3);
                        Console.ReadKey();
                        break;

                    case 5:
                        CrearCarton();
                        Imprimir();
                        for (int i = 0; i < 70; i++)
                        {
                            NumeroSale();
                        }
                        ValidarCarton(Carton, BINGO, 4);
                        Console.ReadKey();
                        break;

                    case 6:
                        
                        break;

                    case 7:

                        break;

                    default:
                        break;
                }

            } while (menu != 7);
        }
        static void Main(string[] args)
        {
            Menu();
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
