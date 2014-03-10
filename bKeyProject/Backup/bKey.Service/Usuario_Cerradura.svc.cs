using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using bKey.Negocio;

namespace bKey.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class usuario_cerradura : Iusuario_cerradura
    {
        public bool darAcceso(string usernameDuenio,int idcerradura, string usernameInvitado)
        {
            bKey.Negocio.Usuario_Cerradura ucD = new bKey.Negocio.Usuario_Cerradura();
            ucD.username = usernameDuenio;
            ucD.idCerradura = idcerradura;
            if (ucD.CompruebaDuenio())
            {
                bKey.Negocio.Usuario_Cerradura ucI = new bKey.Negocio.Usuario_Cerradura();
                ucI.username = usernameInvitado;
                ucI.idCerradura = idcerradura;
                ucI.idTipoUsuario = 2;
                ucI.fecha = DateTime.Now;
                return ucI.Create();
            }else
                return false;
        }

        public bool quitarAcceso(string usernameDuenio, int idcerradura, string usernameInvitado)
        {
            bKey.Negocio.Usuario_Cerradura ucD = new bKey.Negocio.Usuario_Cerradura();
            ucD.username = usernameDuenio;
            ucD.idCerradura = idcerradura;
            if (ucD.CompruebaDuenio())
            {
                bKey.Negocio.Usuario_Cerradura ucI = new bKey.Negocio.Usuario_Cerradura();
                ucI.username = usernameInvitado;
                ucI.idCerradura = idcerradura;
                return ucI.Delete();
            }else
                return false;
            
        }

        public bool registrarDuenio(string usernameDuenio, int idcerradura, string llave) 
        {
            bKey.Negocio.Cerradura cerradura = new bKey.Negocio.Cerradura();
            cerradura.idCerradura = idcerradura;
            cerradura.llave = llave;

            if (cerradura.compruebaLlave())
            {
                bKey.Negocio.Usuario_Cerradura ucD = new bKey.Negocio.Usuario_Cerradura();
                ucD.username = usernameDuenio;
                ucD.idCerradura = idcerradura;
                ucD.idTipoUsuario = 1;
                ucD.fecha = DateTime.Now;
                if (ucD.Create())
                    return true;
                else
                    return false;
            }else {
                return false;
            }

        }

        public bool eliminarDuenio(string usernameDuenio, int idcerradura, string llave)
        {
            bKey.Negocio.Cerradura cerradura = new bKey.Negocio.Cerradura();
            cerradura.idCerradura = idcerradura;
            cerradura.llave = llave;

            if (cerradura.compruebaLlave())
            {
                bKey.Negocio.Usuario_Cerradura ucD = new bKey.Negocio.Usuario_Cerradura();
                ucD.username = usernameDuenio;
                ucD.idCerradura = idcerradura;
                ucD.idTipoUsuario = 1;
                if (ucD.Delete())
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }

        }
    }
}
