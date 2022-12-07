using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    int query = contex.DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);

                    if (query > 0)
                    {
                        result.Message = "El departamento se agrego correctamente";
                    }
                }
                result.Correct = true;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var query = contex.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea);

                    if (query > 0)
                    {
                        result.Message = "El departamento se modifico correctamente";
                    }
                }
                result.Correct = true;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }
        
        public static ML.Result DeleteEF(int idDepartamento)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    int query = contex.DepartamentoDelete(idDepartamento);

                    if (query >= 1)
                    {
                        result.Message = "El departamento se elimino correctamente";
                    }
                }
                result.Correct = true;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var departamentos = contex.DepartamentoGetAll();

                    result.Objects = new List<object>();

                    if (departamentos != null)
                    {
                        foreach (var objeto in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = objeto.IdDepartamento;
                            departamento.Nombre = objeto.Nombre;

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = (byte)objeto.IdArea;

                            result.Objects.Add(departamento);
                        }
                    }

                }
                result.Correct = true;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int idDepartamento)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var tableDepartamento = contex.DepartamentoGetById(idDepartamento).FirstOrDefault();
                    
                    result.Objects = new List<object>();

                    if (tableDepartamento != null)
                    {
                        ML.Departamento departamento = new ML.Departamento();

                        departamento.IdDepartamento = tableDepartamento.IdDepartamento;
                        departamento.Nombre = tableDepartamento.Nombre;

                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = (byte)tableDepartamento.IdArea;
                        departamento.Area.Nombre = tableDepartamento.Nombre;

                        result.Object = departamento;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                result.Correct = true;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }
            return result;
        }



        public static ML.Result DepartamentoGetByIdArea(int idArea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var departamentos = context.DepartamentoGetByIdArea(idArea).ToList();

                    result.Objects = new List<object>();

                    if (departamentos != null)
                    {
                        foreach (var objDepartamento in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = objDepartamento.IdDepartamento;
                            departamento.Nombre = objDepartamento.Nombre;

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = (byte)idArea;

                            result.Objects.Add(departamento);  

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
