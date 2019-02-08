using System;
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
        WcfServicio.WCFBingoClient WCFInstancia = new WcfServicio.WCFBingoClient();

        public static void Revision(int Tipo) {
            for (int i = 0; i < Program.Players.Count; i++)
            {
                for (int j  = 0; j  < Program.Players[i].cartones.Count; j ++)
                {
                    LlenarRevision(Tipo, Program.Players[i], j);
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
            if (YaGano(numerosTiene) == true){
                Console.WriteLine("Ya tenemos ganador: "+y.NombreUsuario());
                Console.WriteLine("Con el carton");
                y.cartones[posicion].Imprimir();
                Ganador = true;
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
                        break;
                    }
                }

            }
            if (numerosTiene.Count == 0)
                    {
                     return true;
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
