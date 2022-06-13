using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;

namespace Logica
{
    public class BL_Insumos
    {

        public static decimal getinsumo(int insumo)
        {
            decimal stock = 0;

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from insu in db.INSUMO
                            where insu.ESTADO == true && insu.ID.Equals(insumo)
                            select insu.EXISTENCIA;

                foreach (var item in consulta)
                {
                    stock = decimal.Parse(item.Value.ToString());
                }
            }

            return stock;
        }

        public static void llenardgvinsumos(DataGridView datagrid)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from insumo in db.INSUMO
                               join cat in db.CATEGORIA
                               on insumo.CATEGORIA equals cat.ID
                               where insumo.ESTADO == true
                               select new
                               {
                                   insumo.ID,
                                   insumo.DESCRIPCION,
                                   insumo.COSTO,
                                   insumo.PRECIO,
                                   cat.NOMBRE,
                                   insumo.EXISTENCIA
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static bool registrarinsumo(INSUMO insumo)
        {
            bool success = false;

            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.INSUMO.Add(insumo);
                    db.SaveChanges();
                }

                MessageBox.Show("Se registró el insumo correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return success;
        }


        public static bool dardebajainsumo(int id)
        {
            bool success = false;

            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    var consulta = from cat in db.INSUMO
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

        public static void actualizarinsumo(int id, string nombre, decimal costo, decimal precio, short cate, decimal stock)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from cat in db.INSUMO
                               where cat.ID.Equals(id)
                               select cat;

                foreach (var item in consulta)
                {
                    item.DESCRIPCION = nombre;
                    item.COSTO = costo;
                    item.PRECIO = precio;
                    item.CATEGORIA = cate;
                    item.EXISTENCIA = stock;
                }

                db.SaveChanges();
                MessageBox.Show("Registro actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
