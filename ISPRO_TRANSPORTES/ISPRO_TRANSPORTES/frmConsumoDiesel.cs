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
    public partial class frmConsumoDiesel : Form
    {
        DataSet ds = new dsReportes();
        public frmConsumoDiesel()
        {
            InitializeComponent();
        }

        private double calculartotal(int column, DataGridView dgv)
        {
            double total = 0.00d;

            try
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    total += double.Parse(dgv.Rows[i].Cells[column].Value.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            return total; 
        }

        private void frmConsumoDiesel_Load(object sender, EventArgs e)
        {
            BL_Vales.llenardgvviajes(dataGridView1);
            txttotal.Text = calculartotal(6, dataGridView1).ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BL_Camiones.devolverdatoscamion(txtplaca.Text.Trim()))
                {
                    txtnombrepiloto.Text = BL_Pilotos.nombrepiloto;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                BL_Vales.filtrarporfecha(dataGridView1, dateTimePicker1.Value, dateTimePicker2.Value);
                txttotal.Text = calculartotal(6, dataGridView1).ToString();
            }
            else
            {
                BL_Vales.filtrarporplacayfecha(dataGridView1, txtplaca.Text, dateTimePicker1.Value, dateTimePicker2.Value);
                txttotal.Text = calculartotal(6, dataGridView1).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llenarDT()
        {
            ds = new dsReportes();
            DataTable dt;

            dt = ds.Tables["dtreporteconsumo"];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataRow drdesxcli = ds.Tables["dtreporteconsumo"].NewRow();
                drdesxcli["NOVIAJE"] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                drdesxcli["NOVALE"] = long.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                drdesxcli["NOMBRE"] = dataGridView1.Rows[i].Cells[2].Value;
                drdesxcli["PLACA"] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                drdesxcli["DESTINO"] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                drdesxcli["FECHA"] = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                drdesxcli["MONTO"] = decimal.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                ds.Tables["dtreporteconsumo"].Rows.Add(drdesxcli);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds = new dsReportes();
            llenarDT();
            if (dataGridView1.Rows.Count > 0)
            {
                rptConsumo informe = new rptConsumo();
                informe.SetDataSource(ds.Tables["dtreporteconsumo"]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            BL_Vales.llenardgvviajes(dataGridView1);
            txttotal.Text = calculartotal(6, dataGridView1).ToString();
        }
    }
}
