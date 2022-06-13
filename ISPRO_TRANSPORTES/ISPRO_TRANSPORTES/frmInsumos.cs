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
    public partial class frmInsumos : frmBase
    {
        public frmInsumos()
        {
            InitializeComponent();
        }

        private void frmInsumos_Load(object sender, EventArgs e)
        {
            BL_Insumos.llenardgvinsumos(dataGridView1);
            BL_Categoria.llenarcmb(cmbcategorias);
            cmbcategorias.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = cmbcategorias.FindStringExact(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            txtidinsumo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtdescripcion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtcosto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtprecio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cmbcategorias.SelectedIndex = index;
            txtexistencias.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            btnregistro.Text = "Actualizar";
        }

        private void limpiar()
        {
            txtidinsumo.Clear();
            txtdescripcion.Clear();
            txtcosto.Clear();
            txtprecio.Clear();
            txtexistencias.Clear();
            cmbcategorias.SelectedIndex = -1;
            txtdescripcion.Select();
            btnregistro.Text = "Registrar";
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (BL_Insumos.dardebajainsumo(int.Parse(txtidinsumo.Text)))
            {
                MessageBox.Show(this, "Insumo eliminado correctamente", "Registro borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void crearobj()
        {
            INSUMO pil = new INSUMO
            {
                
                DESCRIPCION = txtdescripcion.Text.Trim(),
                COSTO = decimal.Parse(txtcosto.Text),
                PRECIO = decimal.Parse(txtprecio.Text),
                CATEGORIA = short.Parse(cmbcategorias.SelectedValue.ToString()),
                EXISTENCIA = decimal.Parse(txtexistencias.Text),
                ESTADO = true
            };
            try
            {
                if (BL_Insumos.registrarinsumo(pil))
                {
                    MessageBox.Show(this, "Insumo registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private bool validacampos()
        {
            bool validado = false;
            //validacion para el código
            if (txtdescripcion.Text.Trim().Equals(""))
            {
                errorProvider1.SetError(txtdescripcion, "Este campo es obligatorio");
                validado = false;
            }
            else
            {
                errorProvider1.SetError(txtdescripcion, "");
                if (txtcosto.Text.Trim().Equals(""))
                {
                    errorProvider1.SetError(txtcosto, "Este campo es obligatorio");
                    validado = false;
                }
                else
                {
                    errorProvider1.SetError(txtcosto, "");
                    if (txtexistencias.Text.Trim().Equals(""))
                    {
                        errorProvider1.SetError(txtexistencias, "Este campo es obligatorio");
                        validado = false;
                    }
                    else
                    {
                        errorProvider1.SetError(txtexistencias, "");
                        validado = true;
                    }
                }
                
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
                    BL_Insumos.llenardgvinsumos(dataGridView1);

                    limpiar();
                }
                else
                {
                    try
                    {
                        BL_Insumos.actualizarinsumo(int.Parse(txtidinsumo.Text), txtdescripcion.Text.Trim(), decimal.Parse(txtcosto.Text), decimal.Parse(txtprecio.Text), short.Parse(cmbcategorias.SelectedValue.ToString()), decimal.Parse(txtexistencias.Text));
                        limpiar();
                        BL_Insumos.llenardgvinsumos(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        
                    }
                    

                    
                }
            }
            else
            {
                MessageBox.Show(this, "Revise los mensajes para completar los campos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
