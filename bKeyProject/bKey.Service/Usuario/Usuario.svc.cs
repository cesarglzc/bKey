using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bKey.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario" in code, svc and config file together.
    public class Usuario : IUsuario
    {
        public bool CrearUsuario(string username, string password, string nombre)
        {
            bKey.Negocio.Usuario usuarioNuevo = new Negocio.Usuario();
            usuarioNuevo.nombre = nombre;
            usuarioNuevo.password = password;
            usuarioNuevo.username = username;
            return usuarioNuevo.Create();
        }
        public Negocio.Usuario BuscarUsuario(string username)
        {
            bKey.Negocio.Usuario usuario = new Negocio.Usuario();
            usuario.username = username;
            if (usuario.Read())
                return usuario;
            else
                return null;
        }
        public bool EliminarUsuario(string username)
        {
            bKey.Negocio.Usuario usuario = new Negocio.Usuario();
            usuario.username = username;
            return usuario.Delete();
        }
        public bool ModificarUsuario(string username, string nombre, string password)
        {
            bKey.Negocio.Usuario usuario = new Negocio.Usuario();
            usuario.username = username;
            usuario.nombre = nombre;
            usuario.password = password;
            return usuario.Update();
        }
    }
}
