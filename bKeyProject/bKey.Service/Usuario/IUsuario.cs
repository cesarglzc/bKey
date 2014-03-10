using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bKey.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuario" in both code and config file together.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        bool CrearUsuario(string username, string password, string nombre);
        [OperationContract]
        Negocio.Usuario BuscarUsuario(string username);
        [OperationContract]
        bool EliminarUsuario(string username);
        [OperationContract]
        bool ModificarUsuario(string username, string nombre, string password);
    }
}
