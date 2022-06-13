using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Logica
{
    public class BL_Cliente
    {
        public static string codigocliente, nombre, nitcliente;
        public static int idcliente;

        public static void cargardgvclientes(DataGridView dgv)
        {
                        
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = db.CLIENTE.Where(x => x.ESTADO == true).Select(x => new { x.ID, x.CODIGO, x.NIT, x.NOMBRE, x.TELEFONO });
                dgv.DataSource = consulta.ToList();
            }

        }

        public static void agregarnuevocliente(CLIENTE cliente)
        {
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.CLIENTE.Add(cliente);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {


            }
        }

        public static void actualizarcliente(int id, string codigo, string nit, string nombre, string telefono)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from cliente in db.CLIENTE
                               where cliente.ID.Equals(id)
                               select cliente;

                foreach (var item in consulta)
                {
                    item.CODIGO = codigo;
                    item.NIT = nit;
                    item.NOMBRE = nombre;
                    item.TELEFONO = telefono;

                }

                db.SaveChanges();
                MessageBox.Show("Registro actualizado correctamente", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }

        public static void dardebajacliente(int id)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from cliente in db.CLIENTE
                               where cliente.ID.Equals(id)
                               select cliente;

                foreach (var item in consulta)
                {
                    item.ESTADO = false;
                }

                db.SaveChanges();
                MessageBox.Show("Se ha dado de baja al cliente", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static bool devolverdatoscliente(string codigo)
        {
            bool resp = false;
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var lst = from cliente in db.CLIENTE
                          where (cliente.CODIGO.Equals(codigo)) && cliente.ESTADO == true
                          select cliente;

                if (lst.Count() > 0)
                {
                    foreach (var item in lst)
                    {
                        nitcliente = item.NIT;
                        nombre = item.NOMBRE;
                        idcliente = item.ID;
                        
                    }
                    resp = true;
                }
                
            }
            return resp;
                             
        }

        public static bool devolverdatoscliente1(string codigo)
        {
            bool resp = false;
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var lst = from cliente in db.CLIENTE
                          where (cliente.NIT.Equals(codigo)) && cliente.ESTADO == true
                          select cliente;

                if (lst.Count() > 0)
                {
                    foreach (var item in lst)
                    {
                        codigocliente = item.CODIGO;
                        nombre = item.NOMBRE;
                        idcliente = item.ID;
                        
                    }
                    resp = true;
                }

            }
            return resp;

        }
    }
}
