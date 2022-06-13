using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Logica;

namespace ISPRO_TRANSPORTES
{
    public partial class frmCamiones : frmBase
    {
        public frmCamiones()
        {
            InitializeComponent();
        }

        private void frmCamiones_Load(object sender, EventArgs e)
        {
            BL_Camiones.llenardgvcamiones(dataGridView1);
            BL_Pilotos.llenarcmbpilotos(comboBox1);
            comboBox1.SelectedIndex = -1;
        }

        private void limpiar()
        {
            txtidcamion.Clear();
            txtplacacamion.Clear();
            txtmarcacamion.Clear();
            txtmodelocamion.Clear();
            comboBox1.SelectedIndex = -1;
            btnregistro.Text = "Registrar";
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            if (validarcampos())
            {
                if (btnregistro.Text.Equals("Registrar"))
                {
                    crearobj();
                    BL_Camiones.llenardgvcamiones(dataGridView1);

                    limpiar();
                }
                else
                {
                    BL_Camiones.actualizarcamion(int.Parse(txtidcamion.Text), txtplacacamion.Text.Trim(), txtmarcacamion.Text.Trim(), txtmodelocamion.Text.Trim());

                    limpiar();
                    BL_Camiones.llenardgvcamiones(dataGridView1);
                }
            }
            else
            {
                MessageBox.Show(this, "Verifique los mensajes para solucionar errores", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void crearobj()
        {
            
            CAMION user = new CAMION
            {
                PLACA = txtplacacamion.Text.Trim(),
                MARCA = txtmarcacamion.Text.Trim(),
                MODELO = txtmodelocamion.Text.Trim(),
                ESTADO = true,
                PILOTO = int.Parse(comboBox1.SelectedValue.ToString())
            };
            try
            {
                BL_Camiones.agregarnuevousuario(user);
                MessageBox.Show(this, "Camión registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            BL_Camiones.dardebajacamion(int.Parse(txtidcamion.Text));
            limpiar();
            BL_Camiones.llenardgvcamiones(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = comboBox1.FindStringExact(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            txtidcamion.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtplacacamion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtmarcacamion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtmodelocamion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.SelectedIndex = index;
            btnregistro.Text = "Actualizar";
        }

        private bool validarcampos()
        {
            bool validado = false;

            if (txtplacacamion.Text.Trim().Equals(""))
            {
                errorProvider1.SetError(txtplacacamion, "Este campo es obligatorio");
                validado = false;
            }
            else
            {
                errorProvider1.SetError(txtplacacamion, "");
                validado = true;
            }

            return validado;
        }
    }
}
