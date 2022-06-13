using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace Logica
{
    public class BL_Pilotos
    {
        public static string nombrepiloto { get; set; }
        public static int idpiloto { get; set; }
        public static string codigopiloto { get; set; }

        public static void llenardgvpagospilotos(DataGridView dgv)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = db.PAGOAPILOTO.Select(x => new
                {
                    x.IDPAGO,
                    x.PILOTO,
                    x.FECHAREGISTRO,
                    x.NODOCUMENTO,
                    x.QUINCENA,
                    x.VIATICOS,
                    x.ENTRADAS,
                    x.PARQUEO,
                    x.DESCARGA,
                    x.OTROS,
                    TOTALVIAJES = x.TOTAL,
                    TOTAL = (x.QUINCENA + x.VIATICOS + x.ENTRADAS + x.ENTRADAS + x.PARQUEO + x.DESCARGA + x.OTROS + x.TOTAL)});
                dgv.DataSource = consulta.ToList();
            }
        }

        public static void  flitrarporpiloto(DataGridView dgv, string pil)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = db.PAGOAPILOTO.Where(x => x.PILOTO.Contains(pil)).Select(x => new
                {
                    x.IDPAGO,
                    x.PILOTO,
                    x.FECHAREGISTRO,
                    x.NODOCUMENTO,
                    x.QUINCENA,
                    x.VIATICOS,
                    x.ENTRADAS,
                    x.PARQUEO,
                    x.DESCARGA,
                    x.OTROS,
                    TOTALVIAJES = x.TOTAL,
                    TOTAL = (x.QUINCENA + x.VIATICOS + x.ENTRADAS + x.ENTRADAS + x.PARQUEO + x.DESCARGA + x.OTROS + x.TOTAL)
                });
                dgv.DataSource = consulta.ToList();
            }
        }

        public static bool devolverdatospiloto(string codigo)
        {
            bool resp = false;
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var lst = from pil in db.PILOTO                          
                          where (pil.CODIGO.Equals(codigo)) && pil.ESTADO == true
                          select new
                          {                              
                              IDPILOTO = pil.ID,
                              pil.NOMBRE,
                              pil.CODIGO
                          };

                if (lst.Count() > 0)
                {
                    foreach (var item in lst)
                    {                        
                        BL_Pilotos.idpiloto = int.Parse(item.IDPILOTO.ToString());
                        BL_Pilotos.codigopiloto = item.CODIGO;
                        BL_Pilotos.nombrepiloto = item.NOMBRE;
                    }
                    resp = true;
                }

            }
            return resp;
        }

        public static void llenardgvpilotos(DataGridView dgv)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = db.PILOTO.Where(x => x.ESTADO == true).Select(x => new { x.ID, x.CODIGO, x.NOMBRE, x.TELEFONO, x.DOMICILIO });
                dgv.DataSource = consulta.ToList();
            }
        }

        public static void llenarcmbpilotos(ComboBox cmb)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = db.PILOTO.Where(x => x.ESTADO == true).Select(x => new { x.ID, x.NOMBRE });
                cmb.DataSource = consulta.ToList();
                cmb.DisplayMember = "NOMBRE";
                cmb.ValueMember = "ID";
            }
        }

        public static void agregarnuevopiloto(PILOTO piloto)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                db.PILOTO.Add(piloto);
                db.SaveChanges();
            }


        }

        public static bool devolvernombrepiloto(string codigo)
        {
            bool resp = false;
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var lst = from piloto in db.PILOTO
                          where (piloto.CODIGO.Equals(codigo)) && piloto.ESTADO == true
                          select piloto;

                if (lst.Count() > 0)
                {
                    foreach (var item in lst)
                    {
                        nombrepiloto = item.NOMBRE;
                        idpiloto= item.ID;

                    }
                    resp = true;
                }

            }
            return resp;
        }

        public static void actualizarpiloto(int id, string codigo, string nombre, string telefono, string domicilio)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from piloto in db.PILOTO
                               where piloto.ID.Equals(id)
                               select piloto;

                foreach (var item in consulta)
                {
                    item.CODIGO = codigo;
                    item.NOMBRE = nombre;
                    item.TELEFONO = telefono;
                    item.DOMICILIO = domicilio;

                }

                db.SaveChanges();
                MessageBox.Show("Registro actualizado correctamente", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public static void dardebajapiloto(int id)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from piloto in db.PILOTO
                               where piloto.ID.Equals(id)
                               select piloto;

                foreach (var item in consulta)
                {
                    item.ESTADO = false;
                }

                db.SaveChanges();
                MessageBox.Show("Se ha dado de baja al piloto", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static bool agregarpagoapiloto(PAGOAPILOTO pago)
        {
            bool estado = false; 
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.PAGOAPILOTO.Add(pago);
                    db.SaveChanges();
                }
                estado = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // or log to file, etc.
                throw; // re-throw the exception if you want it to continue up the stack
            }

            return estado;
        }
    }
}
