using Logica;
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

namespace ISPRO_TRANSPORTES
{
    public partial class frmProveedores : frmBase
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            BL_Proveedores.llenardgvproveedor(dataGridView1); 
            
        }

        private void limpiar()
        {
            txtidproveedor.Clear();
            txtnitproveedor.Clear();
            txtnombreproveedor.Clear();
            txtdireccionproveedor.Clear();
            txttelefonoproveedor.Clear();
            txtnitproveedor.Select();
            txtcontacto.Clear();
            btnregistro.Text = "Registrar";
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                BL_Proveedores.dardebajaproveedor(int.Parse(txtidproveedor.Text));
                limpiar();
                BL_Proveedores.llenardgvproveedor(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void crearobj()
        {
            PROVEEDOR pil = new PROVEEDOR
            {
                NIT = txtnitproveedor.Text.Trim(),
                NOMBRE = txtnombreproveedor.Text.Trim(),
                DIRECCION = txttelefonoproveedor.Text.Trim(),
                TELEFONO = txtdireccionproveedor.Text.Trim(),
                CONTACTO = txtcontacto.Text.Trim(),
                ESTADO = true
            };
            try
            {
                BL_Proveedores.agregarnuevoproveedor(pil);
                MessageBox.Show(this, "Proveedor registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidproveedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnitproveedor.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtnombreproveedor.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtdireccionproveedor.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttelefonoproveedor.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtcontacto.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            btnregistro.Text = "Actualizar";
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private bool validacampos()
        {
            bool validado = false;
            //validacion para el código
            if (txtnitproveedor.Text.Trim().Equals(""))
            {
                errorProvider1.SetError(txtnitproveedor, "Este campo es obligatorio");
                validado = false;
            }
            else
            {
                errorProvider1.SetError(txtnitproveedor, "");
                //Validacion para el nombre
                if (txtnombreproveedor.Text.Trim().Equals(""))
                {
                    errorProvider1.SetError(txtnombreproveedor, "Este campo es obligatorio");
                    validado = false;
                }
                else
                {
                    errorProvider1.SetError(txtnombreproveedor, "");
                    //Validacion para el telefono
                    if (txtdireccionproveedor.Text.Trim().Equals(""))
                    {
                        errorProvider1.SetError(txtdireccionproveedor, "Este campo es obligatorio");
                        validado = false;
                    }
                    else
                    {
                        errorProvider1.SetError(txtdireccionproveedor, "");
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
                    BL_Proveedores.llenardgvproveedor(dataGridView1);

                    limpiar();
                }
                else
                {
                    BL_Proveedores.actualizarproveedor(int.Parse(txtidproveedor.Text), txtnitproveedor.Text.Trim(), txtnombreproveedor.Text.Trim(), txtdireccionproveedor.Text.Trim(), txttelefonoproveedor.Text.Trim(), txtcontacto.Text);
                    limpiar();
                    BL_Proveedores.llenardgvproveedor(dataGridView1);
                }
            }
            else
            {
                MessageBox.Show(this, "Revise los mensajes para completar los campos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
