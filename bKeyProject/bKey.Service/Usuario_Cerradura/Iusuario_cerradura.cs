using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace bKey.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface Iusuario_cerradura
    {

        [OperationContract]
        bool darAcceso(string usernameDuenio, int idcerradura, string usernameInvitado);
        [OperationContract]
        bool quitarAcceso(string usernameDuenio, int idcerradura, string usernameInvitado);
        [OperationContract]
        bool registrarDuenio(string usernameDuenio, int idcerradura, string llave);
        [OperationContract]
        bool eliminarDuenio(string usernameDuenio, int idcerradura, string llave);
    }
}
