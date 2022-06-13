using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;
using System.Data.Entity;

namespace Logica
{
    public class BL_Viajes
    {
        public static long correlativo { get; set; }


        public static void actualizarviaje3(long correl, decimal precio)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               where viaje.CORRELATIVO.Equals(correl) && viaje.ESTADO == true
                               select viaje;

                foreach (var item in consulta)
                {
                    item.PRECIOVIAJE = precio;
                }

                try
                {
                    db.SaveChanges();
                    //MessageBox.Show("Se elimino el viaje", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {

                    MessageBox.Show("4" + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        public static void dardebajaviaje(long correl)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               where viaje.CORRELATIVO.Equals(correl) && viaje.ESTADO == true
                               select viaje;

                foreach (var item in consulta)
                {
                    item.ESTADO = false;
                }

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Se elimino el viaje", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                    MessageBox.Show("No se pudo eliminar el registro", "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        public static void actualizarviaje(long correl, long pago, decimal pagopiloto)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               where viaje.CORRELATIVO.Equals(correl) && viaje.ESTADO == true
                               select viaje;

                foreach (var item in consulta)
                {
                    item.NOPAGO = pago;
                    item.PAGADO = true;
                    item.PAGOPILOTO = pagopiloto;
                }

                try
                {
                    db.SaveChanges();
                    //MessageBox.Show("Se elimino el viaje", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {

                    MessageBox.Show("4"+e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public static void actualizarviaje2(string correl, long preliq)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               where viaje.NOVIAJE.Equals(correl) && viaje.ESTADO == true
                               select viaje;

                foreach (var item in consulta)
                {
                    item.PRELIQUIDACION = preliq;
                    item.FACTURADO = true;
                    
                }

                try
                {
                    db.SaveChanges();
                    //MessageBox.Show("Se elimino el viaje", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {

                    MessageBox.Show("4" + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public static bool obtenerdespachado(long correl)
        {
            bool despachado = false;

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               where viaje.CORRELATIVO.Equals(correl) && viaje.DESPACHADO == true
                               select viaje;

                if (consulta.Count() > 0)
                {
                    despachado = true;
                }

            }

                return despachado;
        }

        //Determina si ya tiene un documento de pago
        public static bool obtenerpagado(long correl)
        {
            bool pagado = false;

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               where viaje.CORRELATIVO.Equals(correl) && viaje.PAGADO == true
                               select viaje;

                if (consulta.Count() > 0)
                {
                    pagado = true;
                }

            }

            return pagado;
        }

        public static void agregarnuevoviaje(VIAJE viaje)
        {
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.VIAJE.Add(viaje);
                    db.SaveChanges();
                }
                MessageBox.Show("Viaje registrado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static void agregarvale(VALECOMBUSTIBLE vale)
        {
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.VALECOMBUSTIBLE.Add(vale);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {


            }
        }

        public static void agregarcheque(PAGOAPILOTO cheque)
        {
            try
            {
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    db.PAGOAPILOTO.Add(cheque);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public static void llenardgvviajes(DataGridView datagrid)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID                               
                               where viaje.ESTADO == true && viaje.CLIENTE == "CEMEX"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE

                               };

                datagrid.DataSource = consulta.ToList();
            }
        }


        public static void llenardgvviajesregional(DataGridView datagrid)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && viaje.CLIENTE == "REGIONAL"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE

                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void llenardgvviajeswp(DataGridView datagrid)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && viaje.CLIENTE == "WP"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE

                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void llenardgvviajes2(DataGridView datagrid)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               //join vale in db.VALECOMBUSTIBLE
                               //on viaje.CORRELATIVO equals vale.VIAJE
                               where viaje.ESTADO == true && viaje.PAGADO != true //esto verificalo
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE,
                                   //vale.NOVALE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxcliente(DataGridView datagrid, string cli)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                              
                               where viaje.ESTADO == true && viaje.DESTINO.Contains(cli) && viaje.CLIENTE == "CEMEX"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxclientereg(DataGridView datagrid, string cli)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID

                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID

                               where viaje.ESTADO == true && viaje.DESTINO.Contains(cli) && viaje.CLIENTE == "REGIONAL"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        //WP
        public static void filtrarxclientewp(DataGridView datagrid, string cli)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID

                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID

                               where viaje.ESTADO == true && viaje.DESTINO.Contains(cli) && viaje.CLIENTE == "WP"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }
        public static void filtrarxviaje(DataGridView datagrid, string cli)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID

                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               //join vale in db.VALECOMBUSTIBLE
                               //on viaje.CORRELATIVO equals vale.VIAJE
                               where viaje.ESTADO == true && viaje.NOVIAJE.Equals(cli)
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE,
                                   //vale.NOVALE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxpiloto(DataGridView datagrid, string pil)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               
                               where viaje.ESTADO == true && camion.PLACA.Contains(pil) && viaje.CLIENTE == "CEMEX"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxnoviaje(DataGridView datagrid, string pil)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID

                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID

                               where viaje.ESTADO == true && viaje.NOVIAJE.Contains(pil) && viaje.CLIENTE == "CEMEX"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxnoviajewp(DataGridView datagrid, string pil)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID

                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID

                               where viaje.ESTADO == true && viaje.NOVIAJE.Contains(pil) && viaje.CLIENTE == "WP"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxnoviajereg(DataGridView datagrid, string pil)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID

                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID

                               where viaje.ESTADO == true && viaje.NOVIAJE.Contains(pil) && viaje.CLIENTE == "REGIONAL"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxpilotoreg(DataGridView datagrid, string pil)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID

                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID

                               where viaje.ESTADO == true && camion.PLACA.Contains(pil) && viaje.CLIENTE == "REGIONAL"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        //WP
        public static void filtrarxpilotowp(DataGridView datagrid, string pil)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID

                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID

                               where viaje.ESTADO == true && camion.PLACA.Contains(pil) && viaje.CLIENTE == "WP"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxusuario(DataGridView datagrid, string us)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && user.CODIGO.Contains(us) && viaje.CLIENTE == "CEMEX"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxusuarioreg(DataGridView datagrid, string us)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && user.CODIGO.Contains(us) && viaje.CLIENTE == "REGIONAL"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarxusuariowp(DataGridView datagrid, string us)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && user.CODIGO.Contains(us) && viaje.CLIENTE == "WP"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarpormes(DataGridView datagrid, int mes, int anio)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && (viaje.FECHAREGISTRO.Year.Equals(anio) && viaje.FECHAREGISTRO.Month.Equals(mes)) && viaje.CLIENTE == "CEMEX"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarpormesreg(DataGridView datagrid, int mes, int anio)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && (viaje.FECHAREGISTRO.Year.Equals(anio) && viaje.FECHAREGISTRO.Month.Equals(mes)) && viaje.CLIENTE == "REGIONAL"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarpormesregwp(DataGridView datagrid, int mes, int anio)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && (viaje.FECHAREGISTRO.Year.Equals(anio) && viaje.FECHAREGISTRO.Month.Equals(mes)) && viaje.CLIENTE == "WP"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarporfechas(DataGridView datagrid, DateTime inicio, DateTime final)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && (viaje.FECHAREGISTRO >= inicio && viaje.FECHAREGISTRO <= final) && viaje.CLIENTE == "CEMEX"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarporfechasreg(DataGridView datagrid, DateTime inicio, DateTime final)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && (viaje.FECHAREGISTRO >= inicio && viaje.FECHAREGISTRO <= final) && viaje.CLIENTE == "REGIONAL"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarporfechaswp(DataGridView datagrid, DateTime inicio, DateTime final)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && (viaje.FECHAREGISTRO >= inicio && viaje.FECHAREGISTRO <= final) && viaje.CLIENTE == "WP"
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarporfechas2(DataGridView datagrid, DateTime inicio, DateTime final)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               join vale in db.VALECOMBUSTIBLE
                               on viaje.CORRELATIVO equals vale.VIAJE
                               where viaje.ESTADO == true && viaje.PAGADO != true && (viaje.FECHAREGISTRO >= inicio.Date && viaje.FECHAREGISTRO <= final.Date)
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE,
                                   vale.NOVALE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        //Filtrar por placa y fechas
        public static void filtrarporfechasyplaca(DataGridView datagrid, DateTime inicio, DateTime final, string placa)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               where viaje.ESTADO == true && (viaje.FECHAREGISTRO >= inicio && viaje.FECHAREGISTRO <= final && camion.PLACA.Equals(placa))
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarporfechasyplaca2(DataGridView datagrid, DateTime inicio, DateTime final, string placa)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               join user in db.USUARIO
                               on viaje.USUARIO equals user.ID
                               join vale in db.VALECOMBUSTIBLE
                               on viaje.CORRELATIVO equals vale.VIAJE
                               where viaje.ESTADO == true && viaje.PAGADO != true && viaje.FECHAREGISTRO >= inicio.Date && viaje.FECHAREGISTRO <= final.Date && piloto.CODIGO.Equals(placa)
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   Piloto = piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                   viaje.CANTDIESEL,
                                   viaje.PRECIOVIAJE,
                                   Usuario = user.CODIGO,
                                   viaje.REGISTRADO,
                                   viaje.DESPACHADO,
                                   viaje.PAGADO,
                                   viaje.FACTURADO,
                                   viaje.TNMOVIDAS,
                                   viaje.KILOMETRAJE,
                                   vale.NOVALE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        //mostrar viajes de un pago especifico
        public static void filtrarxpago(DataGridView datagrid, long pago)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from viaje in db.VIAJE                               
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID                               
                               where viaje.ESTADO == true && viaje.NOPAGO == pago
                               orderby viaje.FECHAREGISTRO descending
                               select new
                               {
                                   viaje.CORRELATIVO,
                                   viaje.NOVIAJE,
                                   viaje.FOLIO,
                                   viaje.FECHAREGISTRO,
                                   viaje.DESTINO,
                                   viaje.ORIGEN,
                                   viaje.FECHAENTREGA,
                                   
                                   camion.PLACA,
                                   viaje.PAGOPILOTO,
                                                                      
                                   //vale.NOVALE
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }
    }
}
