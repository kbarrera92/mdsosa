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
    public partial class frmValeCombustible : frmBase
    {
        public frmValeCombustible()
        {
            InitializeComponent();
        }

        private void frmValeCombustible_Load(object sender, EventArgs e)
        {
            txtnoviaje.Text = Convert.ToString(Logica.BL_Viajes.correlativo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarcampos())
            {
                crearobj();
                
            }
            else
            {
                MessageBox.Show(this, "Revise los mensaje para completar los campos correctamente", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarcampos()
        {
            bool validado = false;

            double valornumerico;

            if (!double.TryParse(txtimportevale.Text, out valornumerico))
            {
                errorProvider1.SetError(txtimportevale, "Debe ingresar un dato numérico");
                validado = false;

            }
            else
            {
                errorProvider1.SetError(txtimportevale, "");

                if (!double.TryParse(txtnovale.Text, out valornumerico))
                {
                    errorProvider1.SetError(txtnovale, "Debe ingresar un dato numérico");
                    validado = false;

                }
                else
                {
                    errorProvider1.SetError(txtnovale, "");
                    validado = true;
                }
            }

                return validado;
        }

        private void crearobj()
        {
            Entidades.VALECOMBUSTIBLE vale = new Entidades.VALECOMBUSTIBLE
            {
                NOVALE = long.Parse(txtnovale.Text.Trim()),
                FECHA = dateTimePicker1.Value,
                MONTO = decimal.Parse(txtimportevale.Text.Trim()),
                VIAJE = long.Parse(txtnoviaje.Text.Trim()),
                LOCALIDAD = checkBox1.Checked
            };
            try
            {
                Logica.BL_Viajes.agregarvale(vale);

                MessageBox.Show(this, "Vale registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                if (checkBox1.Checked)
                {
                    
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
                                    nodos.Attributes[1].Value = (int.Parse(ConfigurationManager.AppSettings["combustibleActual"]) - int.Parse(txtimportevale.Text)).ToString();

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
                
                //
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        
    }
}
