﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Validaciones
    {
        static bool Ganador = false;
       

        public static void Revision(int Tipo) {
            for (int i = 0; i < Program.Players.Count; i++)
            {
                for (int j  = 0; j  < Program.Players[i].cartones.Count; j ++)
                {
                    LlenarRevision(Tipo, Program.Players[i], j);
                    
                }
                if(Ganador == true)
                {
                    return;
                }
            }
            if (Ganador==false)
            {
                Console.WriteLine("No hubo ganadores");
            }

        }



        public static void LlenarRevision(int tipo, Persona y, int posicion)
        {
            ArrayList numerosTiene = new ArrayList();
            object [,]carton = y.cartones[posicion].getCartonActual();
            switch (tipo)
            {
                case 1://cuatro esquinas
                    numerosTiene = CuatroEsquina(numerosTiene,carton);
                    break;
                case 2://letra h
                    numerosTiene = LetraH(numerosTiene, carton);
                    break;
                case 3:// letra x
                    numerosTiene = LetraX(numerosTiene, carton);
                    break;
                case 4://letra o
                    numerosTiene = LetraO(numerosTiene, carton);
                    break;
                case 5://carton lleno
                    numerosTiene = CartonLleno(numerosTiene, carton);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine(y.NombreUsuario());
            ImprimirCarton(carton, numerosTiene);
            Console.ForegroundColor = ConsoleColor.White;

            if (YaGano(numerosTiene) == true){
                Console.WriteLine();
                Console.WriteLine("Ya tenemos ganador: "+y.NombreUsuario());
                Console.WriteLine("Con el carton");
                Console.WriteLine();
                y.cartones[posicion].Imprimir();
                Program.EsGanador = true;
                Ganador = true;
                return;
            }
            
        }
    
        public static bool YaGano(ArrayList numerosTiene)
        {
            
            for (int i = 0; i < Program.BINGO.Count; i++)
            {
                for (int j = 0; j < numerosTiene.Count; j++)
                {
                    if (numerosTiene[j].Equals(Program.BINGO[i]))
                    {

                        numerosTiene.RemoveAt(j);
                    }
                    if (numerosTiene.Count == 0)
                    {
                        Ganador = true;
                        Program.EsGanador = true;
                        return true;
                    }
                }
                
            }

            if (numerosTiene.Count == 0)
                    {
                     Program.EsGanador = true;
                     return true;
                    }
                    return false;
        }

        public static void ImprimirCarton(object[,] carton, ArrayList numerosTiene)
        {

                Console.WriteLine();
                for (int f = 0; f < carton.GetLength(0); f++)
                {
                    for (int c = 0; c < carton.GetLength(1); c++)
                    {
                   
                        for (int j = 0; j < numerosTiene.Count; j++)
                        {
                            if (carton[f,c]==numerosTiene[j] && RevisarBingo(numerosTiene,j)==true)
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        
                        }
                       
                     
                        Console.Write(String.Format("{0}\t", carton[f, c]));

                    }

                    Console.Write(Environment.NewLine + Environment.NewLine);

                }
            
           
        }

       public static bool RevisarBingo(ArrayList n,int x)
        {
            for (int i = 0; i < Program.BINGO.Count; i++)
            {
                if (n[x].Equals(Program.BINGO[i]))
                {
                    return true;
                }
            }

            return false;
        }


        public static ArrayList CuatroEsquina(ArrayList numerosTiene, object[,] carton) {
            numerosTiene.Add(carton[1, 0]);
            numerosTiene.Add(carton[1, 4]);
            numerosTiene.Add(carton[5, 0]);
            numerosTiene.Add(carton[5, 4]);
            return numerosTiene;
        }
        public static ArrayList LetraH(ArrayList numerosTiene, object[,] carton)
        {
            for (int i = 1; i <= 5; i++)
            {
                numerosTiene.Add(carton[i, 0]);
                numerosTiene.Add(carton[i, 4]);
            }
            numerosTiene.Add(carton[3, 1]);
            numerosTiene.Add(carton[3, 3]);

            return numerosTiene;
        }
        public static ArrayList LetraX(ArrayList numerosTiene, object[,] carton)
        {
            numerosTiene.Add(carton[1, 0]);
            numerosTiene.Add(carton[2, 1]);
            numerosTiene.Add(carton[4, 3]);
            numerosTiene.Add(carton[5, 4]);
            numerosTiene.Add(carton[1, 4]);
            numerosTiene.Add(carton[2, 3]);
            numerosTiene.Add(carton[4, 1]);
            numerosTiene.Add(carton[5, 0]);
            return numerosTiene;
        }
        public static ArrayList LetraO(ArrayList numerosTiene, object[,] carton)
        {
            for (int i = 0; i < 5; i++)
            {
                numerosTiene.Add(carton[1, i]);
                numerosTiene.Add(carton[5, i]);
            }

            for (int i = 2; i < 5; i++)
            {
                numerosTiene.Add(carton[i, 0]);
                numerosTiene.Add(carton[i, 4]);
            }
            return numerosTiene;
        }
        public static ArrayList CartonLleno(ArrayList numerosTiene, object[,] carton)
        {
            for (int f = 0; f < carton.GetLength(0); f++)
            {
                for (int c = 0; c < carton.GetLength(1); c++)
                {
                    numerosTiene.Add(carton[f, c]);
                }
            }
            numerosTiene.RemoveAt(12);
            return numerosTiene;
        }








    }
}
