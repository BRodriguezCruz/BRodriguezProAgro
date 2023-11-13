using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        //PROPERTIES
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public byte[]? Contraseña { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? RFC { get; set; }
        public List<object>? ListaUsuarios { get; set; }
        public bool Correct { get; set; }



        //METHODS

        public static Usuario GetAll()
        {
            Usuario usuario = new Usuario();

            try
            {
                using (DL.BrodriguezProAgroContext context = new DL.BrodriguezProAgroContext())
                {

                    var query = context.Usuarios.FromSql($"UsuarioGetAll").ToList();

                    usuario.ListaUsuarios = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            Usuario usuario1 = new Usuario();

                            usuario1.IdUsuario = registro.IdUsuario;
                            usuario1.Contraseña = registro.Contrasena;
                            usuario1.Nombre = registro.Nombre;
                            usuario1.FechaNacimiento = registro.FechaNacimiento;
                            usuario1.ApellidoPaterno = registro.ApellidoPaterno;
                            usuario1.RFC = registro.Rfc;

                            usuario.ListaUsuarios.Add(usuario1);
                            usuario.Correct = true;
                        }
                    }
                    else
                    {
                        usuario.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                usuario.Correct = false;
                var message = ex.Message;
            }
            return usuario;
        }

        public static Usuario GetById(int idUsuario)
        {
            Usuario usuario = new Usuario();

            try
            {
                using (DL.BrodriguezProAgroContext context = new DL.BrodriguezProAgroContext())
                {

                    var query = context.Usuarios.FromSql($"UsuarioGetById {idUsuario}").AsEnumerable().SingleOrDefault();

                    if (query != null)
                    {

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Contraseña = query.Contrasena;
                        usuario.Nombre = query.Nombre;
                        usuario.FechaNacimiento = query.FechaNacimiento;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.RFC = query.Rfc;
                        
                        usuario.Correct = true;
                    }
                    else
                    {
                        usuario.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                usuario.Correct = false;
                var message = ex.Message;
            }
            return usuario;
        }

    }
}
