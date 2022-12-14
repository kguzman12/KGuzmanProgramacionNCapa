using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var paises = context.PaisGetAll().ToList();

                    result.Objects = new List<object>();

                    if (paises != null)
                    {
                        foreach (var objetoPais in paises)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = objetoPais.IdPais;
                            pais.Nombre = objetoPais.Nombre;

                            result.Objects.Add(pais);

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
                result.Ex = ex;
                result.Message = "Error al consultar los registros" + result.Ex;

                throw;
            }
            return result;

        }

    }
}
