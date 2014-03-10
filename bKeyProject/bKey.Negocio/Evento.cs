using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mime;
using System.Media;

namespace bKey.Negocio
{
    public class Evento
    {
        public int idEvento { get; set; }
        public DateTime fecha { get; set; }
        public int idCerradura { get; set; }
        public byte[] foto { get; set; }

        public Evento() { }

        public bool Create()
        {
            try
            {
                DALC.evento evento = new DALC.evento();
                evento.idevento = this.idEvento;
                evento.idcerradura = this.idCerradura;
                evento.fecha = this.fecha;
                evento.foto = this.foto;

                CommonBC.ModelobKey.AddToevento(evento);
                CommonBC.ModelobKey.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }
        public List<Negocio.Evento> ReadAllWithIdCerradura()
        {
            List<Negocio.Evento> listaEventos = new List<Evento>();
            try
            {
                List<DALC.evento> listaDALC = CommonBC.ModelobKey.evento.Where(res => res.idcerradura == this.idCerradura && (res.fecha >= this.fecha)).OrderByDescending(res => res.fecha).ToList();
                foreach (DALC.evento eventod in listaDALC)
                {
                    Negocio.Evento eventon = new Evento();
                    eventon.idEvento = eventod.idevento;
                    eventon.idCerradura = eventod.idcerradura;
                    eventon.fecha = eventod.fecha;
                    eventon.foto = eventod.foto;
                    listaEventos.Add(eventon);
                }
                return listaEventos;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return listaEventos;
        }
        public List<Negocio.Evento> ReadAllWithIdCerraduraAndFecha()
        {
            List<Negocio.Evento> listaEventos = new List<Evento>();
            try
            {
                List<DALC.evento> listaDALC = CommonBC.ModelobKey.evento.Where(res => res.idcerradura == this.idCerradura && (res.fecha == this.fecha)).OrderByDescending(res => res.fecha).ToList();
                foreach (DALC.evento eventod in listaDALC)
                {
                    Negocio.Evento eventon = new Evento();
                    eventon.idEvento = eventod.idevento;
                    eventon.idCerradura = eventod.idcerradura;
                    eventon.fecha = eventod.fecha;
                    eventon.foto = eventod.foto;
                    listaEventos.Add(eventon);
                }
                return listaEventos;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return listaEventos;
        }
    }
}
