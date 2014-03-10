using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bKey.Service.Evento
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEvento" in both code and config file together.
    [ServiceContract]
    public interface IEvento
    {
        [OperationContract]
        bool CrearEvento(byte[] foto, int idcerradura);
        [OperationContract]
        List<Negocio.Evento> BuscarEventoCerradura(int idcerradura, string usernameDuenio);
        [OperationContract]
        List<Negocio.Evento> BuscarEventoCerraduraFecha(int idcerradura, string usernameDuenio, DateTime fecha);
    }
}
