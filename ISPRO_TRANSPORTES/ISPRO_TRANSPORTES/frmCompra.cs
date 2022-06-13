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
    public partial class frmCompra : frmBase
    {
        public frmCompra()
        {
            InitializeComponent();
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
            BL_Compra.llenarcmbformapago(cmbFP);
            BL_Insumos.llenardgvinsumos(dataGridView1);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProveedores prov = new frmProveedores();
            prov.Show();
        }

        private void lblidcamion_Click(object sender, EventArgs e)
        {

        }

        private void txtNIT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BL_Proveedores.devolverdatosproveedor(txtNIT.Text.Trim()))
                {
                    txtproveedor.Text = BL_Proveedores.nombreproveedor;
                    lblidproveedor.Text = BL_Proveedores.idproveedor.ToString();
                    
                }
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            
        }

        private bool validado()
        {
            bool valida = false;

            if (cmbFP.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbFP, "Debe elegir la forma de pago");
            }
            else
            {
                errorProvider1.SetError(cmbFP, "");
                if (txtnofactura.Text.Trim()=="")
                {
                    errorProvider1.SetError(txtnofactura, "Ingrese la factura relacionada a la compra");
                }
                else
                {
                    errorProvider1.SetError(txtnofactura, "");
                    if (lblidproveedor.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txtNIT, "No ha ingresado un nit para el proveedor");
                    }
                    else
                    {
                        errorProvider1.SetError(txtNIT, "");
                        if (dataGridView2.Rows.Count == 0)
                        {
                            errorProvider1.SetError(dataGridView2, "No ha ingresado ningún detalle");
                        }
                        else
                        {
                            errorProvider1.SetError(dataGridView2, "");
                            valida = true;
                        }
                        
                    }
                }
            }

            return valida;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validado())
            {

                Entidades.COMPRA compra = new Entidades.COMPRA()
                {
                    PROVEEDOR = int.Parse(lblidproveedor.Text),
                    FECHA = dateTimePickerFechaCompra.Value,
                    TOTAL = decimal.Parse(txttotal.Text),
                    FORMAPAGO = short.Parse(cmbFP.SelectedValue.ToString()),
                    FECHAPAGO = dateTimePickerFechaPago.Value,
                    NOFACTURA = txtnofactura.Text
                };

                if (BL_Compra.agregarcompra(compra))
                {
                    for (int i = 0;  i <= dataGridView2.Rows.Count - 1; i++)
                    {
                        Entidades.COMPRADETA deta = new Entidades.COMPRADETA()
                        {
                            NODETALLE = i + 1,
                            IDCOMPRA = BL_Compra.obtenerultimacompra(),
                            IDINSUMO = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()),
                            PRECIO = decimal.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString()),
                            CANTIDAD = int.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString())
                        };

                        BL_Compra.agregardetalles(deta);
                    }

                    MessageBox.Show("Se registró la compra.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodpro.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtdescpro.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtcosto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtprecio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtcantidad.Text = "0";
            txtsubt.Text = "0.00";
            txtprecio.Select();

        }

        private void txtprecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcantidad.Select();
            }
        }

        private void txtcantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtcantidad.Text.Trim().Equals(""))
                {
                    txtcantidad.Text = "0";
                    txtsubt.Text = "0.00";
                }
                else
                {
                    txtsubt.Text = string.Format("{0:N2}", (double.Parse(txtcantidad.Text) * double.Parse(txtprecio.Text)));
                    btnagregardetalle.PerformClick();
                    txttotal.Text = string.Format("{0:N2}", calculartotal(dataGridView2, 4));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(txtcodpro.Text, txtdescpro.Text, txtcantidad.Text, txtprecio.Text.Trim(), txtsubt.Text);
        }

        private void btneliminardetalle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Desea eliminar este detalle?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            txtcodpro.Clear();
            txtdescpro.Clear();
            txtcosto.Clear();
            txtcosto.Clear();
            txtprecio.Clear();
            txtcantidad.Clear();
            txtsubt.Clear();
            txtbuscar.Clear();
            txtproveedor.Clear();
            txtNIT.Clear();
            txtnofactura.Clear();
            dateTimePickerFechaCompra.Select();
        }

        private double calculartotal(DataGridView dgv, int column)
        {
            double total = 0.00d;

            for (int i = 0; i <= dgv.Rows.Count - 1; i++)
            {
                total += double.Parse(dgv.Rows[i].Cells[column].Value.ToString());
            }

            return total;
        }
    }
}
