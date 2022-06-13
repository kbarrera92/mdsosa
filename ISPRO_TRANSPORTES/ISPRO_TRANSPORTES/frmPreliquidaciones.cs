using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Entidades;

namespace ISPRO_TRANSPORTES
{
    public partial class frmPreliquidaciones : Form
    {
        DataSet ds = new dsReportes();
        public frmPreliquidaciones()
        {
            InitializeComponent();
        }

        private void frmPreliquidaciones_Load(object sender, EventArgs e)
        {
            BL_Preliquidacion.llenardgv(dataGridView1);
        }
        long preliq = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            preliq = long.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            MessageBox.Show(preliq.ToString());
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
                               where viaje.ESTADO == true && viaje.PRELIQUIDACION == preliq
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
                dataGridView2.DataSource = consulta.ToList();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new dsReportes();
            llenarDT();
            if (dataGridView1.Rows.Count > 0)
            {
                rptViajes informe = new rptViajes();
                informe.SetDataSource(ds.Tables["dtreporteviajes"]);
                informe.SetParameterValue("preliquidacion", "Preliquidación: "+preliq.ToString());
                frmVerReportes reporte = new frmVerReportes();
                reporte.crystalReportViewer1.ReportSource = informe;
                //MessageBox.Show(ds.Tables["dtreporteviajes"].Rows.Count.ToString());
                reporte.Show();
            }
            else
            {
                MessageBox.Show("No hay ningún dato para el reporte", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void llenarDT()
        {
            ds = new dsReportes();
            DataTable dt;

            dt = ds.Tables["dtreporteviajes"];
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                DataRow drdesxcli = ds.Tables["dtreporteviajes"].NewRow();
                drdesxcli["noviaje"] = dataGridView2.Rows[i].Cells[1].Value.ToString();
                drdesxcli["folio"] = dataGridView2.Rows[i].Cells[2].Value.ToString();
                drdesxcli["fecha"] = dataGridView2.Rows[i].Cells[3].Value;
                drdesxcli["placa"] = dataGridView2.Rows[i].Cells[8].Value.ToString();
                drdesxcli["destino"] = dataGridView2.Rows[i].Cells[4].Value.ToString();
                drdesxcli["valor"] = decimal.Parse(dataGridView2.Rows[i].Cells[11].Value.ToString());
                ds.Tables["dtreporteviajes"].Rows.Add(drdesxcli);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
