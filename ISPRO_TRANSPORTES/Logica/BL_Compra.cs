using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;
namespace Logica
{
    public class BL_Compra
    {
        public static void llenardgv(DataGridView dgv)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from compras in db.COMPRA2
                               select new
                               {
                                   compras.ID,
                                   compras.FECHA,
                                   compras.NOFACTURA,
                                   compras.TIPODOCUMENTO,
                                   compras.NIT,
                                   compras.PROVEEDOR,
                                   compras.CUENTACONTABLE,
                                   compras.GALONAJE,
                                   compras.IDP,
                                   compras.TOTALFACTURA,
                                   compras.PRECIONETO,
                                   compras.IVA,
                                   compras.TOTAL
                               };

                dgv.DataSource = consulta.ToList();
            }
        }

        public static void llenardgvpormes(DataGridView dgv, int mes, int anio)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from compras in db.COMPRA2
                               where compras.FECHA.Year.Equals(anio) && compras.FECHA.Month.Equals(mes)
                               orderby compras.FECHA descending
                               select new
                               {
                                   compras.ID,
                                   compras.FECHA,
                                   compras.NOFACTURA,
                                   compras.TIPODOCUMENTO,
                                   compras.NIT,
                                   compras.PROVEEDOR,
                                   compras.CUENTACONTABLE,
                                   compras.GALONAJE,
                                   compras.IDP,
                                   compras.TOTALFACTURA,
                                   compras.PRECIONETO,
                                   compras.IVA,
                                   compras.TOTAL
                               };

                dgv.DataSource = consulta.ToList();
            }
        }

        public static void llenardgvporfecha(DataGridView dgv, DateTime ini, DateTime final)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from compras in db.COMPRA2
                               where compras.FECHA >= ini && compras.FECHA <= final
                               orderby compras.FECHA descending
                               select new
                               {
                                   compras.ID,
                                   compras.FECHA,
                                   compras.NOFACTURA,
                                   compras.TIPODOCUMENTO,
                                   compras.NIT,
                                   compras.PROVEEDOR,
                                   compras.CUENTACONTABLE,
                                   compras.GALONAJE,
                                   compras.IDP,
                                   compras.TOTALFACTURA,
                                   compras.PRECIONETO,
                                   compras.IVA,
                                   compras.TOTAL
                               };

                dgv.DataSource = consulta.ToList();
            }
        }
        public static bool agregarcompra(COMPRA compra)
        {
            bool estado = false;
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.COMPRA.Add(compra);
                    db.SaveChanges();
                }
                //MessageBox.Show("Se registró la compra. Ingrese los detalles", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                estado = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

            return estado;

        }

        public static bool agregarcompra2(COMPRA2 compra)
        {
            bool estado = false;
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.COMPRA2.Add(compra);
                    db.SaveChanges();
                }
                //MessageBox.Show("Se registró la compra. Ingrese los detalles", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                estado = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return estado;

        }

        public static void llenarcmbformapago(ComboBox cmb)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = db.FORMAPAGO.Select(x => new { x.ID, x.NOMBRE });
                cmb.DataSource = consulta.ToList();
                cmb.DisplayMember = "NOMBRE";
                cmb.ValueMember = "ID";
            }
        }

        public static void agregardetalles(COMPRADETA detalle)
        {
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.COMPRADETA.Add(detalle);
                    db.SaveChanges();
                }
                //MessageBox.Show("Se registró la compra. Ingrese los detalles", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static long obtenerultimacompra()
        {
            long ultimacompra;
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                ultimacompra = db.COMPRA.Max(x => x.NOCOMPRA);
            }

            return ultimacompra;
        }
    }
}
