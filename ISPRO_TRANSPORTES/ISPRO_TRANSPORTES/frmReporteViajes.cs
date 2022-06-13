using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISPRO_TRANSPORTES
{
    public partial class frmReporteViajes : Form
    {
        DataSet ds = new dsReportes();
        public frmReporteViajes()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BL_Pilotos.devolverdatospiloto(txtplacacamion.Text.Trim()))
                {
                    txtnombrepiloto.Text = BL_Pilotos.nombrepiloto;
                }
            }
        }

        private void frmReporteViajes_Load(object sender, EventArgs e)
        {
            BL_Viajes.llenardgvviajes2(dataGridView1);
            formateardgv(dataGridView1);
        }

        private void formateardgv(DataGridView datagrid)
        {
            datagrid.Columns[0].Width = 100;
            datagrid.Columns[0].HeaderText = "Correlativo";

            datagrid.Columns[1].Width = 100;
            datagrid.Columns[1].HeaderText = "No. de Viaje";

            datagrid.Columns[2].Width = 100;
            datagrid.Columns[2].HeaderText = "Folio";

            datagrid.Columns[3].Width = 100;
            datagrid.Columns[3].HeaderText = "Fecha registro";

            datagrid.Columns[4].Width = 250;
            datagrid.Columns[4].HeaderText = "Destino";

            datagrid.Columns[5].Width = 250;
            datagrid.Columns[5].HeaderText = "Origen";

            datagrid.Columns[6].Width = 100;
            datagrid.Columns[6].HeaderText = "Fecha entrega";

            datagrid.Columns[7].Width = 200;
            datagrid.Columns[7].HeaderText = "Piloto";

            datagrid.Columns[8].Width = 100;
            datagrid.Columns[8].HeaderText = "Placa";

            datagrid.Columns[9].Width = 100;
            datagrid.Columns[9].HeaderText = "Pago piloto";

            datagrid.Columns[10].Width = 100;
            datagrid.Columns[10].HeaderText = "Cant. Diesel";

            datagrid.Columns[11].Width = 100;
            datagrid.Columns[11].HeaderText = "Precio viaje";

            datagrid.Columns[12].Width = 250;
            datagrid.Columns[12].HeaderText = "Usuario";

            datagrid.Columns[13].Width = 100;
            datagrid.Columns[13].HeaderText = "Registrado";

            datagrid.Columns[14].Width = 100;
            datagrid.Columns[14].HeaderText = "Despachado";

            datagrid.Columns[15].Width = 100;
            datagrid.Columns[15].HeaderText = "Pagado";

            datagrid.Columns[16].Width = 100;
            datagrid.Columns[16].HeaderText = "Facturado";

            datagrid.Columns[17].Width = 100;
            datagrid.Columns[17].HeaderText = "TN Movidas";

            datagrid.Columns[18].Width = 100;
            datagrid.Columns[18].HeaderText = "Kilometraje";
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                BL_Viajes.filtrarporfechas2(dataGridView1, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else
            {
                BL_Viajes.filtrarporfechasyplaca2(dataGridView1, dateTimePicker1.Value, dateTimePicker2.Value, txtplacacamion.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BL_Viajes.llenardgvviajes2(dataGridView1);
            formateardgv(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds = new dsReportes();
            llenarDT();
            if (dataGridView1.Rows.Count > 0)
            {
                rptViajes informe = new rptViajes();
                informe.SetDataSource(ds.Tables["dtreporteviajes"]);
                informe.SetParameterValue("preliquidacion", "");
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataRow drdesxcli = ds.Tables["dtreporteviajes"].NewRow();
                drdesxcli["noviaje"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                drdesxcli["folio"] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                drdesxcli["fecha"] = dataGridView1.Rows[i].Cells[3].Value;
                drdesxcli["placa"] = dataGridView1.Rows[i].Cells[8].Value.ToString();
                drdesxcli["destino"] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                drdesxcli["valor"] = decimal.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
                ds.Tables["dtreporteviajes"].Rows.Add(drdesxcli);
            }
        }

        private void llenarDT2()
        {
            ds = new dsReportes();
            DataTable dt;

            dt = ds.Tables["dthojapago"];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataRow drdesxcli = ds.Tables["dthojapago"].NewRow();
                drdesxcli["FECHA"] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                drdesxcli["NOVIAJE"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                drdesxcli["DESTINO"] = dataGridView1.Rows[i].Cells[5].Value.ToString() + "/" + dataGridView1.Rows[i].Cells[4].Value.ToString();
                drdesxcli["SACOS"] = decimal.Parse(dataGridView1.Rows[i].Cells[17].Value.ToString()) * 23.53M;
                drdesxcli["VALORVIAJE"] = decimal.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
                drdesxcli["NOVALE"] = long.Parse(dataGridView1.Rows[i].Cells[19].Value.ToString());
                ds.Tables["dthojapago"].Rows.Add(drdesxcli);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("Debe elegir una placa especifica", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ds = new dsReportes();
                llenarDT2();
                if (dataGridView1.Rows.Count > 0)
                {
                    rptHojadePago informe = new rptHojadePago();
                    informe.SetDataSource(ds.Tables["dthojapago"]);
                    frmVerReportes reporte = new frmVerReportes();
                    informe.SetParameterValue("placa", txtplacacamion.Text);
                    informe.SetParameterValue("piloto", txtnombrepiloto.Text);
                    reporte.crystalReportViewer1.ReportSource = informe;
                    //MessageBox.Show(ds.Tables["dtreporteviajes"].Rows.Count.ToString());
                    reporte.Show();
                }
                else
                {
                    MessageBox.Show("No hay ningún dato para el reporte", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
