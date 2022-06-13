using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;

namespace Logica
{
    public class BL_Categoria
    {
        public static void llenardgv(DataGridView dgv)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from cat in db.CATEGORIA
                               where cat.ESTADO == true
                               select new
                               {
                                   cat.ID,
                                   cat.NOMBRE
                               };

                dgv.DataSource = consulta.ToList();
            }
        }
        public static void llenarcmb(ComboBox combo)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from cat in db.CATEGORIA
                               where cat.ESTADO == true
                               select new
                               {
                                   cat.ID,
                                   cat.NOMBRE
                               };

                combo.DataSource = consulta.ToList();
                combo.ValueMember = "ID";
                combo.DisplayMember = "NOMBRE";
            }
        }


        public static bool registrarcat( CATEGORIA cate)
        {
            bool success = false;

            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.CATEGORIA.Add(cate);
                    db.SaveChanges();
                }

                MessageBox.Show("Se registró la categoría correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

            return success;
        }

        public static bool dardebajacategoria(int id)
        {
            bool success = false;

            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    var consulta = from cat in db.CATEGORIA
                                   where cat.ID.Equals(id)
                                   select cat;

                    foreach (var item in consulta)
                    {
                        item.ESTADO = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return success;
        }

        public static void actualizarcat(short id, string nombre)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from cat in db.CATEGORIA
                               where cat.ID.Equals(id)
                               select cat;

                foreach (var item in consulta)
                {
                    item.NOMBRE = nombre;
                }

                db.SaveChanges();
                MessageBox.Show("Registro actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
