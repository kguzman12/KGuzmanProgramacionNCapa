using DL_EF;
using ML;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
    //Sql client
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Sexo])VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@Sexo)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta sentencia sql
                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[7];//Arreglo que se almacena la informacion
                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[2].Value = usuario.FechaNacimiento;

                        collection[3] = new SqlParameter("Sexo", System.Data.SqlDbType.Char);
                        collection[3].Value = usuario.Sexo;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "El usuario se agrego correctamente";
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

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UPDATE [Usuario]SET [Nombre]=@Nombre,[ApellidoPaterno]=@ApellidoPaterno,[ApellidoMaterno]=@ApellidoMaterno,[FechaNacimiento]=@FechaNacimiento,[Sexo]=@Sexo WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta
                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("Sexo", System.Data.SqlDbType.Char);
                        collection[5].Value = usuario.Sexo;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "EL usuario se modifico correctamente";
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

        public static ML.Result Delate(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "USE [KGuzmanProgramacionNCapas] DELETE FROM [Usuario] WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta
                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "EL usuario se elimino correctamente";
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


    //Stored Procedure
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("@Email", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Email;

                        collection[5] = new SqlParameter("@Password", System.Data.SqlDbType.Char);
                        collection[5].Value = usuario.Password;

                        collection[6] = new SqlParameter("@UserName", System.Data.SqlDbType.Char);
                        collection[6].Value = usuario.UserName;

                        collection[7] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[7].Value = usuario.Sexo;

                        collection[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.Char);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.Char);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@Curp", System.Data.SqlDbType.Char);
                        collection[10].Value = usuario.Curp;

                        collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
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

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;

                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("@Email", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Email;

                        collection[5] = new SqlParameter("@Password", System.Data.SqlDbType.Char);
                        collection[5].Value = usuario.Password;

                        collection[6] = new SqlParameter("@UserName", System.Data.SqlDbType.Char);
                        collection[6].Value = usuario.UserName;

                        collection[7] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[7].Value = usuario.Sexo;

                        collection[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.Char);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.Char);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@Curp", System.Data.SqlDbType.Char);
                        collection[10].Value = usuario.Curp;

                        collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
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

        public static ML.Result DelateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioDelate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta
                        cmd.CommandType = CommandType.StoredProcedure;

                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "El usuario se elimino correctamente";
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string querySP = "UsuarioGetAll"; 
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = querySP; //consulta sql
                        cmd.CommandType = CommandType.StoredProcedure;
                        contex.Open();

                        DataTable usuarioTable = new DataTable();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); 
      
                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();
                                usuario.Email = row[5].ToString();
                                usuario.Password = row[6].ToString();
                                usuario.UserName = row[7].ToString();
                                usuario.Sexo = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.Curp = row[11].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                                result.Objects.Add(usuario);
                            }
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

        public static ML.Result GetByIdSP(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                        collection[0].Value = idUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            DataRow row = tableUsuario.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.UserName = row[7].ToString();
                            usuario.Sexo = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.Curp = row[11].ToString();

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                            result.Object = usuario;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
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

    //Entity Framework
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    int query = contex.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo, usuario.Password, usuario.Telefono, usuario.Celular, usuario.Curp, usuario.UserName, usuario.Email, usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Message = "El usuario se agrego correctamente";
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

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    //usuario.Rol.IdRol = (usuario.Rol.IdRol == null) ? 0 : usuario.Rol.IdRol;
                    var query = contex.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo, usuario.Password, usuario.Telefono, usuario.Celular, usuario.Curp, usuario.UserName, usuario.Email, usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Message = "EL usuario se modifico correctamente";
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

        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    int query = contex.UsuarioDelete(usuario.IdUsuario);

                    if (query >= 1)
                    {
                        result.Message = "El usuario se elimino correctamente";
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

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
                    usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;

                    var usuarios = contex.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno).ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var objeto in usuarios)
                        {
                            usuario = new ML.Usuario();

                            usuario.IdUsuario = objeto.IdUsuario;
                            usuario.Nombre = objeto.Nombre;
                            usuario.ApellidoPaterno = objeto.ApellidoPaterno;
                            usuario.ApellidoMaterno = objeto.ApellidoMaterno;
                            usuario.FechaNacimiento = objeto.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            usuario.Sexo = objeto.Sexo;
                            usuario.Password = objeto.Password;
                            usuario.Telefono = objeto.Telefono;
                            usuario.Celular = objeto.Celular;
                            usuario.Curp = objeto.Curp;
                            usuario.UserName = objeto.UserName;
                            usuario.Email = objeto.Email;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(objeto.IdRol.ToString());
                            usuario.Rol.Nombre = objeto.Nombre;

                            usuario.Imagen = objeto.Imagen;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = objeto.IdDireccion;
                            usuario.Direccion.Calle = objeto.Calle;
                            usuario.Direccion.NumeroInterior = objeto.NumeroInterior;
                            usuario.Direccion.NumeroExterior = objeto.NumeroExterior;
                            
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = objeto.IdColonia;
                            usuario.Direccion.Colonia.Nombre = objeto.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = objeto.CodigoPostal;
                            
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = objeto.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = objeto.NombreMunicipio;
                           
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objeto.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = objeto.NombreEstado;
                            
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objeto.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objeto.NombrePais;


                            result.Objects.Add(usuario);
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

        public static ML.Result GetByIdEF(int idUsuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities contex = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var tableUsuario = contex.UsuarioGetById(idUsuario).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (tableUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = tableUsuario.IdUsuario;
                        usuario.Nombre = tableUsuario.Nombre;
                        usuario.ApellidoPaterno = tableUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = tableUsuario.ApellidoMaterno;
                        usuario.FechaNacimiento = tableUsuario.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                        usuario.Sexo = tableUsuario.Sexo;
                        usuario.Password = tableUsuario.Password;
                        usuario.Telefono = tableUsuario.Telefono;
                        usuario.Celular = tableUsuario.Telefono;
                        usuario.Curp = tableUsuario.Curp;
                        usuario.UserName = tableUsuario.UserName;
                        usuario.Email = tableUsuario.Email;
                        
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = byte.Parse(tableUsuario.IdRol.ToString());

                        usuario.Imagen = tableUsuario.Imagen;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = tableUsuario.IdDireccion;
                        usuario.Direccion.Calle = tableUsuario.Calle;
                        usuario.Direccion.NumeroInterior = tableUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = tableUsuario.NumeroExterior;
                       
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = tableUsuario.IdColonia;
                        usuario.Direccion.Colonia.Nombre = tableUsuario.NombreColonia;
                    
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = tableUsuario.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = tableUsuario.NombreMunicipio;
                       
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = tableUsuario.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = tableUsuario.NombreEstado;
                        
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = tableUsuario.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = tableUsuario.NombrePais;

                        result.Object = usuario;
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


    //LINQ
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.Curp = usuario.Curp;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.IdRol = (byte)usuario.Rol.IdRol;

                    //usuario.Rol = new ML.Rol();
                    //usuario.Rol.IdRol = byte.Parse(usuarioDL.IdRol.ToString());

                    context.Usuarios.Add(usuarioDL);
                    context.SaveChanges();
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

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.IdUsuario = usuario.IdUsuario;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.Curp = usuario.Curp;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.IdRol = (byte)usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);
                    context.SaveChanges();
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

        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var query = (from a in context.Usuarios
                                 where a.IdUsuario == usuario.IdUsuario
                                 select a).First();

                    context.Usuarios.Remove(query);
                    context.SaveChanges();
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

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var query = (from usuarioLQ in context.Usuarios
                                     //join rol in context.Rols on usuarioLQ.IdRol equals rol.IdRol
                                 select new
                                 {
                                     idUsuario = usuarioLQ.IdUsuario,
                                     Nombre = usuarioLQ.Nombre,
                                     ApellidoPaterno = usuarioLQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLQ.ApellidoMaterno,
                                     FechaNacimiento = usuarioLQ.FechaNacimiento,
                                     Sexo = usuarioLQ.Sexo,
                                     Password = usuarioLQ.Password,
                                     Telefono = usuarioLQ.Telefono,
                                     Celular = usuarioLQ.Celular,
                                     Curp = usuarioLQ.Curp,
                                     UserName = usuarioLQ.UserName,
                                     Email = usuarioLQ.Email,
                                     IdRol = usuarioLQ.IdRol
                                 });

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = row.idUsuario;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;
                            usuario.ApellidoMaterno = row.ApellidoPaterno;
                            usuario.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            usuario.Sexo = row.Sexo;
                            usuario.Password = row.Password;
                            usuario.Telefono = row.Telefono;
                            usuario.Celular = row.Celular;
                            usuario.Curp = row.Curp;
                            usuario.UserName = row.UserName;
                            usuario.Email = row.Email;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(row.IdRol.ToString());

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
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

        public static ML.Result GetByIdLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGuzmanProgramacionNCapasEntities context = new DL_EF.KGuzmanProgramacionNCapasEntities())
                {
                    var query = (from usuarioLQ in context.Usuarios
                                 where usuarioLQ.IdUsuario == idUsuario
                                 select new
                                 {
                                     IdUsuario = usuarioLQ.IdUsuario,

                                     Nombre = usuarioLQ.Nombre,
                                     ApellidoPaterno = usuarioLQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLQ.ApellidoMaterno,
                                     FechaNacimiento = usuarioLQ.FechaNacimiento,
                                     Sexo = usuarioLQ.Sexo,
                                     Password = usuarioLQ.Password,
                                     Telefono = usuarioLQ.Telefono,
                                     Celular = usuarioLQ.Celular,
                                     Curp = usuarioLQ.Curp,
                                     UserName = usuarioLQ.UserName,
                                     Email = usuarioLQ.Email,
                                     IdRol = usuarioLQ.IdRol
                                 }).SingleOrDefault(); 
                    //result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                        usuario.Sexo = query.Sexo;
                        usuario.Password = query.Password;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.Curp = query.Curp;
                        usuario.UserName = query.UserName;
                        usuario.Email = query.Email;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;


                        result.Object = usuario;
                        result.Correct = true;
                        //result.Objects.Add(usuario);//boxing
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


    }
}
