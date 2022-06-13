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
    public partial class frmLogin : Form
    {

        public delegate void pasar(string dato);
        public event pasar pasado;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                txtcontra.PasswordChar = '*';
                checkBox1.Text = "Mostrar contraseña";
                checkBox1.Checked = false;
            }
            else
            {
                txtcontra.PasswordChar = (char)0;
                checkBox1.Text = "Ocultar contraseña";
                checkBox1.Checked = true;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Logica.BL_Usuario.checharlogin(txtusuario.Text.Trim(), txtcontra.Text.Trim()))
            {
                MessageBox.Show(this, "Bienvenido al sistema: " + BL_Usuario.nombreUsuarioActual, "Datos correctos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pasado(BL_Usuario.nombreUsuarioActual);
                //MessageBox.Show(BL_Usuario.tipousuario.ToString());
                //frmPrincipal principal = Owner as frmPrincipal;
                //principal.toolStripLabelUsuario.Text += BL_Usuario.nombreUsuarioActual;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "No se encontraron coincidencias para estos datos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
