using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var areas = context.AreaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (areas != null)
                    {
                        foreach (var objetoArea in areas)
                        {
                            ML.Area area = new ML.Area();
                            area.IdArea = (byte)objetoArea.IdArea;
                            area.Nombre = objetoArea.Nombre;

                            result.Objects.Add(area);

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
