using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IDepartamento" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IDepartamento
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Departamento departamento);

        [OperationContract]
        //[ServiceKnownType(typeof(ML.Departamento))]
        SL_WCF.Result GetAll();
        
    }
}
