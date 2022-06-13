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
    public partial class frmViaje : Form
    {
        public frmViaje()
        {
            InitializeComponent();
        }

        private void frmViaje_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                //MessageBox.Show("Todo bien");
                crearobj();
            }
            else
            {
                MessageBox.Show(this, "Revise los mensajes para verificar datos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void crearobj()
        {
            try
            {
                Entidades.VIAJE viaje = new Entidades.VIAJE
                {
                    FECHAREGISTRO = dtpfecharegistro.Value,
                    DESTINO = txtdestinoviaje.Text.Trim(),
                    PILOTO = int.Parse(lblidpiloto.Text),
                    CAMION = int.Parse(lblidcamion.Text),
                    ORIGEN = txtorigen.Text.Trim(),
                    NOVIAJE = txtnoviaje.Text.Trim(),
                    FOLIO = txtfolio.Text.Trim(),
                    FECHAENTREGA = dtpfechaentrega.Value,
                    PAGOPILOTO = decimal.Parse(txtpagopiloto.Text),
                    PRECIOVIAJE = decimal.Parse(txtprecioviaje.Text),
                    CANTDIESEL = decimal.Parse(txtcantidaddiesel.Text),
                    REGISTRADO = true,
                    DESPACHADO = false,
                    PAGADO = false,
                    FACTURADO = false,
                    USUARIO = BL_Usuario.codusuarioActual,
                    ESTADO = true,
                    TNMOVIDAS = decimal.Parse(txttnmovidas.Text),
                    KILOMETRAJE = int.Parse(txtkilometraje.Text),
                    PRELIQUIDACION = null,
                    NOPAGO = null,
                    CLIENTE = comboBox1.Text
            };
            
                BL_Viajes.agregarnuevoviaje(viaje);
                //MessageBox.Show(this, "Viaje registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private bool validar()
        {
            bool validado = false;

            //Validacion del destino
            if (txtdestinoviaje.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtdestinoviaje, "Este campo es obligatorio");
                validado = false;
            }
            else
            {
                errorProvider1.SetError(txtdestinoviaje, "");


                //Validación del diesel
                double valornumerico;

                if (!double.TryParse(txtcantidaddiesel.Text, out valornumerico))
                {
                    errorProvider1.SetError(txtcantidaddiesel, "Debe ingresar un dato numérico");
                    validado = false;

                }
                else
                {
                    errorProvider1.SetError(txtcantidaddiesel, "");
                    //Validación del pago a piloto
                    if (!double.TryParse(txtpagopiloto.Text, out valornumerico))
                    {
                        errorProvider1.SetError(txtpagopiloto, "Debe ingresar un dato numérico");
                        validado = false;

                    }
                    else
                    {
                        errorProvider1.SetError(txtpagopiloto, "");
                        //Validación del precio del viaje
                        if (!double.TryParse(txtprecioviaje.Text, out valornumerico))
                        {
                            errorProvider1.SetError(txtprecioviaje, "Debe ingresar un dato numérico");
                            validado = false;

                        }
                        else
                        {
                            errorProvider1.SetError(txtprecioviaje, "");
                            //Validacion del piloto
                            if (txtnombrepiloto.Text.Trim().Length == 0)
                            {
                                errorProvider1.SetError(txtnombrepiloto, "Falta la información del piloto");
                                validado = false;
                            }
                            else
                            {
                                errorProvider1.SetError(txtnombrepiloto, "");
                                // Validacion del camion
                                if (txtmarcacamion.Text.Trim().Length == 0)
                                {
                                    errorProvider1.SetError(txtmarcacamion, "Falta la información del camion");
                                    validado = false;
                                }
                                else
                                {
                                    errorProvider1.SetError(txtmarcacamion, "");
                                    if (txtnoviaje.Text.Trim().Equals(""))
                                    {
                                        errorProvider1.SetError(txtnoviaje, "Debe ingresar el numero de viaje");
                                        validado = false;
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(txtnoviaje, "");
                                        if (comboBox1.Text == "CEMEX")
                                        {
                                            if (txtfolio.Text.Trim().Equals(""))
                                            {
                                                errorProvider1.SetError(txtfolio, "Debe ingresar el numero de folio");
                                                validado = false;
                                            }
                                            else
                                            {
                                                errorProvider1.SetError(txtnoviaje, "");

                                                validado = true;
                                            }
                                        }
                                        else
                                        {
                                            validado = true;
                                        }
                                        
                                    }
                                    
                                }
                            }

                        }

                    }


                }
            }

            return validado;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCamiones camiones = new frmCamiones();
            camiones.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPilotos pilotos = new frmPilotos();
            pilotos.Show();
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCliente cliente = new frmCliente();
            cliente.Show();
        }





        private void txtcodigopiloto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BL_Pilotos.devolvernombrepiloto(txtcodigopiloto.Text.Trim()))
                {
                    txtnombrepiloto.Text = BL_Pilotos.nombrepiloto;
                    lblidpiloto.Text = BL_Pilotos.idpiloto.ToString();

                }
            }
        }

        private void txtplacacamion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BL_Camiones.devolverdatoscamion(txtplacacamion.Text.Trim()))
                {
                    txtmodelocamion.Text = BL_Camiones.modelocamion;
                    txtmarcacamion.Text = BL_Camiones.marcacamion;
                    lblidcamion.Text = BL_Camiones.idcamion.ToString();
                    lblidpiloto.Text = BL_Pilotos.idpiloto.ToString();
                    txtcodigopiloto.Text = BL_Pilotos.codigopiloto;
                    txtnombrepiloto.Text = BL_Pilotos.nombrepiloto;
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            dtpfecharegistro.Value = DateTime.Now;
            txtdestinoviaje.Clear();
            txtorigen.Clear();
            dtpfechaentrega.Value = DateTime.Now;
            txtnoviaje.Clear();
            txtcantidaddiesel.Text = "0.0";
            txtpagopiloto.Text = "0.0";
            txtprecioviaje.Text = "0.0";
            txtfolio.Clear();
            txtcodigopiloto.Clear();
            txtnombrepiloto.Clear();
            lblidpiloto.Text = "";
            lblidcamion.Text = "";
            txtplacacamion.Clear();
            txtmarcacamion.Clear();
            txtmodelocamion.Clear();
            txttnmovidas.Clear();
            txtkilometraje.Clear();
            
        }

        private void btnverviajes_Click(object sender, EventArgs e)
        {
            this.Close();
            frmVerViajes verviajes = new frmVerViajes();
            frmPrincipal principal = new frmPrincipal();
            verviajes.MdiParent = principal;
            verviajes.Show();

        }

        private void txtnoviaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtfolio.Select();
            }
        }

        private void txtfolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txttnmovidas.Select();
            }
        }

        private void txttnmovidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtorigen.Select();
            }
        }

        private void txtorigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtdestinoviaje.Select();
            }
        }

        private void txtdestinoviaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtkilometraje.Select();
            }
        }

        private void txtkilometraje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcantidaddiesel.Select();
            }
        }

        private void txtcantidaddiesel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpagopiloto.Select();
            }
        }

        private void txtpagopiloto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtprecioviaje.Select();
            }
        }

        private void txtprecioviaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtplacacamion.Select();
            }
        }
    }
}
