using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result EstadoGetByIdPais(int idPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var estados = context.EstadoGetByIdPais(idPais).ToList();

                    result.Objects = new List<object>();

                    if (estados != null)
                    {
                        foreach (var objEstado in estados)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = objEstado.IdEstado;
                            estado.Nombre = objEstado.Nombre;

                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = idPais;

                            result.Objects.Add(estado);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    
    }
}
