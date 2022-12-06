using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Operaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Operaciones.svc o Operaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Operaciones : IOperaciones
    {
        public int Sumar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public string Saludar(string Nombre)
        {
            return "Hola " + Nombre;
        }

        public float Resta(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public float Multiplicacion(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public float Division(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

    }
}
