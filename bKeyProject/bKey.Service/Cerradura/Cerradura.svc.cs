using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bKey.Service.Cerradura
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Cerradura" in code, svc and config file together.
    public class Cerradura : ICerradura
    {
        public bool CrearCerradura(int idCerradura, string llave, string nombre)
        {
            Negocio.Cerradura cerradura = new Negocio.Cerradura();
            cerradura.idCerradura = idCerradura;
            cerradura.llave = llave;
            cerradura.nombre = nombre;
            return cerradura.Create();
        }
        public Negocio.Cerradura BuscarCerradura(int idCerradura)
        {
            Negocio.Cerradura cerradura = new Negocio.Cerradura();
            cerradura.idCerradura = idCerradura;
            if (cerradura.Read())
                return cerradura;
            else
                return null;
        }
        public bool EliminarCerradura(int idCerradura)
        {
            Negocio.Cerradura cerradura = new Negocio.Cerradura();
            cerradura.idCerradura = idCerradura;
            return cerradura.Delete();
        }
        public bool ModificarCerradura(int idCerradura, string nombre)
        {
            Negocio.Cerradura cerradura = new Negocio.Cerradura();
            cerradura.idCerradura = idCerradura;
            cerradura.nombre = nombre;
            return cerradura.Update();
        }
    }
}
