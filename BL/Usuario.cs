using CurpValidator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.VRodriguezDrSecurityEntities context = new DL.VRodriguezDrSecurityEntities())
                {
                    var query = context.UsuarioGetAll().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Sexo = obj.Sexo;
                            usuario.EstadoNacimiento = obj.EstadoNacimiento;
                            usuario.Telefono = obj.Telefono;
                            usuario.CURP = obj.CURP;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = obj.IdDireccion;
                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.Colonia = obj.Colonia;
                            usuario.Direccion.Estado = obj.Estado;
                            usuario.Direccion.Municipio = obj.Municipio;
                            usuario.Direccion.Numero = obj.Numero;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pueden mostrar los datos";
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
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.VRodriguezDrSecurityEntities context = new DL.VRodriguezDrSecurityEntities())
                {
                    int query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo, usuario.CURP, usuario.EstadoNacimiento,  usuario.Telefono,usuario.Direccion.Calle, usuario.Direccion.Colonia, usuario.Direccion.Estado, usuario.Direccion.Municipio, usuario.Direccion.Numero);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se logro insertar";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezDrSecurityEntities context = new DL.VRodriguezDrSecurityEntities())
                {
                    var query = context.UsuarioGetById(IdUsuario).AsEnumerable().FirstOrDefault();
                    result.Object = new List<object>();
                    if(query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                        usuario.Sexo = query.Sexo;
                        usuario.EstadoNacimiento = query.EstadoNacimiento;
                        usuario.Telefono = query.Telefono;
                        usuario.CURP = query.CURP;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = query.IdDireccion;
                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.Colonia = query.Colonia;
                        usuario.Direccion.Estado = query.Estado;
                        usuario.Direccion.Municipio = query.Municipio;
                        usuario.Direccion.Numero = query.Numero;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede mostrar la información";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezDrSecurityEntities context = new DL.VRodriguezDrSecurityEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo,  usuario.CURP, usuario.EstadoNacimiento, usuario.Telefono,usuario.Direccion.Calle, usuario.Direccion.Colonia, usuario.Direccion.Estado, usuario.Direccion.Municipio, usuario.Direccion.Numero);
                    if (query >=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede actualizar la información";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete (ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
               using ( DL.VRodriguezDrSecurityEntities context = new DL.VRodriguezDrSecurityEntities())
                {
                    int query = context.UsuarioDelete(usuario.IdUsuario);
                    if(query >=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se ha podido eliminar";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result CURP(ML.Usuario usuario)
        {
            var sex = Genres.Male;
            var estado = Estado(usuario.Direccion.Estado);

            ML.Result result = new ML.Result();
            switch (usuario.Sexo.ToString())
            {
                case "H":
                    sex = Genres.Male;
                    break;
                case "M":
                    sex = Genres.Female;
                    break;
                default:
                    break;
            }
            string curp = CurpClass.CreateCURP(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno
                , DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", null), sex, estado);
            if (curp != null)
            {
                result.Message = curp;
                result.Correct = true;
            }
            else
            {

                result.Correct = false;
            }
            return result;
        }

        public static FederalEntities Estado(string estado)
        {
            var entidad = FederalEntities.Mexico;
            switch (estado)
            {
                case "Mexico":
                    entidad = FederalEntities.Mexico;
                    break;
                case "Nacido en el extranjero":
                    entidad = FederalEntities.NacidoExtranjero;
                    break;
                case "Nuevo Leon":
                    entidad = FederalEntities.NuevoLeon;
                    break;
            }

            return entidad;
        }


    }
}
