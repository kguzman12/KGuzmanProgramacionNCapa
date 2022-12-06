using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOperaciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        int Sumar(int numero1, int numero2);

        [OperationContract]
        string Saludar(string Nombre);

        [OperationContract]
        float Resta(int numero1, int numero2);

        [OperationContract]
        float Multiplicacion(int numero1, int numero2);

        [OperationContract]
        float Division(int numero1, int numero2);

    }
}
