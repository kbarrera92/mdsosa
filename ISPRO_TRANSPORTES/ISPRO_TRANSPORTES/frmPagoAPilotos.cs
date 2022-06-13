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
    public partial class frmPagoAPilotos : Form
    {
        public frmPagoAPilotos()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPagoAPilotos_Load(object sender, EventArgs e)
        {
            limpiartodo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblcorrelativoviaje.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnoviaje.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtfechaviaje.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtorigendestino.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString() + "/" + dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtsacos.Text = string.Format("{0:N0}", decimal.Parse(dataGridView1.CurrentRow.Cells[17].Value.ToString()) * 23.53M);
            txtvalorviaje.Select();
        }

        private void btnguardarvalor_Click(object sender, EventArgs e)
        {
            if (txtvalorviaje.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el valor del viaje", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (decimal.Parse(txtvalorviaje.Text.Trim()) <= 0)
                {
                    MessageBox.Show("Cantidad incorrecta", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dataGridView2.Rows.Add(lblcorrelativoviaje.Text, txtnoviaje.Text, txtorigendestino.Text, txtsacos.Text, string.Format("{0:N2}", txtvalorviaje.Text));
                    txttotalpago.Text = string.Format("{0:N2}", calculartotal(4, dataGridView2).ToString());
                    limpiar();
                    txtnoviaje.Select();
                }
            }
        }

        private decimal calculartotal(int col, DataGridView dgv)
        {
            decimal total = 0.0M;

            try
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    total += decimal.Parse(dgv.Rows[i].Cells[col].Value.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return total;
        }

        private void limpiar()
        {
            txtfechaviaje.Clear();
            lblcorrelativoviaje.Text = "";
            txtnoviaje.Clear();
            txtorigendestino.Clear();
            txtsacos.Clear();
            txtvalorviaje.Clear();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            BL_Viajes.filtrarxviaje(dataGridView1, txtbuscarviaje.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL_Viajes.llenardgvviajes2(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un viaje para borrarlo", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                txttotalpago.Text = string.Format("{0:N2}", calculartotal(4, dataGridView2).ToString());
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnregistrarpago_Click(object sender, EventArgs e)
        {
            PAGOAPILOTO pago = new PAGOAPILOTO()
            {
                FECHAREGISTRO = dateTimePicker1.Value,
                NODOCUMENTO = txtnocheque.Text,
                DOCUMENTO = "",
                QUINCENA = decimal.Parse(txtquincena.Text),
                VIATICOS = decimal.Parse(txtviaticos.Text),
                ENTRADAS = decimal.Parse(txtentrada.Text),
                PARQUEO = decimal.Parse(txtparqueo.Text),
                DESCARGA = decimal.Parse(txtdescarga.Text),
                OTROS = decimal.Parse(txtotros.Text),
                TOTAL = decimal.Parse(txttotalpago.Text),
                PLACA = txtplaca.Text,
                PILOTO = txtpiloto.Text
            };

            if (BL_Pilotos.agregarpagoapiloto(pago))
            {
                long pago1;
                //MessageBox.Show("Si");
                using (TRANSPORTEEntities db = new TRANSPORTEEntities())
                {
                    pago1 = db.PAGOAPILOTO.Max(x => x.IDPAGO);
                }

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    BL_Viajes.actualizarviaje(long.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()), pago1, decimal.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString()));
                }

                MessageBox.Show("Se registró correctamente el pago", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btndescartar_Click(object sender, EventArgs e)
        {
            limpiartodo();
        }

        private void limpiartodo()
        {
            txtplaca.Clear();
            txtpiloto.Clear();
            txtbuscarviaje.Clear();
            BL_Viajes.llenardgvviajes2(dataGridView1);
            dataGridView2.Rows.Clear();
            txtfechaviaje.Clear();
            lblcorrelativoviaje.Text = "";
            txtfechaviaje.Clear();
            txtnoviaje.Clear();
            txtorigendestino.Clear();
            txtsacos.Clear();
            txtvalorviaje.Clear();
            txttotalpago.Clear();
            txtquincena.Clear();
            txtviaticos.Clear();
            txtentrada.Clear();
            txtparqueo.Clear();
            txtdescarga.Clear();
            txtotros.Clear();
            txtbuscarviaje.Select();
            
        }

        private void txtplaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BL_Camiones.devolverdatoscamion(txtplaca.Text.Trim()))
                {
                    txtpiloto.Text = BL_Pilotos.nombrepiloto;
                }
            }
        }
    }
}
