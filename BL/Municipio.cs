using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result MunicipioGetByIdEstado(int idEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var municipios = context.MunicipioGetByIdEstado(idEstado).ToList();

                    result.Objects = new List<object>();

                    if (municipios != null)
                    {
                        foreach (var objMunicipio in municipios)
                        {
                            ML.Municipio municipio = new ML.Municipio();
                            municipio.IdMunicipio = objMunicipio.IdMunicipio;
                            municipio.Nombre = objMunicipio.Nombre;

                            municipio.Estado = new ML.Estado();
                            municipio.Estado.IdEstado = idEstado;

                            result.Objects.Add(municipio);

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
