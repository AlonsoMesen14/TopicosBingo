using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public void GetCrearCs(int cant)
        {
            for (int j = 0; j < cant; j++)
            {

            object[,] Cart = new object[6, 5];
            ArrayList Numeros = new ArrayList();
            Random rnd = new Random();
                int B = 0;
                int I = 0;
                int N = 0;
                int G = 0;
                int O = 0;
            Cart = FormarCarton(Cart);
                Numeros = Llenado(Numeros, Cart);
            Cart =LlenarCarton(Cart, Numeros, B, I, N, G, O);
            Cart[3, 2] = ' ';
            Carton Cartoncito = new Carton(false, Cart);
            Thread.Sleep(50); 
            this._cartones.Add(Cartoncito);
        }
        }
        public ArrayList Llenado(ArrayList Numeros, object[,] Cart) {
            Numeros.Add(Cart[1, 0]);
            Numeros.Add(Cart[1, 1]);
            Numeros.Add(Cart[1, 2]);
            Numeros.Add(Cart[1, 3]);
            Numeros.Add(Cart[1, 4]);
            return Numeros;
        }


        public object[,] FormarCarton(object[,] Cart) {
            Random rnd = new Random();
            int B, I, N, G, O = 0;
            Cart[0, 0] = 'B';
            Cart[0, 1] = 'I';
            Cart[0, 2] = 'N';
            Cart[0, 3] = 'G';
            Cart[0, 4] = 'O';
            B = rnd.Next(1, 15);
            Cart[1, 0] = B;
            I = rnd.Next(16, 30);
            Cart[1, 1] = I;
            N = rnd.Next(31, 45);
            Cart[1, 2] = N;
            G = rnd.Next(46, 60);
            Cart[1, 3] = G;
            O = rnd.Next(61, 75);
            Cart[1, 4] = O;
            return Cart;

        }
        public object[,] LlenarCarton(object[,] Cart, ArrayList Numeros,int B,int I, int N, int G, int O) {
            Random rnd = new Random();
            for (int i = 2; i <= 5; i++)
            {
                while (Numeros.Contains(B))
                {
                    B = rnd.Next(1, 15);
                }
                Numeros.Add(B);
                Cart[i, 0] = B;
                while (Numeros.Contains(I))
                {
                    I = rnd.Next(16, 30);
                }
                Numeros.Add(I);
                Cart[i, 1] = I;
                while (Numeros.Contains(N))
                {
                    N = rnd.Next(31, 45);
                }
                Numeros.Add(N);
                Cart[i, 2] = N;
                while (Numeros.Contains(G))
                {
                    G = rnd.Next(46, 60);
                }
                Numeros.Add(G);
                Cart[i, 3] = G;
                while (Numeros.Contains(O))
                {
                    O = rnd.Next(61, 75);
                }
                Numeros.Add(O);
                Cart[i, 4] = O;
            }
            return Cart;
        }

        



        public void Imprimir()
        {
            for (int i = 0; i < this._cartones.Count; i++)
            {
                this._cartones[i].Imprimir();
            }
           
        }


        public string NombreUsuario() {
            return this.Name;
        }
        public object getCarton(int i) {
            return this._cartones[i].getCartonActual();
        }
    }
}
