using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class BL_Camiones
    {
        public static string marcacamion, modelocamion;
        public static int idcamion;
        public static void llenardgvcamiones(DataGridView dgv)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from camiones in db.CAMION
                               join pil in db.PILOTO
                               on camiones.PILOTO equals pil.ID
                               where camiones.ESTADO == true
                               select new
                               {
                                   camiones.ID,
                                   camiones.PLACA,
                                   camiones.MARCA,
                                   camiones.MODELO,
                                   pil.NOMBRE
                               };
                dgv.DataSource = consulta.ToList();
            }
        }

        public static void agregarnuevousuario(CAMION camion)
        {

            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.CAMION.Add(camion);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {


            }
        }

        public static bool devolverdatoscamion(string placa)
        {
            bool resp = false;
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var lst = from camion in db.CAMION
                          join pil in db.PILOTO
                          on camion.PILOTO equals pil.ID
                          where (camion.PLACA.Equals(placa)) && camion.ESTADO == true
                          select new
                          {
                              camion.ID,
                              camion.PLACA,
                              camion.MARCA,
                              camion.MODELO,
                              IDPILOTO = pil.ID,
                              pil.NOMBRE,
                              pil.CODIGO
                          };

                if (lst.Count() > 0)
                {
                    foreach (var item in lst)
                    {
                        marcacamion = item.MARCA;
                        modelocamion = item.MODELO;
                        idcamion = item.ID;
                        BL_Pilotos.idpiloto = int.Parse(item.IDPILOTO.ToString());
                        BL_Pilotos.codigopiloto = item.CODIGO;
                        BL_Pilotos.nombrepiloto = item.NOMBRE;
                    }
                    resp = true;
                }

            }
            return resp;
        }

        public static void actualizarcamion(int id, string placa, string marca, string modelo)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from camion in db.CAMION
                               where camion.ID.Equals(id)
                               select camion;

                foreach (var item in consulta)
                {
                    item.PLACA = placa;
                    item.MARCA = marca;
                    item.MODELO = modelo;
                    
                }

                db.SaveChanges();
                MessageBox.Show("Registro actualizado correctamente", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public static void dardebajacamion(int id)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from camion in db.CAMION
                               where camion.ID.Equals(id)
                               select camion;

                foreach (var item in consulta)
                {
                    item.ESTADO = false;
                }

                db.SaveChanges();
                MessageBox.Show("Se ha dado de baja al camión", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
