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
    public partial class frmAjustarTanque : Form
    {
        public frmAjustarTanque()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int valorNuevoCombustible = 0;
            if (validado())
            {
                if (comboBox1.Text.Equals("ENTRADA"))
                {
                    valorNuevoCombustible = int.Parse(txtcombustibleactual.Text) + int.Parse(txtcantidad.Text);
                }
                else
                {
                    valorNuevoCombustible = int.Parse(txtcombustibleactual.Text) - int.Parse(txtcantidad.Text);
                }

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
        }

        private bool validado()
        {
            bool valida = false;
            try
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    errorProvider1.SetError(comboBox1, "Selecione el tipo de ajuste");
                }
                else
                {
                    errorProvider1.SetError(comboBox1, "");
                    if (txtcantidad.Text.Trim().Equals(""))
                    {
                        errorProvider1.SetError(txtcantidad, "Debe agregar una cantidad");
                    }
                    else
                    {
                        errorProvider1.SetError(txtcantidad, "");
                        if (txtconcepto.Text.Trim().Equals(""))
                        {
                            errorProvider1.SetError(txtconcepto, "Escriba un concepto");
                        }
                        else
                        {
                            errorProvider1.SetError(txtconcepto, "");
                            if ((int.Parse(txtcantidad.Text) + int.Parse(txtcombustibleactual.Text)) > int.Parse(ConfigurationManager.AppSettings["maxCombustible"]))
                            {
                                errorProvider1.SetError(txtcantidad, "La cantidad sobrepasa el limite del tanque");
                            }
                            else
                            {
                                errorProvider1.SetError(txtcantidad, "");
                            }
                            valida = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return valida;
        }

        private void frmAjustarTanque_Load(object sender, EventArgs e)
        {

        }
    }
}
