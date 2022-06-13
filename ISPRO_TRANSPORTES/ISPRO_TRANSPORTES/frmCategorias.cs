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
using Entidades;

namespace ISPRO_TRANSPORTES
{
    public partial class frmCategorias : frmBase
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            BL_Categoria.llenardgv(dataGridView1);
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidpiloto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtcodigopiloto.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            btnregistro.Text = "Actualizar";
        }

        private bool validacampos()
        {
            bool validado = false;
            //validacion para el código
            if (txtcodigopiloto.Text.Trim().Equals(""))
            {
                errorProvider1.SetError(txtcodigopiloto, "Este campo es obligatorio");
                validado = false;
            }
            else
            {
                errorProvider1.SetError(txtcodigopiloto, "");
                validado = true;
            }
            return validado;
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            if (validacampos())
            {
                if (btnregistro.Text.Equals("Registrar"))
                {
                    crearobj();
                    BL_Categoria.llenardgv(dataGridView1);

                    limpiar();
                }
                else
                {
                    BL_Categoria.actualizarcat(short.Parse(txtidpiloto.Text), txtcodigopiloto.Text.Trim());
                   
                    limpiar();
                    BL_Categoria.llenardgv(dataGridView1);
                }
            }
            else
            {
                MessageBox.Show(this, "Revise los mensajes para completar los campos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            txtidpiloto.Clear();
            txtcodigopiloto.Clear();
            
            txtcodigopiloto.Select();
            btnregistro.Text = "Registrar";
        }

        private void crearobj()
        {
            CATEGORIA pil = new CATEGORIA
            {
                        
                NOMBRE = txtcodigopiloto.Text.Trim(),                
                ESTADO = true
            };
            try
            {
                if (BL_Categoria.registrarcat(pil))
                {
                    MessageBox.Show(this, "Categoría registrada correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (BL_Categoria.dardebajacategoria(int.Parse(txtidpiloto.Text)))
            {
                MessageBox.Show(this, "Categoría eliminada correctamente", "Registro borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
