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
    public partial class frmAsignarPreliquidacion : Form
    {
        public frmAsignarPreliquidacion()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            BL_Viajes.filtrarxviaje(dataGridView1, txtbuscarviaje.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BL_Viajes.llenardgvviajes2(dataGridView1);
        }

        private void frmAsignarPreliquidacion_Load(object sender, EventArgs e)
        {
            BL_Viajes.llenardgvviajes2(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtnoviaje.Text.Trim().Equals(""))
            {
                MessageBox.Show("No ha elegido ningún viaje", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BL_Viajes.actualizarviaje3(long.Parse(lblidviaje.Text), decimal.Parse(txtvalorviaje.Text.Trim()));
                listBoxviajes.Items.Add(txtnoviaje.Text.Trim());
                txtvalorviaje.Clear();
                txtnoviaje.Clear();
                lblidviaje.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (BL_Preliquidacion.existe(long.Parse(txtpreliquidacion.Text.Trim())))
                {
                    for (int i = 0; i < listBoxviajes.Items.Count; i++)
                    {
                        BL_Viajes.actualizarviaje2(listBoxviajes.Items[i].ToString(), long.Parse(txtpreliquidacion.Text));
                    }
                    txtpreliquidacion.Clear();
                    txtnfactura.Clear();
                    txtdescripcion.Clear();
                    txtbuscarviaje.Clear();
                    BL_Viajes.llenardgvviajes2(dataGridView1);
                    listBoxviajes.Items.Clear();
                }
                else
                {
                    try
                    {
                        Entidades.PRELIQUIDACION preliq = new Entidades.PRELIQUIDACION()
                        {
                            PRELIQUIDACION1 = long.Parse(txtpreliquidacion.Text.Trim()),
                            FECHA = dateTimePickerfecha.Value,
                            FACTURA = txtnfactura.Text,
                            DESCRIPCION = txtdescripcion.Text
                        };

                        if (BL_Preliquidacion.agregarpreliquidacion(preliq))
                        {
                            for (int i = 0; i < listBoxviajes.Items.Count; i++)
                            {
                                BL_Viajes.actualizarviaje2(listBoxviajes.Items[i].ToString(), long.Parse(txtpreliquidacion.Text));
                            }
                            txtpreliquidacion.Clear();
                            txtnfactura.Clear();
                            txtdescripcion.Clear();
                            txtbuscarviaje.Clear();
                            BL_Viajes.llenardgvviajes2(dataGridView1);
                            listBoxviajes.Items.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("2 " + ex.Message);
                    }
                }
                
            }
        }

        private bool validar()
        {
            bool validado = false;

            if (txtpreliquidacion.Text.Trim().Equals(""))
            {
                errorProvider1.SetError(txtpreliquidacion, "Este campo es obligatorio");
            }
            else
            {
                errorProvider1.SetError(txtpreliquidacion, "");
                if (listBoxviajes.Items.Count == 0)
                {
                    errorProvider1.SetError(listBoxviajes, "Debe elegir al menos un viaje");
                }
                else
                {
                    errorProvider1.SetError(listBoxviajes, "");
                    validado = true;
                }
            }

            return validado;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblidviaje.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnoviaje.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtvalorviaje.Select();
        }
    }
}
