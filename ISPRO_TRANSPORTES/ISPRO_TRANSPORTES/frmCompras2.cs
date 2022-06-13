using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ISPRO_TRANSPORTES
{
    public partial class frmCompras2 : Form
    {
        public frmCompras2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtnofactura.Clear();
            txttipodocumento.Clear();
            txtnit.Clear();
            txtproveedor.Clear();
            txtcuentacontable.Clear();
            checkBoxCombustible.Checked = false;
            txtgalonaje.Text = "0";
            txtidp.Clear();
            txttotalfactura.Text = "0.0";
            txtprecioneto.Text = "0.0";
            txtiva.Text = "0.0";
            txttotal.Text = "0.0";
            txtnofactura.Select();
        }

        private void ajustartanque()
        {
            int valorNuevoCombustible = int.Parse(ConfigurationManager.AppSettings["combustibleActual"]) - int.Parse(txtgalonaje.Text.Trim());

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement item in xmlDoc.DocumentElement)
            {
                if (item.Name.Equals("appSettings"))
                {
                    foreach (XmlNode nodos in item.ChildNodes)
                    {
                        if (nodos.Attributes[0].Value == "combustibleActual")
                        {
                            nodos.Attributes[1].Value = valorNuevoCombustible.ToString();

                        }
                    }
                }
            }

            try
            {
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("appSettings");
                MessageBox.Show("Se ajusto el combustible correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (checkBoxCombustible.Checked)
                {
                    try
                    {
                        Entidades.COMPRA2 compra = new Entidades.COMPRA2
                        {
                            FECHA = dateTimePicker1.Value,
                            NOFACTURA = txtnofactura.Text.Trim(),
                            TIPODOCUMENTO = txttipodocumento.Text.Trim(),
                            NIT = txtnit.Text.Trim(),
                            PROVEEDOR = txtproveedor.Text.Trim(),
                            CUENTACONTABLE = txtcuentacontable.Text.Trim(),
                            GALONAJE = decimal.Parse(txtgalonaje.Text.Trim()),
                            IDP = txtidp.Text.Trim(),
                            TOTALFACTURA = decimal.Parse(txttotalfactura.Text.Trim()),
                            PRECIONETO = decimal.Parse(txtprecioneto.Text.Trim()),
                            IVA = decimal.Parse(txtiva.Text.Trim()),
                            TOTAL = decimal.Parse(txttotal.Text)
                        };

                        if (Logica.BL_Compra.agregarcompra2(compra))
                        {
                            MessageBox.Show("Se registró la compra", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ajustartanque();
                            limpiar();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        Entidades.COMPRA2 compra = new Entidades.COMPRA2
                        {
                            FECHA = dateTimePicker1.Value,
                            NOFACTURA = txtnofactura.Text.Trim(),
                            TIPODOCUMENTO = txttipodocumento.Text.Trim(),
                            NIT = txtnit.Text.Trim(),
                            PROVEEDOR = txtproveedor.Text.Trim(),
                            CUENTACONTABLE = txtcuentacontable.Text.Trim(),
                            GALONAJE = decimal.Parse(txtgalonaje.Text.Trim()),
                            IDP = txtidp.Text.Trim(),
                            TOTALFACTURA = decimal.Parse(txttotalfactura.Text.Trim()),
                            PRECIONETO = decimal.Parse(txtprecioneto.Text.Trim()),
                            IVA = decimal.Parse(txtiva.Text.Trim()),
                            TOTAL = decimal.Parse(txttotal.Text)
                        };

                        if (Logica.BL_Compra.agregarcompra2(compra))
                        {
                            MessageBox.Show("Se registró la compra", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //ajustartanque();
                            limpiar();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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

        private void btnvercompras_Click(object sender, EventArgs e)
        {
            frmVerCompras2 compras2 = new frmVerCompras2();
            compras2.Show();
        }

        private void txtgalonaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal valor;
                if (!decimal.TryParse(txtgalonaje.Text.Trim(), out valor))
                {
                    MessageBox.Show("Ingresa un valor numerico", "Error");
                    //txtidp.Text = string.Format("{0:N2}", decimal.Parse(txtgalonaje.Text) * 1.3m);
                }
                else
                {
                    txtidp.Text = string.Format("{0:N2}", decimal.Parse(txtgalonaje.Text) * 1.3m);
                }
                 
            }
        }

        private void txttotalfactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtidp.Text.Trim().Equals(""))
                {
                    txttotal.Text = string.Format("{0:N2}", double.Parse(txttotalfactura.Text.Trim()) - double.Parse(txtidp.Text.Trim()));
                    txtprecioneto.Text = string.Format("{0:N2}", double.Parse(txttotalfactura.Text.Trim()) / 1.12);
                    txtiva.Text = string.Format("{0:N2}", double.Parse(txtprecioneto.Text.Trim()) * 0.12);
                }
                else
                {
                    txtprecioneto.Text = string.Format("{0:N2}", double.Parse(txttotalfactura.Text.Trim()) / 1.12);
                    txtiva.Text = string.Format("{0:N2}", double.Parse(txtprecioneto.Text.Trim()) * 0.12);
                }
            }
        }

        private void frmCompras2_Load(object sender, EventArgs e)
        {

        }
    }
}
