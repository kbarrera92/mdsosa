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
using SpreadsheetLight;
using Microsoft.VisualBasic;
using System.IO;
using SpreadsheetLight.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Configuration;

namespace ISPRO_TRANSPORTES
{
    public partial class frmVerViajes : frmBase
    {
        Dictionary<int, string> meses = new Dictionary<int, string>();

        public frmVerViajes()
        {
            InitializeComponent();

        }

        private void llenarcmbanios()
        {
            int anioactual = DateTime.Now.Year;

            for (int i = 2020; i <= anioactual; i++)
            {
                cmbanio.Items.Add(i);
            }
        }

        private void frmVerViajes_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, "Registrado");
            toolTip1.SetToolTip(pictureBox2, "Combustible despachado");
            toolTip1.SetToolTip(pictureBox3, "Pagado");
            toolTip1.SetToolTip(pictureBox2, "Facturado");
            BL_Viajes.llenardgvviajes(dataGridView1);
            formateardgv(dataGridView1);
            pintar();
            llenarcmbanios();
            meses.Add(1, "Enero");
            meses.Add(2, "Febrero");
            meses.Add(3, "Marzo");
            meses.Add(4, "Abril");
            meses.Add(5, "Mayo");
            meses.Add(6, "Junio");
            meses.Add(7, "Julio");
            meses.Add(8, "Agosto");
            meses.Add(9, "Septiembre");
            meses.Add(10, "Octubre");
            meses.Add(11, "Noviembre");
            meses.Add(12, "Diciembre");

