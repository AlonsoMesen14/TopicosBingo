using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfBingo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCFBingo : IWCFBingo
    {

        public Menu MENU(int opcion)
        {
            
            if(opcion == 1)
            {
                
                return new Menu() { mensaje = "Bienvenido al Bingo \n\n" +
                                                                "Instrucciones: \n" +
                                                                "1) Debe elegir la cantidad de jugadores por partida \n" +
                                                                "2) Debe indicar el nombre de cada jugador \n" +
                                                                "3) Debe indicar la cantidad de cartones por jugador \n" +
                                                                "4) Debe seleccionar el modo de juego \n\n"
                };

             
            }
            else
            {
                throw new Exception("Error");
            }

            throw new Exception("Error");
        }

        public ReglasDeJuego ReglasDeJuego()
        {
            return new ReglasDeJuego() { MensajeInstrucciones = "Bienvenido al Bingo \n" +
                                                                "Instrucciones: \n" +
                                                                "1) Debe elegir la cantidad de jugadores por partida \n" +
                                                                "2) Debe indicar el nombre de cada jugador \n" +
                                                                "3) Debe indicar la cantidad de cartones por jugador \n" +
                                                                "4) Debe seleccionar el modo de juego \n\n" };
            throw new Exception("Error");
        }
    }
}
