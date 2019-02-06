using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Persona
    {
        private string Name { get; set; }
        private List<Carton> _cartones = new List<Carton>();

        public IList<Carton> cartones { get { return _cartones; } }

    public Persona(string name, List<Carton> cartones)
        {
            Name = name;
            this._cartones = cartones;
        }


    }
}
