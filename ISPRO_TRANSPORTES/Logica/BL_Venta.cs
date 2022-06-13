using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class BL_Venta
    {
        public static bool agregarventa(VENTA compra)
        {
            bool estado = false;
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.VENTA.Add(compra);
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

        public static void llenardgvporfecha(DataGridView dgv, DateTime ini, DateTime final)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from compras in db.VENTA
                               where compras.FECHA >= ini && compras.FECHA <= final
                               orderby compras.FECHA descending
                               select new
                               {
                                   compras.ID,
                                   compras.FECHA,
                                   compras.FACTURA,
                                   compras.TIPODOCUMENTO,
                                   compras.NIT,
                                   compras.PROVEEDOR,
                                   compras.CUENTACONTABLE,
                                   compras.TOTAL,
                                   compras.PRECIONETO,
                                   compras.IVA,
                                   compras.RETENCION
                               };

                dgv.DataSource = consulta.ToList();
            }
        }
        public static void llenardgvpormes(DataGridView dgv, int mes, int anio)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from compras in db.VENTA
                               where compras.FECHA.Year.Equals(anio) && compras.FECHA.Month.Equals(mes)
                               orderby compras.FECHA descending
                               select new
                               {
                                   compras.ID,
                                   compras.FECHA,
                                   compras.FACTURA,
                                   compras.TIPODOCUMENTO,
                                   compras.NIT,
                                   compras.PROVEEDOR,
                                   compras.CUENTACONTABLE,
                                   compras.TOTAL,
                                   compras.PRECIONETO,
                                   compras.IVA,
                                   compras.RETENCION
                               };

                dgv.DataSource = consulta.ToList();
            }
        }

        public static void llenardgv(DataGridView dgv)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from compras in db.VENTA
                               select new
                               {
                                   compras.ID,
                                   compras.FECHA,
                                   compras.FACTURA,
                                   compras.TIPODOCUMENTO,
                                   compras.NIT,
                                   compras.PROVEEDOR,
                                   compras.CUENTACONTABLE,
                                   compras.TOTAL,
                                   compras.PRECIONETO,
                                   compras.IVA,
                                   compras.RETENCION
                               };

                dgv.DataSource = consulta.ToList();
            }
        }
    }
}
