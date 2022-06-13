using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;

namespace Logica
{
    public class BL_Vales
    {
        public static long obtenernovale(long correl)
        {
            long viaje = 0;

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vales in db.VALECOMBUSTIBLE
                               where vales.VIAJE == correl
                               select vales;

                foreach (var item in consulta)
                {
                    viaje = long.Parse(item.NOVALE.ToString());
                }
            }

            return viaje;
        }

        //Get preliquidacion
        public static long obtenernopreliq(long correl)
        {
            long viaje = 0;

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vales in db.VIAJE
                               where vales.CORRELATIVO == correl
                               select vales;

                foreach (var item in consulta)
                {
                    viaje = long.Parse(item.PRELIQUIDACION.ToString());
                }
            }

            return viaje;
        }

        //Obtiene el monto del vale
        public static decimal obtenermontovale(long correl)
        {
            decimal viaje = 0;

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vales in db.VALECOMBUSTIBLE
                               where vales.VIAJE == correl
                               select vales;

                foreach (var item in consulta)
                {
                    viaje = decimal.Parse(item.MONTO.ToString());
                }
            }

            return viaje;
        }

        //Obtiene la fecha del vale
        public static string obtenerfechavale(long correl)
        {
            string viaje = "";

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vales in db.VALECOMBUSTIBLE
                               where vales.VIAJE == correl
                               select vales;

                foreach (var item in consulta)
                {
                    viaje = string.Format("{0:dd/MM/yyyy}", item.FECHA);
                }
            }

            return viaje;
        }

        //Obtiene el numero de cheque
        public static string obtenerpago(long correl)
        {
            string viaje = "";

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vales in db.VIAJE                               
                               join pago in db.PAGOAPILOTO
                               on vales.NOPAGO equals pago.IDPAGO
                               where vales.CORRELATIVO == correl
                               select new
                               {
                                   pago.NODOCUMENTO
                               };

                foreach (var item in consulta)
                {
                    viaje = item.NODOCUMENTO;
                }
            }

            return viaje;
        }
        public static decimal obtenerpagoimporte(long correl)
        {
            decimal viaje = 0;

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vales in db.VIAJE
                               join pago in db.PAGOAPILOTO
                               on vales.NOPAGO equals pago.IDPAGO
                               where vales.CORRELATIVO == correl
                               select new
                               {
                                   vales.PAGOPILOTO
                               };

                foreach (var item in consulta)
                {
                    viaje = Convert.ToDecimal(item.PAGOPILOTO);
                }
            }

            return viaje;
        }


        public static string obtenerfecha(long correl)
        {
            string viaje = "";

            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vales in db.VIAJE
                               join pago in db.PAGOAPILOTO
                               on vales.NOPAGO equals pago.IDPAGO
                               where vales.CORRELATIVO == correl
                               select new
                               {
                                   pago.FECHAREGISTRO
                               };

                foreach (var item in consulta)
                {
                    viaje = string.Format("{0:dd/MM/yyyy}", item.FECHAREGISTRO);
                }
            }

            return viaje;
        }
        //public static decimal obtenermontocheque(long correl)
        //{
        //    decimal viaje = 0;

        //    using (TRANSPORTEEntities db = new TRANSPORTEEntities())
        //    {
        //        var consulta = from vales in db.PAGOAPILOTO
        //                       where vales.VIAJE == correl
        //                       select vales;

        //        foreach (var item in consulta)
        //        {
        //            viaje = decimal.Parse(item.IMPORTE.ToString());
        //        }
        //    }

        //    return viaje;
        //}

        //public static string obtenerfechacheque(long correl)
        //{
        //    string fecha = "";

        //    using (TRANSPORTEEntities db = new TRANSPORTEEntities())
        //    {
        //        var consulta = from vales in db.PAGOAPILOTO
        //                       where vales.VIAJE == correl
        //                       select vales;

        //        foreach (var item in consulta)
        //        {
        //            fecha = string.Format("{0:dd/MM/yyyy}", item.FECHAREGISTRO.ToString());
        //        }
        //    }

        //    return fecha;
        //}

        public static void llenardgvviajes(DataGridView datagrid)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vale in db.VALECOMBUSTIBLE
                               join viaje in db.VIAJE
                               on vale.VIAJE equals viaje.CORRELATIVO
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               where vale.LOCALIDAD == true
                               select new
                               {
                                   viaje.NOVIAJE,
                                   vale.NOVALE,
                                   piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.DESTINO,
                                   vale.FECHA,
                                   vale.MONTO
                                                                      
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarporplaca(DataGridView datagrid, string placa)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vale in db.VALECOMBUSTIBLE
                               join viaje in db.VIAJE
                               on vale.VIAJE equals viaje.CORRELATIVO
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               where camion.PLACA.Contains(placa) 
                               select new
                               {
                                   viaje.NOVIAJE,
                                   vale.NOVALE,
                                   piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.DESTINO,
                                   vale.FECHA,
                                   vale.MONTO
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarporplacayfecha(DataGridView datagrid, string placa, DateTime fechainicio, DateTime fechafinal)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vale in db.VALECOMBUSTIBLE
                               join viaje in db.VIAJE
                               on vale.VIAJE equals viaje.CORRELATIVO
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               where camion.PLACA.Contains(placa) && (vale.FECHA >= fechainicio && vale.FECHA <= fechafinal) && vale.LOCALIDAD == true
                               select new
                               {
                                   viaje.NOVIAJE,
                                   vale.NOVALE,
                                   piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.DESTINO,
                                   vale.FECHA,
                                   vale.MONTO
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarpordestino(DataGridView datagrid, string destino)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vale in db.VALECOMBUSTIBLE
                               join viaje in db.VIAJE
                               on vale.VIAJE equals viaje.CORRELATIVO
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               where viaje.DESTINO.Contains(destino)
                               select new
                               {
                                   viaje.NOVIAJE,
                                   vale.NOVALE,
                                   piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.DESTINO,
                                   vale.FECHA,
                                   vale.MONTO
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarpormes(DataGridView datagrid, int mes, int anio)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vale in db.VALECOMBUSTIBLE
                               join viaje in db.VIAJE
                               on vale.VIAJE equals viaje.CORRELATIVO
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               where vale.FECHA.Year.Equals(anio) && vale.FECHA.Month.Equals(mes)
                               select new
                               {
                                   viaje.NOVIAJE,
                                   vale.NOVALE,
                                   piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.DESTINO,
                                   vale.FECHA,
                                   vale.MONTO
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

        public static void filtrarporfecha(DataGridView datagrid, DateTime inicio, DateTime final)
        {
            using (TRANSPORTEEntities db = new TRANSPORTEEntities())
            {
                var consulta = from vale in db.VALECOMBUSTIBLE
                               join viaje in db.VIAJE
                               on vale.VIAJE equals viaje.CORRELATIVO
                               join piloto in db.PILOTO
                               on viaje.PILOTO equals piloto.ID
                               join camion in db.CAMION
                               on viaje.CAMION equals camion.ID
                               where vale.FECHA >= inicio.Date && vale.FECHA <= final.Date && vale.LOCALIDAD == true
                               select new
                               {
                                   viaje.NOVIAJE,
                                   vale.NOVALE,
                                   piloto.NOMBRE,
                                   camion.PLACA,
                                   viaje.DESTINO,
                                   vale.FECHA,
                                   vale.MONTO
                               };

                datagrid.DataSource = consulta.ToList();
            }
        }

    }
}
