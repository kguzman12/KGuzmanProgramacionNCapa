using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result ColoniaGetByIdMunicipio(int idMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var colonias = context.ColoniaGetByIdMunicipio(idMunicipio).ToList();

                    result.Objects = new List<object>();

                    if (colonias != null)
                    {
                        foreach (var objColonia in colonias)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.IdColonia = objColonia.IdColonia;
                            colonia.Nombre = objColonia.Nombre;

                            colonia.Municipio = new ML.Municipio();
                            colonia.Municipio.IdMunicipio = idMunicipio;

                            result.Objects.Add(colonia);

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
