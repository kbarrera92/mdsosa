namespace ISPRO_TRANSPORTES
{
    partial class frmVerPagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txttotalviajes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtidpago = new System.Windows.Forms.TextBox();
            this.txtfechapago = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnodocumento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtquincena = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtviaticos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtentradas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtparqueos = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtdescargas = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtotros = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(684, 567);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(703, 53);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(638, 381);
            this.dataGridView2.TabIndex = 1;
            // 
            // txttotalviajes
            // 
            this.txttotalviajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalviajes.Location = new System.Drawing.Point(1120, 434);
            this.txttotalviajes.Name = "txttotalviajes";
            this.txttotalviajes.Size = new System.Drawing.Size(221, 45);
            this.txttotalviajes.TabIndex = 2;
            this.txttotalviajes.Text = "0.00";
            this.txttotalviajes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar";
            // 
            // txtbuscar
            // 
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(92, 22);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(604, 26);
            this.txtbuscar.TabIndex = 4;
            this.txtbuscar.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(702, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Listado de viajes pagados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1002, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total viajes";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(779, 496);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID";
            // 
            // txtidpago
            // 
            this.txtidpago.Location = new System.Drawing.Point(808, 497);
            this.txtidpago.Name = "txtidpago";
            this.txtidpago.Size = new System.Drawing.Size(100, 20);
            this.txtidpago.TabIndex = 8;
            this.txtidpago.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtfechapago
            // 
            this.txtfechapago.Location = new System.Drawing.Point(808, 523);
            this.txtfechapago.Name = "txtfechapago";
            this.txtfechapago.Size = new System.Drawing.Size(100, 20);
            this.txtfechapago.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(750, 523);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha";
            // 
            // txtnodocumento
            // 
            this.txtnodocumento.Location = new System.Drawing.Point(808, 549);
            this.txtnodocumento.Name = "txtnodocumento";
            this.txtnodocumento.Size = new System.Drawing.Size(100, 20);
            this.txtnodocumento.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(713, 549);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Documento";
            // 
            // txtquincena
            // 
            this.txtquincena.Location = new System.Drawing.Point(808, 575);
            this.txtquincena.Name = "txtquincena";
            this.txtquincena.Size = new System.Drawing.Size(100, 20);
            this.txtquincena.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(725, 575);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Quincena";
            // 
            // txtviaticos
            // 
            this.txtviaticos.Location = new System.Drawing.Point(808, 600);
            this.txtviaticos.Name = "txtviaticos";
            this.txtviaticos.Size = new System.Drawing.Size(100, 20);
            this.txtviaticos.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(737, 601);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Viaticos";
            // 
            // txtentradas
            // 
            this.txtentradas.Location = new System.Drawing.Point(1006, 497);
            this.txtentradas.Name = "txtentradas";
            this.txtentradas.Size = new System.Drawing.Size(100, 20);
            this.txtentradas.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(927, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Entradas";
            // 
            // txtparqueos
            // 
            this.txtparqueos.Location = new System.Drawing.Point(1006, 523);
            this.txtparqueos.Name = "txtparqueos";
            this.txtparqueos.Size = new System.Drawing.Size(100, 20);
            this.txtparqueos.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(931, 524);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Parqueo";
            // 
            // txtdescargas
            // 
            this.txtdescargas.Location = new System.Drawing.Point(1006, 549);
            this.txtdescargas.Name = "txtdescargas";
            this.txtdescargas.Size = new System.Drawing.Size(100, 20);
            this.txtdescargas.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(923, 549);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "Descarga";
            // 
            // txtotros
            // 
            this.txtotros.Location = new System.Drawing.Point(1006, 575);
            this.txtotros.Name = "txtotros";
            this.txtotros.Size = new System.Drawing.Size(100, 20);
            this.txtotros.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(952, 575);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Otros";
            // 
            // txttotal
            // 
            this.txttotal.BackColor = System.Drawing.Color.Blue;
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.ForeColor = System.Drawing.Color.Yellow;
            this.txttotal.Location = new System.Drawing.Point(1120, 575);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(221, 45);
            this.txttotal.TabIndex = 25;
            this.txttotal.Text = "0.00";
            this.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1116, 549);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 24);
            this.label13.TabIndex = 26;
            this.label13.Text = "Total";
            // 
            // frmVerPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 632);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.txtotros);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtdescargas);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtparqueos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtentradas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtviaticos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtquincena);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtnodocumento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtfechapago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtidpago);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttotalviajes);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmVerPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar pagos";
            this.Load += new System.EventHandler(this.frmVerPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txttotalviajes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtidpago;
        private System.Windows.Forms.TextBox txtfechapago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnodocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtquincena;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtviaticos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtentradas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtparqueos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtdescargas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtotros;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label label13;
    }
}