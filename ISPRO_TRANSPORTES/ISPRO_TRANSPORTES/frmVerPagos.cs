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

namespace ISPRO_TRANSPORTES
{
    public partial class frmVerPagos : Form
    {
        public frmVerPagos()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private double calcularTotal()
        {
            double tot = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                tot += double.Parse(row.Cells[8].Value.ToString());
            }

            return tot;
        }

        private void frmVerPagos_Load(object sender, EventArgs e)
        {
            BL_Pilotos.llenardgvpagospilotos(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            txtidpago.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtfechapago.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtnodocumento.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtquincena.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtviaticos.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtentradas.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtparqueos.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtdescargas.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtotros.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            
            txttotal.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            long nopago = long.Parse(txtidpago.Text.Trim());
            BL_Viajes.filtrarxpago(dataGridView2, nopago);
            txttotalviajes.Text = string.Format("{0:N2}", calcularTotal());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BL_Pilotos.flitrarporpiloto(dataGridView1, txtbuscar.Text.Trim());
        }
    }
}
