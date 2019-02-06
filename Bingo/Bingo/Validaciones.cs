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
        WcfServicio.WCFBingoClient WCFInstancia = new WcfServicio.WCFBingoClient();
        public void ValidacionCartonLLeno()
        {

        }

        public void Validar4esquinas()
        {

        }

        public static void Revision(int Tipo) {
            for (int i = 0; i < Program.Players.Count; i++)
            {
                for (int j  = 0; j  < Program.Players[i].cartones.Count; j ++)
                {
                    LlenarRevision(Tipo, Program.Players[i], j);
                }
            }


        }



        public static void LlenarRevision(int tipo, Persona y, int posicion)
        {

            
            ArrayList numerosTiene = new ArrayList();
            object [,]carton = y.cartones[posicion].getCartonActual();
            switch (tipo)
            {

                case 1://cuatro esquinas
                    numerosTiene.Add(carton[1,0]);
                    numerosTiene.Add(carton[1, 4]);
                    numerosTiene.Add(carton[5, 0]);
                    numerosTiene.Add(carton[5, 4]);
                    break;
                case 2://letra h
                    for (int i = 1; i <= 5; i++)
                    {
                        numerosTiene.Add(carton[i, 0]);
                        numerosTiene.Add(carton[i, 4]);
                    }
                    numerosTiene.Add(carton[3, 1]);
                    numerosTiene.Add(carton[3, 3]);

                    break;
                case 3:// letra x
                    numerosTiene.Add(carton[1, 0]);
                    numerosTiene.Add(carton[2, 1]);
                    numerosTiene.Add(carton[4, 3]);
                    numerosTiene.Add(carton[5, 4]);
                    numerosTiene.Add(carton[1, 4]);
                    numerosTiene.Add(carton[2, 3]);
                    numerosTiene.Add(carton[4, 1]);
                    numerosTiene.Add(carton[5, 0]);
                    break;
                case 4://letra o
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

                    break;
                case 5://carton lleno
                    for (int f = 0; f < carton.GetLength(0); f++)
                    {
                        for (int c = 0; c < carton.GetLength(1); c++)
                        {
                            numerosTiene.Add(carton[f, c]);
                        }
                    }
                    numerosTiene.RemoveAt(12);
                    break;



            }
            numerosTiene.ToString();
            if (YaGano(numerosTiene) == true){
                Console.WriteLine("Ya tenemos ganador");
                return;
            }
            else
            {
                Console.WriteLine("No hay ganador");
            }

        }

    
        public static bool YaGano(ArrayList numerosTiene)
        {

            for (int i = 0; i < Program.BINGO.Count; i++)
            {
                for (int j = 0; j < numerosTiene.Count; j++)
                {
                    if (numerosTiene[j] == Program.BINGO[i])
                    {
                        numerosTiene.RemoveAt(j);
                        //j++;
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















    }
}
