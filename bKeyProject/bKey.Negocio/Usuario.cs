using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bKey.Negocio
{
    public class Usuario
    {
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }

        public Usuario() {
        }
        public bool Create()
        {
            try
            {
                DALC.usuario usuario = new DALC.usuario();
                usuario.username = this.username;
                usuario.password = this.password;
                usuario.nombre = this.nombre;

                CommonBC.ModelobKey.AddTousuario(usuario);
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
                DALC.usuario usuario = CommonBC.ModelobKey.usuario.First(
                        per => per.username == this.username
                    );
                this.password = usuario.password;
                this.nombre = usuario.nombre;
                this.username = usuario.username;

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

                DALC.usuario usuario = CommonBC.ModelobKey.usuario.First(
                        per => per.username == this.username
                    );
                usuario.username = this.username;
                usuario.password = this.password;
                usuario.nombre = this.nombre;
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

                DALC.usuario usuario = CommonBC.ModelobKey.usuario.First(
                        per => per.username == this.username
                    );
                CommonBC.ModelobKey.DeleteObject(usuario);
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
