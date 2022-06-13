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
    public partial class frmCliente : frmBase
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Logica.BL_Cliente.cargardgvclientes(dataGridView1);
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            btnregistro.Text = "Registrar";
            txtcodigocliente.Select();
        }

            private void limpiar()
        {
            txtidcliente.Clear();
            txtcodigocliente.Clear();
            txtnitcliente.Clear();
            txtnombrecliente.Clear();
            txttelefonocliente.Clear();
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            if (btnregistro.Text.Equals("Registrar"))
            {
                crearobj();
                BL_Cliente.cargardgvclientes(dataGridView1);
                
                limpiar();
            }
            else
            {
                BL_Cliente.actualizarcliente(int.Parse(txtidcliente.Text), txtcodigocliente.Text.Trim(), txtnitcliente.Text.Trim(), txtnombrecliente.Text.Trim(), txttelefonocliente.Text.Trim());
                limpiar();
                BL_Cliente.cargardgvclientes(dataGridView1);
                btnregistro.Text = "Registrar";
            }
        }

        private void crearobj()
        {
            Entidades.CLIENTE cliente = new Entidades.CLIENTE
            {
                CODIGO = txtcodigocliente.Text.Trim(),
                NIT = txtnitcliente.Text.Trim(),
                NOMBRE = txtnombrecliente.Text.Trim(),
                TELEFONO = txttelefonocliente.Text.Trim(),
                ESTADO = true
            };
            try
            {
                Logica.BL_Cliente.agregarnuevocliente(cliente);
                MessageBox.Show(this, "Cliente registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnregistro.Text = "Actualizar";
            txtidcliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtcodigocliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtnitcliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtnombrecliente.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttelefonocliente.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Seleccione un registro para borrar", "Seleccione algo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                BL_Cliente.dardebajacliente(int.Parse(txtidcliente.Text));
                limpiar();
                BL_Cliente.cargardgvclientes(dataGridView1);
            }
        }
    }
}
