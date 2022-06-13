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
    public partial class frmUsuarios : frmBase
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            BL_Usuario.llenardgvusuario(dataGridView1);
            BL_Usuario.llenarcmb(cmbtipousuario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtidusuario.Clear();
            txtcodigousuario.Clear();
            txtclaveusuario.Clear();
            cmbtipousuario.SelectedIndex = -1;
            btnregistro.Text = "Registrar";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (btnregistro.Text.Equals("Registrar"))
            {
                crearobj();
                BL_Usuario.llenardgvusuario(dataGridView1);
                BL_Usuario.llenarcmb(cmbtipousuario);
                limpiar();
            }
            else
            {
                BL_Usuario.actualizarusuario(int.Parse(txtidusuario.Text), txtcodigousuario.Text.Trim(), txtclaveusuario.Text.Trim(), byte.Parse(cmbtipousuario.SelectedValue.ToString()));
                limpiar();
                BL_Usuario.llenardgvusuario(dataGridView1);
            }
        }

        private void crearobj()
        {
            Entidades.USUARIO user = new Entidades.USUARIO
            {
                CODIGO = txtcodigousuario.Text.Trim(),
                CLAVE = txtclaveusuario.Text.Trim(),
                TIPO = byte.Parse(cmbtipousuario.SelectedValue.ToString()),
                ESTADO = true
            };
            try
            {
                BL_Usuario.agregarnuevousuario(user);
                MessageBox.Show(this, "Usuario creado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = cmbtipousuario.FindStringExact(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            txtidusuario.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtcodigousuario.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtclaveusuario.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbtipousuario.SelectedIndex = index;
            btnregistro.Text = "Actualizar";
        }
    }
}
