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
    public partial class frmVerVales : frmBase
    {
        Dictionary<int, string> meses = new Dictionary<int, string>();

        private void llenarcmbanios()
        {
            int anioactual = DateTime.Now.Year;

            for (int i = 2020; i <= anioactual; i++)
            {
                cmbanio.Items.Add(i);
            }
        }

        public frmVerVales()
        {
            InitializeComponent();
        }

        private void frmVerVales_Load(object sender, EventArgs e)
        {
            Logica.BL_Vales.llenardgvviajes(dataGridView1);

            llenarcmbanios();
            meses.Add(1, "Enero");
            meses.Add(2, "Febrero");
            meses.Add(3, "Marzo");
            meses.Add(4, "Abril");
            meses.Add(5, "Mayo");
            meses.Add(6, "Junio");
            meses.Add(7, "Julio");
            meses.Add(8, "Agosto");
            meses.Add(9, "Septiembre");
            meses.Add(10, "Octubre");
            meses.Add(11, "Noviembre");
            meses.Add(12, "Diciembre");

            comboBox1.DataSource = meses.ToList();
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";
            comboBox1.SelectedIndex = 0;
            cmbanio.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButtonplaca.Checked)
            {
                BL_Vales.filtrarporplaca(dataGridView1, txtbuscar.Text.Trim());
            }
            else
            {
                BL_Vales.filtrarpordestino(dataGridView1, txtbuscar.Text.Trim());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (chkmes.Checked)
            {
                int anio = int.Parse(cmbanio.Text);
                int mes = int.Parse(comboBox1.SelectedValue.ToString());
                BL_Vales.filtrarpormes(dataGridView1, mes, anio);
            }
            else
            {
                if (chkfechas.Checked)
                {
                    DateTime ini = dateTimePicker1.Value;
                    DateTime fin = dateTimePicker2.Value;
                    BL_Vales.filtrarporfecha(dataGridView1, ini, fin);
                }
                else
                {
                    MessageBox.Show(this, "No ha seleccionado un criterio de búsqueda", "Marque un criterio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Logica.BL_Vales.llenardgvviajes(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtbuscar.Clear();
            Logica.BL_Vales.llenardgvviajes(dataGridView1);
        }

        private void chkfechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfechas.Checked == false)
            {
                chkmes.Checked = true;
            }
            else
            {
                chkmes.Checked = false;
                chkfechas.Checked = true;
            }
        }

        private void chkmes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmes.Checked == false)
            {
                chkfechas.Checked = true;
            }
            else
            {
                chkmes.Checked = true;
                chkfechas.Checked = false;
            }
        }
    }
}
