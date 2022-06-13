using DocumentFormat.OpenXml.Spreadsheet;
using Logica;
using Microsoft.VisualBasic;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISPRO_TRANSPORTES
{
    public partial class frmVerCompras2 : Form
    {
        Dictionary<int, string> meses = new Dictionary<int, string>();

        private void llenarcmbanios()
        {
            int anioactual = DateTime.Now.Year;

            for (int i = 2020; i <= anioactual; i++)
            {
                cmbanio.Items.Add(i);
            }
        }
        public frmVerCompras2()
        {
            InitializeComponent();
        }

        private void frmVerCompras2_Load(object sender, EventArgs e)
        {
            Logica.BL_Compra.llenardgv(dataGridView1);

            //Combobox
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
            //fin
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (chkmes.Checked)
            {
                int anio = int.Parse(cmbanio.Text);
                int mes = int.Parse(comboBox1.SelectedValue.ToString());
                BL_Compra.llenardgvpormes(dataGridView1, mes, anio);
            }
            else
            {
                if (chkfechas.Checked)
                {
                    DateTime ini = dateTimePicker1.Value;
                    DateTime fin = dateTimePicker2.Value;
                    BL_Compra.llenardgvporfecha(dataGridView1, ini, fin);
                }
                else
                {
                    MessageBox.Show(this, "No ha seleccionado un criterio de búsqueda", "Marque un criterio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
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

        private void button7_Click(object sender, EventArgs e)
        {
            BL_Compra.llenardgv(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre;
            nombre = Interaction.InputBox("Ingrese el nombre del archivo", "Guardando") + ".xlsx";

            SLDocument sl = new SLDocument();


            SLPageSettings ps = new SLPageSettings();

            ps.Orientation = OrientationValues.Landscape;
            ps.PaperSize = SLPaperSizeValues.LetterPaper;
            ps.LeftMargin = 0.2;
            ps.RightMargin = 0.2;


            //Imprimir datagridview

            sl.SetColumnWidth(1, 10);
            sl.SetColumnWidth(2, 10);
            sl.SetColumnWidth(3, 10);
            sl.SetColumnWidth(4, 25);
            sl.SetColumnWidth(5, 10);
            sl.SetColumnWidth(6, 30);
            sl.SetColumnWidth(7, 30);
            sl.SetColumnWidth(8, 10);
            sl.SetColumnWidth(9, 10);
            sl.SetColumnWidth(10, 10);
            sl.SetColumnWidth(11, 10);
            sl.SetColumnWidth(12, 10);
            sl.SetColumnWidth(13, 10);

            sl.SetCellValue("A1", "No.");
            sl.SetCellValue("B1", "Fecha");
            sl.SetCellValue("C1", "No. Factura");
            sl.SetCellValue("D1", "Tipo Documento");
            sl.SetCellValue("E1", "NIT");
            sl.SetCellValue("F1", "Proveedor");
            sl.SetCellValue("G1", "Cuenta Contable");
            sl.SetCellValue("H1", "Galonaje");
            sl.SetCellValue("I1", "IDP");
            sl.SetCellValue("J1", "Total Factura");
            sl.SetCellValue("K1", "Precio neto");
            sl.SetCellValue("L1", "IVA");
            sl.SetCellValue("M1", "Total");

            int iR = 2;
            //int R = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sl.SetCellValue(iR, 1, row.Cells[0].Value.ToString());
                sl.SetCellValue(iR, 2, string.Format("{0:dd/MM/yyyy}", row.Cells[1].Value.ToString()));
                sl.SetCellValue(iR, 3, row.Cells[2].Value.ToString());
                sl.SetCellValue(iR, 4, row.Cells[3].Value.ToString());
                sl.SetCellValue(iR, 5, row.Cells[4].Value.ToString());
                sl.SetCellValue(iR, 6, row.Cells[5].Value.ToString());
                sl.SetCellValue(iR, 7, row.Cells[6].Value.ToString());
                sl.SetCellValue(iR, 8, row.Cells[7].Value.ToString());
                sl.SetCellValue(iR, 9, row.Cells[8].Value.ToString());
                sl.SetCellValue(iR, 10, row.Cells[9].Value.ToString());
                sl.SetCellValue(iR, 11, row.Cells[10].Value.ToString());
                sl.SetCellValue(iR, 12, row.Cells[11].Value.ToString());
                sl.SetCellValue(iR, 13, row.Cells[12].Value.ToString());
                iR++;

            }

            SLTable tbl = sl.CreateTable("A1", string.Format("M{0}", (1 + dataGridView1.Rows.Count).ToString()));
            tbl.SetTableStyle(SLTableStyleTypeValues.Medium9);
            sl.InsertTable(tbl);

            sl.SetPageSettings(ps);

            try
            {
                sl.SaveAs("ReporteCompras\\" + @nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message);
            }


            FileInfo fi = new FileInfo("ReporteCompras\\" + nombre);
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start("ReporteCompras\\" + nombre);
            }
        }
    }
}
