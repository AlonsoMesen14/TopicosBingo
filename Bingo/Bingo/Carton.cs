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

        public Carton(bool haGanado, object[,] carton)
        {
            this.haGanado = haGanado;
            this.carton = carton;
        }


    }
}
