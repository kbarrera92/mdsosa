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
    public partial class frmCompra3 : Form
    {
        public frmCompra3()
        {
            InitializeComponent();
        }

        private void txttotalfactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBox1.Checked)
                {
                    txtprecioneto.Text = string.Format("{0:N2}", double.Parse(txttotalfactura.Text.Trim()) / 1.12);
                    txtiva.Text = string.Format("{0:N2}", double.Parse(txtprecioneto.Text.Trim()) * 0.12);
                    txtretencion.Text = string.Format("{0:N2}", double.Parse(txtiva.Text.Trim()) * 0.30);
                }
                else
                {
                    txtprecioneto.Text = string.Format("{0:N2}", double.Parse(txttotalfactura.Text.Trim()) / 1.12);
                    txtiva.Text = string.Format("{0:N2}", double.Parse(txtprecioneto.Text.Trim()) * 0.12);
                    txtretencion.Text = "0.0";
                }
                
            }
        }

        private void limpiar()
        {
            txtnofactura.Clear();
            txttipodocumento.Clear();
            txtnit.Clear();
            txtproveedor.Clear();
            txtcuentacontable.Clear();
            checkBox1.Checked = false;
            
            txttotalfactura.Text = "0.0";
            txtprecioneto.Text = "0.0";
            txtiva.Text = "0.0";
            txtretencion.Text = "0.0";
            txtnofactura.Select();
        }
        private void btnvercompras_Click(object sender, EventArgs e)
        {

        }


        private bool validar()
        {
            bool valida = false;

            double valornumerico;
            if (!double.TryParse(txttotalfactura.Text, out valornumerico))
            {
                errorProvider1.SetError(txttotalfactura, "Debe ingresar un valor numérico");
            }
            else
            {
                errorProvider1.SetError(txttotalfactura, "");
                if (txtnofactura.Text.Trim().Equals(""))
                {
                    errorProvider1.SetError(txtnofactura, "Este dato es obligatorio");
                }
                else
                {
                    errorProvider1.SetError(txtnofactura, "");
                    if (txtcuentacontable.Text.Trim().Equals(""))
                    {
                        errorProvider1.SetError(txtcuentacontable, "Este dato es obligatorio");
                    }
                    else
                    {
                        errorProvider1.SetError(txtcuentacontable, "");
                        valida = true;
                    }
                }

            }

            return valida;
        }
        private void btndescartar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    Entidades.VENTA compra = new Entidades.VENTA
                    {
                        FECHA = dateTimePicker1.Value,
                        FACTURA = txtnofactura.Text,
                        TIPODOCUMENTO = txttipodocumento.Text,
                        NIT = txtnit.Text,
                        PROVEEDOR = txtproveedor.Text,
                        CUENTACONTABLE = txtcuentacontable.Text,
                        TOTAL = decimal.Parse(txttotalfactura.Text),
                        PRECIONETO = decimal.Parse(txtprecioneto.Text),
                        IVA = decimal.Parse(txtiva.Text),
                        RETENCION = decimal.Parse(txtretencion.Text)
                    };

                    if (Logica.BL_Venta.agregarventa(compra))
                    {
                        MessageBox.Show("Se registró la venta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        limpiar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
