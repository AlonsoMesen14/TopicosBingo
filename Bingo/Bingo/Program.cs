using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Bingo
{
    class Program
    { //Varibles Estaticas
        public static ArrayList BINGO = new ArrayList();//Arraylist que contiene los numeros que han salido
        public static List<Persona> Players= new List<Persona>();//Lista que contiene Personas y cartones
       // WcfServicio.WCFBingoClient WCFInstancia = new WcfServicio.WCFBingoClient();
        static object[,] Carton = new object[6, 5];
        public static bool EsGanador = false;
       
     

        public static void CrearPersona(string Nombre) {
            int cantCartones = 0;
            bool esNumero = true;
            string CantidadDeCartones = " ";
            do
            {
                Console.WriteLine("Digite la cantidad de cartones que desea:" + Nombre);
                CantidadDeCartones = Console.ReadLine();
                esNumero = int.TryParse(CantidadDeCartones, out cantCartones);
                if (esNumero)
                {
                    cantCartones = System.Convert.ToInt32(CantidadDeCartones);
                }
                else {
                    cantCartones = -2;
                }
                
            } while (cantCartones < 0);

            List<Carton> _cartones = new List<Carton>();
            Persona nuevo = new Persona(Nombre, _cartones);
            
      
                //_cartones.Add(nuevo.GetCrearCs());
                nuevo.GetCrearCs(cantCartones);
        
     
            Players.Add(nuevo);
            for (int i = 0; i < nuevo.cartones.Count; i++)
            {
                Console.WriteLine();
                nuevo.cartones[i].Imprimir();
            }
            //nuevo.Imprimir();
            string CantidadDeJugadores = Console.ReadLine();
        }

        public static void Jugadores() {
            int cantPlayer = 0;
            bool esNumero=true;
            string CantidadDeJugadores = " ";
            do {
                Console.WriteLine("Digite la cantidad de usuarios:");
                CantidadDeJugadores = Console.ReadLine();
                esNumero=int.TryParse(CantidadDeJugadores, out cantPlayer);
            } while (!esNumero);
            cantPlayer = System.Convert.ToInt32(CantidadDeJugadores);
            for (int i = 0; i <cantPlayer; i++)
            {
                Console.WriteLine("Digite el Nombre de Usuario:");
                string Nombre = Console.ReadLine();

                CrearPersona(Nombre);
            }

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
        
        public static void TextoMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Modos de juego");
            Console.WriteLine("1.Juego 4 Esquinas");
            Console.WriteLine("2.Juego H");
            Console.WriteLine("3.Juego X");
            Console.WriteLine("4.Juego O");
            Console.WriteLine("5.Juego Clasico (Carton LLeno)");
            Console.WriteLine("Introduzca un Numero:");
        }

        public static void Menu()
        {
            int num = 1;

            using (WcfServicio.WCFBingoClient WCFInstancia = new WcfServicio.WCFBingoClient())
            {
                var ejemplo = WCFInstancia.MENU(num);
                var mensaje = ejemplo.mensaje;
                Console.WriteLine(mensaje);
                Console.ReadLine();
            }

            Jugadores();

            int Tipo = 0;
            bool esNumero = true;
            string TipoJuego = " ";
            do
            {
                TextoMenu();
                Console.WriteLine("Seleccione el modo de juego:");
                TipoJuego = Console.ReadLine();
                esNumero = int.TryParse(TipoJuego, out Tipo);
            } while (!esNumero);
            Tipo = System.Convert.ToInt32(TipoJuego);

            for (int i = 0; i <= 70; i++)
            {
              
                NumeroSale();
                Validaciones.Revision(Tipo);
                if (EsGanador == true)
                {
                    Console.ReadLine();
                    return;
                }
            }

            Console.ReadLine();

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
