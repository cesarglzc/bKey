using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bKey.Service.Acceso
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Acceso" in code, svc and config file together.
    public class Acceso : IAcceso
    {
        public bool CrearAcceso(int idcerradura, byte[] foto, string username)
        {
            bKey.Negocio.Acceso acceso = new bKey.Negocio.Acceso();
            acceso.idAcceso = 0;
            acceso.fecha = DateTime.Now;
            acceso.idCerradura = idcerradura;
            acceso.foto = foto;
            acceso.username = username;
            return acceso.Create();
        }
        public List<Negocio.Acceso> BuscarAccesoCerradura(int idcerradura, string usernameDuenio)
        {
            bKey.Negocio.Usuario_Cerradura ucD = new bKey.Negocio.Usuario_Cerradura();
            ucD.username = usernameDuenio;
            ucD.idCerradura = idcerradura;
            List<Negocio.Acceso> listaAccesos = new List<Negocio.Acceso>();
            if (ucD.CompruebaDuenio())
            {
                bKey.Negocio.Acceso acceso = new bKey.Negocio.Acceso();
                acceso.idAcceso = 0;
                acceso.fecha = ucD.fecha;
                acceso.idCerradura = idcerradura;
                listaAccesos = acceso.ReadAllWithIdCerradura();
            }
            return listaAccesos;
        }
        public List<Negocio.Acceso> BuscarAccesoCerraduraFecha(int idcerradura, string usernameDuenio, DateTime fecha)
        {
            bKey.Negocio.Usuario_Cerradura ucD = new bKey.Negocio.Usuario_Cerradura();
            ucD.username = usernameDuenio;
            ucD.idCerradura = idcerradura;
            List<Negocio.Acceso> listaAccesos = new List<Negocio.Acceso>();
            if (ucD.CompruebaDuenio())
            {
                if (fecha >= ucD.fecha)
                {
                    bKey.Negocio.Acceso acceso = new bKey.Negocio.Acceso();
                    acceso.idAcceso = 0;
                    acceso.fecha = fecha;
                    acceso.idCerradura = idcerradura;
                    listaAccesos = acceso.ReadAllWithIdCerraduraAndFecha();
                }
            }
            return listaAccesos;
        }
    }
}
