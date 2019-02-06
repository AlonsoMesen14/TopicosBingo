using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Bingo
{
    class Carton
    {
        private bool haGanado { get; set; }
        private object [,] carton { get; set; }

        WcfServicio.WCFBingoClient WCFInstancia = new WcfServicio.WCFBingoClient();

        public Carton(bool haGanado, object[,] carton)
        {
            this.haGanado = haGanado;
            this.carton = carton;
        }
        public object[,] getCartonActual()
        {
            return this.carton;
        }
        public void Imprimir()
        {
            for (int f = 0; f < this.carton.GetLength(0); f++)
            {
                for (int c = 0; c < this.carton.GetLength(1); c++)
                {

                    Console.Write(String.Format("{0}\t", this.carton[f, c]));
                }

                Console.Write(Environment.NewLine + Environment.NewLine);

            }
        }
   
    }
}
