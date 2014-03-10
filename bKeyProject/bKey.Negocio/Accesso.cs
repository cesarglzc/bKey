using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bKey.Negocio
{
    public class Acceso
    {
        public int idAcceso { get; set; }
        public DateTime fecha { get; set; }
        public int idCerradura { get; set; }
        public byte[] foto { get; set; }
        public string username { get; set; }
        
        public Acceso() { }

        public bool Create()
        {
            try
            {
                DALC.acceso acceso = new DALC.acceso();
                acceso.idacceso = this.idAcceso;
                acceso.idcerradura = this.idCerradura;
                acceso.fecha = this.fecha;
                acceso.foto = this.foto;
                acceso.username = this.username;

                CommonBC.ModelobKey.AddToacceso(acceso);
                CommonBC.ModelobKey.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Negocio.Acceso> ReadAllWithIdCerradura()
        {
            List<Negocio.Acceso> listaEventos = new List<Acceso>();
            try
            {
                List<DALC.acceso> listaDALC = CommonBC.ModelobKey.acceso.Where(res => res.idcerradura == this.idCerradura && (res.fecha >= this.fecha)).OrderByDescending(res => res.fecha).ToList();
                foreach (DALC.acceso accesod in listaDALC)
                {
                    Negocio.Acceso acceson = new Acceso();
                    acceson.idAcceso = accesod.idacceso;
                    acceson.idCerradura = accesod.idcerradura;
                    acceson.fecha = accesod.fecha;
                    acceson.foto = accesod.foto;
                    listaEventos.Add(acceson);
                }
                return listaEventos;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return listaEventos;
        }
        public List<Negocio.Acceso> ReadAllWithIdCerraduraAndFecha()
        {
            List<Negocio.Acceso> listaEventos = new List<Acceso>();
            try
            {
                List<DALC.acceso> listaDALC = CommonBC.ModelobKey.acceso.Where(res => res.idcerradura == this.idCerradura && (res.fecha == this.fecha)).OrderByDescending(res => res.fecha).ToList();
                foreach (DALC.acceso accesod in listaDALC)
                {
                    Negocio.Acceso acceson = new Acceso();
                    acceson.idAcceso = accesod.idacceso;
                    acceson.idCerradura = accesod.idcerradura;
                    acceson.fecha = accesod.fecha;
                    acceson.foto = accesod.foto;
                    listaEventos.Add(acceson);
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
