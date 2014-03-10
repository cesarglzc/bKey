using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bKey.Service.Evento
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Evento" in code, svc and config file together.
    public class Evento : IEvento
    {
        public bool CrearEvento(byte[] foto, int idcerradura)
        {
            bKey.Negocio.Evento evento = new bKey.Negocio.Evento();
            evento.idEvento = 0;
            evento.fecha = DateTime.Now;
            evento.idCerradura = idcerradura;
            evento.foto = foto;
            return evento.Create();
        }

        public List<Negocio.Evento> BuscarEventoCerradura(int idcerradura, string usernameDuenio)
        {
            bKey.Negocio.Usuario_Cerradura ucD = new bKey.Negocio.Usuario_Cerradura();
            ucD.username = usernameDuenio;
            ucD.idCerradura = idcerradura;
            List<Negocio.Evento> listaEventos = new List<Negocio.Evento>();
            if (ucD.CompruebaDuenio())
            {
                bKey.Negocio.Evento evento = new bKey.Negocio.Evento();
                evento.idEvento = 0;
                evento.fecha = ucD.fecha;
                evento.idCerradura = idcerradura;
                listaEventos = evento.ReadAllWithIdCerradura();
            }
            return listaEventos;
        }


        public List<Negocio.Evento> BuscarEventoCerraduraFecha(int idcerradura, string usernameDuenio, DateTime fecha)
        {
            bKey.Negocio.Usuario_Cerradura ucD = new bKey.Negocio.Usuario_Cerradura();
            ucD.username = usernameDuenio;
            ucD.idCerradura = idcerradura;
            List<Negocio.Evento> listaEventos = new List<Negocio.Evento>();
            if (ucD.CompruebaDuenio())
            {
                if (fecha >= ucD.fecha)
                {
                    bKey.Negocio.Evento evento = new bKey.Negocio.Evento();
                    evento.idEvento = 0;
                    evento.fecha = fecha;
                    evento.idCerradura = idcerradura;
                    listaEventos = evento.ReadAllWithIdCerraduraAndFecha();
                }
            }
            return listaEventos;

        }
    }
}
