using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bKey.Negocio
{
    public class Usuario_Cerradura
    {
        public string username { get; set; }
        public int idCerradura { get; set; }
        public int idTipoUsuario { get; set; }
        public DateTime fecha { get; set; }
        
        public Usuario_Cerradura() { }

        public bool Read()
        {
            try
            {
                DALC.usuario_cerradura uc = CommonBC.ModelobKey.usuario_cerradura.First(
                        per => per.username == username && per.idcerradura == idCerradura
                    );
                this.username = uc.username;
                this.idCerradura = uc.idcerradura;
                this.idTipoUsuario = uc.idTipoUsuario;
                this.fecha = uc.fecha;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Create()
        {
            try
            {
                DALC.usuario_cerradura usuario_cerradura = new DALC.usuario_cerradura();
                usuario_cerradura.username = this.username;
                usuario_cerradura.idcerradura = this.idCerradura;
                usuario_cerradura.idTipoUsuario = this.idTipoUsuario;
                usuario_cerradura.fecha = this.fecha;
                CommonBC.ModelobKey.AddTousuario_cerradura(usuario_cerradura);
                CommonBC.ModelobKey.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
        public bool CompruebaDuenio() {
            try
            {
                DALC.usuario_cerradura uc = CommonBC.ModelobKey.usuario_cerradura.First(
                        per => per.username == this.username && per.idcerradura == idCerradura
                    );
                this.idTipoUsuario = uc.idTipoUsuario;
                this.fecha = uc.fecha;
                if (idTipoUsuario == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                DALC.usuario_cerradura usuariocerradura = CommonBC.ModelobKey.usuario_cerradura.First(
                        h => (h.username == this.username) && (h.idcerradura == this.idCerradura)
                    );
                CommonBC.ModelobKey.DeleteObject(usuariocerradura);
                CommonBC.ModelobKey.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Negocio.Usuario_Cerradura> ReadAllInvitados()
        {
            List<Negocio.Usuario_Cerradura> listaInvitados = new List<Usuario_Cerradura>();
            try
            {
                List<DALC.usuario_cerradura> listaDALC = CommonBC.ModelobKey.usuario_cerradura.Where(res => res.idcerradura == this.idCerradura && (res.idTipoUsuario == 2)).OrderBy(res => res.username).ToList();
                foreach (DALC.usuario_cerradura usuario_cerradurad in listaDALC)
                {
                    Negocio.Usuario_Cerradura usuario_cerraduran = new Usuario_Cerradura();
                    usuario_cerraduran.idTipoUsuario = usuario_cerradurad.idTipoUsuario;
                    usuario_cerraduran.idCerradura = usuario_cerradurad.idcerradura;
                    usuario_cerraduran.fecha = usuario_cerradurad.fecha;
                    usuario_cerraduran.username = usuario_cerradurad.username;
                    listaInvitados.Add(usuario_cerraduran);
                }
                return listaInvitados;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return listaInvitados;
        }
        public bool DeleteAllInvitados()
        {
            try
            {
                Negocio.Usuario_Cerradura usuario_cerraduran = new Usuario_Cerradura();
                List<DALC.usuario_cerradura> listaDALC = CommonBC.ModelobKey.usuario_cerradura.Where(res => res.idcerradura == this.idCerradura && (res.idTipoUsuario == 2)).OrderBy(res => res.username).ToList();
                if (listaDALC.ToList().Count > 0)
                {
                    foreach (DALC.usuario_cerradura usuario_cerradurad in listaDALC)
                    {
                        usuario_cerraduran.idTipoUsuario = usuario_cerradurad.idTipoUsuario;
                        usuario_cerraduran.idCerradura = usuario_cerradurad.idcerradura;
                        usuario_cerraduran.username = usuario_cerradurad.username;
                        usuario_cerraduran.Delete();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }
    }
}
