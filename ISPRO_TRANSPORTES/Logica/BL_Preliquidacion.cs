using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;

namespace Logica
{
    public class BL_Preliquidacion
    {
        public static bool existe(long preli)
        {
            bool exis = false;
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                bool ex = db.PRELIQUIDACION.Any(x => x.PRELIQUIDACION1 == preli);
                exis = ex;
            }
            return exis;
        }

        public static bool agregarpreliquidacion(PRELIQUIDACION preliq)
        {
            bool status = false;

            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.PRELIQUIDACION.Add(preliq);
                    db.SaveChanges();
                    status = true;
                }
                MessageBox.Show("La preliquidación se guardó correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("1 " + e.Message);                                
            }

            return status;
        }

        public static void llenardgv(DataGridView dgv)
        {          
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    var consulta = from preli in db.PRELIQUIDACION
                                   select new
                                   {
                                       preli.PRELIQUIDACION1,
                                       preli.FECHA,
                                       preli.FACTURA,
                                       preli.DESCRIPCION
                                   };

                    dgv.DataSource = consulta.ToList();
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("1 " + e.Message);
            }

           
        }
    }
}