            comboBox1.DataSource = meses.ToList();
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";
            comboBox1.SelectedIndex = 0;
            cmbanio.SelectedIndex = 0;
        }

        private void formateardgv(DataGridView datagrid)
        {
            datagrid.Columns[0].Width = 100;
            datagrid.Columns[0].HeaderText = "Correlativo";

            datagrid.Columns[1].Width = 100;
            datagrid.Columns[1].HeaderText = "No. de Viaje";

            datagrid.Columns[2].Width = 100;
            datagrid.Columns[2].HeaderText = "Folio";

            datagrid.Columns[3].Width = 100;
            datagrid.Columns[3].HeaderText = "Fecha registro";

            datagrid.Columns[4].Width = 250;
            datagrid.Columns[4].HeaderText = "Destino";

            datagrid.Columns[5].Width = 250;
            datagrid.Columns[5].HeaderText = "Origen";

            datagrid.Columns[6].Width = 100;
            datagrid.Columns[6].HeaderText = "Fecha entrega";

            datagrid.Columns[7].Width = 200;
            datagrid.Columns[7].HeaderText = "Piloto";

            datagrid.Columns[8].Width = 100;
            datagrid.Columns[8].HeaderText = "Placa";

            datagrid.Columns[9].Width = 100;
            datagrid.Columns[9].HeaderText = "Pago piloto";

            datagrid.Columns[10].Width = 100;
            datagrid.Columns[10].HeaderText = "Cant. Diesel";

            datagrid.Columns[11].Width = 100;
            datagrid.Columns[11].HeaderText = "Precio viaje";

            datagrid.Columns[12].Width = 250;
            datagrid.Columns[12].HeaderText = "Usuario";

            datagrid.Columns[13].Width = 100;
            datagrid.Columns[13].HeaderText = "Registrado";

            datagrid.Columns[14].Width = 100;
            datagrid.Columns[14].HeaderText = "Despachado";

            datagrid.Columns[15].Width = 100;
            datagrid.Columns[15].HeaderText = "Pagado";

            datagrid.Columns[16].Width = 100;
            datagrid.Columns[16].HeaderText = "Facturado";

            datagrid.Columns[17].Width = 100;
            datagrid.Columns[17].HeaderText = "TN Movidas";

            datagrid.Columns[18].Width = 100;
            datagrid.Columns[18].HeaderText = "Kilometraje";

                      
        }

        private void pintar()
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                
                
                if (item.Cells[13].Value.ToString().Equals("True") && item.Cells[14].Value.ToString().Equals("True") && item.Cells[15].Value.ToString().Equals("True") && item.Cells[16].Value.ToString().Equals("True"))
                {
                    item.DefaultCellStyle.BackColor = System.Drawing.Color.SpringGreen;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcorrelativoviaje.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            txtpilotoviaje.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtcantidaddiesel.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtpagopiloto.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtprecioviaje.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            //txtutilidad.Text = Convert.ToString(decimal.Parse(txtprecioviaje.Text) - (decimal.Parse(txtcantidaddiesel.Text) + decimal.Parse(txtpagopiloto.Text)));
            if (dataGridView1.CurrentRow.Cells[13].Value.ToString() != "True")
            {
                pbregistrado.Image = Properties.Resources.Button_Close_icon;
            }
            else
            {
                pbregistrado.Image = Properties.Resources.Button_Ok_icon;
            }

            //Despachado
            if (dataGridView1.CurrentRow.Cells[14].Value.ToString() != "True")
            {
                pbdespachado.Image = Properties.Resources.Button_Close_icon;
            }
            else
            {
                pbdespachado.Image = Properties.Resources.Button_Ok_icon;
            }

            //Pagado
            if (dataGridView1.CurrentRow.Cells[15].Value.ToString() != "True")
            {
                pbpagado.Image = Properties.Resources.Button_Close_icon;
            }
            else
            {
                pbpagado.Image = Properties.Resources.Button_Ok_icon;
            }

            //Facturado
            if (dataGridView1.CurrentRow.Cells[16].Value.ToString() != "True")
            {
                pbfacturado.Image = Properties.Resources.Button_Close_icon;
            }
            else
            {
                pbfacturado.Image = Properties.Resources.Button_Ok_icon;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {

            if (radioButtoncliente.Checked)
            {
                BL_Viajes.filtrarxcliente(dataGridView1, txtbuscar.Text.Trim());
            }
            else
            {
                if (radioButtonpiloto.Checked)
                {
                    BL_Viajes.filtrarxpiloto(dataGridView1, txtbuscar.Text.Trim());
                }
                else
                {
                    BL_Viajes.filtrarxusuario(dataGridView1, txtbuscar.Text.Trim());
                    if (radioButton1.Checked)
                    {
                        BL_Viajes.filtrarxnoviaje(dataGridView1, txtbuscar.Text.Trim());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtcorrelativoviaje.Text.Trim().Equals(""))
            {
                MessageBox.Show(this, "No ha elegido ningún viaje", "Elija un viaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (BL_Viajes.obtenerdespachado(int.Parse(txtcorrelativoviaje.Text.Trim())))
                {
                    MessageBox.Show(this, "El viaje ya tiene registrado un vale", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    BL_Viajes.correlativo = long.Parse(txtcorrelativoviaje.Text);
                    frmValeCombustible vale = new frmValeCombustible();
                    vale.ShowDialog();
                    if (vale.DialogResult.Equals(DialogResult.OK))
                    {
                        BL_Viajes.llenardgvviajes(dataGridView1);
                        
                        
                    }
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!txtcorrelativoviaje.Text.Trim().Equals(""))
            {
                if (MessageBox.Show(this, "¿Desea eliminar este viaje?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    BL_Viajes.dardebajaviaje(int.Parse(txtcorrelativoviaje.Text));
                    BL_Viajes.llenardgvviajes(dataGridView1);
                }

            }
            else
            {
                MessageBox.Show(this, "No se ha elegido ningún viaje", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pbdespachado_Click(object sender, EventArgs e)
        {
            if (!BL_Vales.obtenernovale(long.Parse(txtcorrelativoviaje.Text)).Equals(0))
            {
                frmNoVale novale = new frmNoVale();
                novale.label1.Text += BL_Vales.obtenernovale(long.Parse(txtcorrelativoviaje.Text));
                novale.label2.Text += BL_Vales.obtenermontovale(long.Parse(txtcorrelativoviaje.Text));
                novale.label3.Text += BL_Vales.obtenerfechavale(long.Parse(txtcorrelativoviaje.Text));
                novale.Show();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (chkmes.Checked)
            {
                int anio = int.Parse(cmbanio.Text);
                int mes = int.Parse(comboBox1.SelectedValue.ToString());
                BL_Viajes.filtrarpormes(dataGridView1, mes, anio);
            }
            else
            {
                if (chkfechas.Checked)
                {
                    DateTime ini = dateTimePicker1.Value;
                    DateTime fin = dateTimePicker2.Value;
                    BL_Viajes.filtrarporfechas(dataGridView1, ini, fin);
                }
                else
                {
                    MessageBox.Show(this, "No ha seleccionado un criterio de búsqueda", "Marque un criterio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void radioButtoncliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkmes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmes.Checked == false)
            {
                chkfechas.Checked = true;
            }
            else
            {
                chkmes.Checked = true;
                chkfechas.Checked = false;
            }
        }

        private void chkfechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfechas.Checked == false)
            {
                chkmes.Checked = true;
            }
            else
            {
                chkmes.Checked = false;
                chkfechas.Checked = true;
            }
        }

        

        private void pbregistrado_Click(object sender, EventArgs e)
        {

        }

        private void pbpagado_Click(object sender, EventArgs e)
        {
            if (!BL_Vales.obtenerpago(long.Parse(txtcorrelativoviaje.Text)).Equals(""))
            {
                frmNoChequePagoPiloto novale = new frmNoChequePagoPiloto();
                novale.label1.Text += BL_Vales.obtenerpago(long.Parse(txtcorrelativoviaje.Text));
                novale.label2.Text += BL_Vales.obtenerpagoimporte(long.Parse(txtcorrelativoviaje.Text));
                novale.label3.Text += BL_Vales.obtenerfecha(long.Parse(txtcorrelativoviaje.Text));
                novale.Show();
            }
                
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre;
            nombre = Interaction.InputBox("Ingrese el nombre del archivo", "Guardando")+ ".xlsx";

            SLDocument sl = new SLDocument();
            SLPicture pic = new SLPicture("c:/Preliquidaciones/cemex.png");

            SLPageSettings ps = new SLPageSettings();

            ps.Orientation = OrientationValues.Landscape;
            ps.PaperSize = SLPaperSizeValues.LetterPaper;
            ps.LeftMargin = 0.2;
            ps.RightMargin = 0.2;

            pic.SetPosition(0, 0);
            pic.ResizeInPixels(200, 60);
            sl.InsertPicture(pic);

            sl.SetCellValue("A4", "Transportista");
            sl.SetCellValue("D4", "Mynor David Sosa Rodríguez");

            sl.SetCellValue("A6", "Fecha Preliquidación");
            sl.SetCellValue("D6", DateTime.Now.ToShortDateString());
                        
            SLStyle style = sl.CreateStyle();
            style.Font.FontSize = 14;            
            style.Font.Bold = true;
            sl.SetCellStyle("A4", style);
            sl.SetCellStyle("D4", style);

            sl.SetCellStyle("A6", style);
            sl.SetCellStyle("D6", style);


            
            //Imprimir datagridview

            sl.SetColumnWidth(1, 10);
            sl.SetColumnWidth(2, 15);
            sl.SetColumnWidth(3, 10);
            sl.SetColumnWidth(4, 10);
            sl.SetColumnWidth(5, 10);

            sl.SetColumnWidth(6, 30);
            sl.SetColumnWidth(7, 30);
            sl.SetColumnWidth(8, 10);

            sl.SetCellValue("A8", "No.");
            sl.SetCellValue("B8", "Fecha Remisión");
            sl.SetCellValue("C8", "PLACA");
            sl.SetCellValue("D8", "Remisión");
            sl.SetCellValue("E8", "No. Viaje");
            sl.SetCellValue("F8", "ORIGEN");
            sl.SetCellValue("G8", "DESTINO");
            sl.SetCellValue("H8", "TN Movidas");

            int iR = 9;
            int R = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[16].Value) == false)
                {
                    sl.SetCellValue(iR, 1, R);
                    sl.SetCellValue(iR, 2, row.Cells[3].Value.ToString());
                    sl.SetCellValue(iR, 3, row.Cells[8].Value.ToString());
                    sl.SetCellValue(iR, 4, row.Cells[2].Value.ToString());
                    sl.SetCellValue(iR, 5, row.Cells[1].Value.ToString());
                    sl.SetCellValue(iR, 6, row.Cells[5].Value.ToString());
                    sl.SetCellValue(iR, 7, row.Cells[4].Value.ToString());
                    sl.SetCellValue(iR, 8, row.Cells[17].Value.ToString());
                    iR++;
                    R++;
                }
                
            }

            SLTable tbl = sl.CreateTable("A8", string.Format("H{0}", (8 + R - 1)));
            tbl.SetTableStyle(SLTableStyleTypeValues.Medium9);
            sl.InsertTable(tbl);

            sl.SetPageSettings(ps);

            try
            {
                sl.SaveAs("c:\\Preliquidaciones\\" + @nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);               
            }
            

            FileInfo fi = new FileInfo("c:\\Preliquidaciones\\" + nombre);
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start("c:\\Preliquidaciones\\" + nombre);
            }

        }

        private void pbfacturado_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe elegir un viaje", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (dataGridView1.CurrentRow.Cells[16].Value.ToString().Equals("False"))
                {
                    MessageBox.Show("El viaje no se ha agregado a una preliquidación", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                frmNoPreliquidacion preliq = new frmNoPreliquidacion();
                preliq.label2.Text += txtprecioviaje.Text;
                preliq.label1.Text += BL_Vales.obtenernopreliq(long.Parse(txtcorrelativoviaje.Text)).ToString();
                preliq.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BL_Viajes.llenardgvviajes(dataGridView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BL_Viajes.llenardgvviajes(dataGridView1);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (bool.Parse(item.Cells[13].Value.ToString()) && bool.Parse(item.Cells[14].Value.ToString()) && bool.Parse(item.Cells[15].Value.ToString()) && bool.Parse(item.Cells[16].Value.ToString()))
                {
                    item.DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
                }
            }
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }
    }
}
