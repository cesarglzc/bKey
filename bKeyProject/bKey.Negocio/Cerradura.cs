using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bKey.Negocio
{
    public class Cerradura
    {
        public int idCerradura { get; set; }
        public string llave { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }

        public Cerradura() { 
        }


        public bool compruebaLlave()
        {
            try
            {
                DALC.cerradura cerradura = CommonBC.ModelobKey.cerradura.First(
                        c => c.idcerradura == this.idCerradura && c.llave == this.llave
                    );
                this.nombre = cerradura.nombre;
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
                DALC.cerradura cerradura = new DALC.cerradura();
                cerradura.idcerradura = this.idCerradura;
                cerradura.llave = this.llave;
                cerradura.nombre = this.nombre;
                cerradura.activo = this.activo;

                CommonBC.ModelobKey.AddTocerradura(cerradura);
                CommonBC.ModelobKey.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Read()
        {
            try
            {
                DALC.cerradura cerradura = CommonBC.ModelobKey.cerradura.First(
                        per => per.idcerradura == this.idCerradura
                    );
                this.idCerradura = cerradura.idcerradura;
                this.llave = cerradura.llave;
                this.nombre = cerradura.nombre;
                this.activo = (bool)cerradura.activo;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Update()
        {
            try
            {

                DALC.cerradura cerradura = CommonBC.ModelobKey.cerradura.First(
                        per => per.idcerradura == this.idCerradura
                    );
                cerradura.idcerradura = this.idCerradura;
                cerradura.llave = this.llave;
                cerradura.nombre = this.nombre;
                cerradura.activo = this.activo;
                CommonBC.ModelobKey.SaveChanges();
                return true;
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
                DALC.cerradura cerradura = CommonBC.ModelobKey.cerradura.First(
                        per => per.idcerradura == this.idCerradura
                    );
                cerradura.activo = false;
                CommonBC.ModelobKey.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }

}
