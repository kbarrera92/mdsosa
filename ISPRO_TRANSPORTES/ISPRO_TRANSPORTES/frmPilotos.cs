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
    public partial class frmPilotos : frmBase
    {
        public frmPilotos()
        {
            InitializeComponent();
        }

        private void frmPilotos_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Imprimir Carné");
            BL_Pilotos.llenardgvpilotos(dataGridView1);
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtidpiloto.Clear();
            txtcodigopiloto.Clear();
            txtnombrepiloto.Clear();
            txttelpiloto.Clear();
            txtdomiciliopiloto.Clear();
            txtcodigopiloto.Select();
            btnregistro.Text = "Registrar";
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            if (validacampos())
            {
                if (btnregistro.Text.Equals("Registrar"))
                {
                    crearobj();
                    BL_Pilotos.llenardgvpilotos(dataGridView1);

                    limpiar();
                }
                else
                {
                    BL_Pilotos.actualizarpiloto(int.Parse(txtidpiloto.Text), txtcodigopiloto.Text.Trim(), txtnombrepiloto.Text.Trim(), txttelpiloto.Text.Trim(), txtdomiciliopiloto.Text.Trim());
                    limpiar();
                    BL_Pilotos.llenardgvpilotos(dataGridView1);
                }
            }
            else
            {
                MessageBox.Show(this, "Revise los mensajes para completar los campos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        private void crearobj()
        {
            PILOTO pil = new PILOTO
            {
                CODIGO = txtcodigopiloto.Text.Trim(),
                NOMBRE = txtnombrepiloto.Text.Trim(),
                TELEFONO = txttelpiloto.Text.Trim(),
                DOMICILIO = txtdomiciliopiloto.Text.Trim(),
                ESTADO = true
            };
            try
            {
                BL_Pilotos.agregarnuevopiloto(pil);
                MessageBox.Show(this, "Piloto registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidpiloto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtcodigopiloto.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtnombrepiloto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttelpiloto.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdomiciliopiloto.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            btnregistro.Text = "Actualizar";
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                BL_Pilotos.dardebajapiloto(int.Parse(txtidpiloto.Text));
                limpiar();
                BL_Pilotos.llenardgvpilotos(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
                //Validacion para el nombre
                if (txtnombrepiloto.Text.Trim().Equals(""))
                {
                    errorProvider1.SetError(txtnombrepiloto, "Este campo es obligatorio");
                    validado = false;
                }
                else
                {
                    errorProvider1.SetError(txtnombrepiloto, "");
                    //Validacion para el telefono
                    if (txttelpiloto.Text.Trim().Equals(""))
                    {
                        errorProvider1.SetError(txttelpiloto, "Este campo es obligatorio");
                        validado = false;
                    }
                    else
                    {
                        errorProvider1.SetError(txttelpiloto, "");
                        validado = true;
                    }
                }
            }

            return validado; 
        }
    }
}
