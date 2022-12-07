using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Departamento" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Departamento.svc o Departamento.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Departamento : IDepartamento
    {
        public SL_WCF.Result Add(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddEF(departamento);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };

        }

        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Departamento.GetAllEF();
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };

        }
    }
}
