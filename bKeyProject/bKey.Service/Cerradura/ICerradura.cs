using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bKey.Service.Cerradura
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICerradura" in both code and config file together.
    [ServiceContract]
    public interface ICerradura
    {
        [OperationContract]
        bool CrearCerradura(int idCerradura, string llave, string nombre);
        [OperationContract]
        Negocio.Cerradura BuscarCerradura(int idCerradura);
        [OperationContract]
        bool EliminarCerradura(int idCerradura);
        [OperationContract]
        bool ModificarCerradura(int idCerradura, string nombre);
    }
}
