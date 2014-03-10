using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bKey.Service.Acceso
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAcceso" in both code and config file together.
    [ServiceContract]
    public interface IAcceso
    {
        [OperationContract]
        bool CrearAcceso(int idcerradura, byte[] foto, string username);
        [OperationContract]
        List<Negocio.Acceso> BuscarAccesoCerradura(int idcerradura, string usernameDuenio);
        [OperationContract]
        List<Negocio.Acceso> BuscarAccesoCerraduraFecha(int idcerradura, string usernameDuenio, DateTime fecha);
    }
}
