using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;

namespace Logica
{
    public class BL_Proveedores
    {
        public static string nombreproveedor { get; set; }
        public static int idproveedor { get; set; }

        public static void llenardgvproveedor(DataGridView dgv)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = db.PROVEEDOR.Where(x => x.ESTADO == true).Select(x => new { x.ID, x.NIT, x.NOMBRE, x.DIRECCION, x.TELEFONO, x.CONTACTO });
                dgv.DataSource = consulta.ToList();
            }
        }

        public static void agregarnuevoproveedor(PROVEEDOR prov)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                db.PROVEEDOR.Add(prov);
                db.SaveChanges();
            }


        }

        public static void actualizarproveedor(int id, string nit, string nombre, string direccion, string telefono, string contacto)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from prov in db.PROVEEDOR
                               where prov.ID.Equals(id)
                               select prov;

                foreach (var item in consulta)
                {
                    item.NOMBRE = nombre;
                    item.DIRECCION = direccion;
                    item.TELEFONO = telefono;
                    item.CONTACTO = contacto;

                }

                db.SaveChanges();
                MessageBox.Show("Registro actualizado correctamente", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public static void dardebajaproveedor(int id)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from prov in db.PROVEEDOR
                               where prov.ID.Equals(id)
                               select prov;

                foreach (var item in consulta)
                {
                    item.ESTADO = false;
                }

                db.SaveChanges();
                MessageBox.Show("Se ha dado de baja al proveedor", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Obtener los datos del proveedor
        public static bool devolverdatosproveedor(string placa)
        {
            bool resp = false;
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var lst = from prov in db.PROVEEDOR
                          where (prov.NIT.Equals(placa)) && prov.ESTADO == true
                          select new
                          {
                              prov.ID,
                              prov.NIT,
                              prov.NOMBRE,
                              
                          };

                if (lst.Count() > 0)
                {
                    foreach (var item in lst)
                    {
                        nombreproveedor = item.NOMBRE;
                        idproveedor = item.ID;                       
                    }
                    resp = true;
                }

            }
            return resp;
        }
    }
}
