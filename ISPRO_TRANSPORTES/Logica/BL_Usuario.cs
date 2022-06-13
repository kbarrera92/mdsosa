using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Logica
{
    public class BL_Usuario
    {
        public static int codusuarioActual;
        public static short tipousuario;
        public static string nombreUsuarioActual;

        public static void llenardgvusuario(DataGridView dgv)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from user in db.USUARIO
                               join tipo in db.TIPOUSUARIO
                               on user.TIPO equals tipo.ID
                               select new
                               {
                                   user.ID,
                                   user.CODIGO,
                                   user.CLAVE,
                                   tipo.DESCRIPCION
                               };
                dgv.DataSource = consulta.ToList();
            }
        }

        public static void llenarcmb(ComboBox cmb)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = db.TIPOUSUARIO.Select(x => new { x.ID, x.DESCRIPCION});
                cmb.DataSource = consulta.ToList();
                cmb.ValueMember = "ID";
                cmb.DisplayMember = "DESCRIPCION";
            }
        }

        public static void agregarnuevousuario(USUARIO usuario)
        {
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.USUARIO.Add(usuario);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                
            }
        }

        public static bool checharlogin(string user, string pass)
        {
            bool resp = false;

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var lst = db.USUARIO.Where(x => x.CODIGO.Equals(user) && x.CLAVE.Equals(pass) && x.ESTADO == true).Select(x => x);

                if (lst.Count()>0)
                {
                    foreach (var item in lst)
                    {
                        codusuarioActual = item.ID;
                        nombreUsuarioActual = item.CODIGO;
                        tipousuario = Convert.ToInt16(item.TIPO);
                    }
                    resp = true;
                }
                
                
            }

            return resp;
        }

        public static void actualizarusuario(int id, string codigo, string clave, byte tipo)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from user in db.USUARIO
                               where user.ID.Equals(id)
                               select user;

                foreach (var item in consulta)
                {
                    item.CODIGO = codigo;
                    item.CLAVE = clave;
                    item.TIPO = tipo;
                   
                }

                db.SaveChanges();
                MessageBox.Show("Registro actualizado correctamente", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


    }
}

