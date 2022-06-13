namespace ISPRO_TRANSPORTES
{
    partial class frmAsignarPreliquidacion
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerfecha = new System.Windows.Forms.DateTimePicker();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnfactura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxviajes = new System.Windows.Forms.ListBox();
            this.txtpreliquidacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtbuscarviaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtnoviaje = new System.Windows.Forms.TextBox();
            this.lblviaje = new System.Windows.Forms.Label();
            this.txtvalorviaje = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblidviaje = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerfecha);
            this.panel1.Controls.Add(this.txtdescripcion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtnfactura);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBoxviajes);
            this.panel1.Controls.Add(this.txtpreliquidacion);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 503);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePickerfecha
            // 
            this.dateTimePickerfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerfecha.Location = new System.Drawing.Point(15, 73);
            this.dateTimePickerfecha.Name = "dateTimePickerfecha";
            this.dateTimePickerfecha.Size = new System.Drawing.Size(266, 21);
            this.dateTimePickerfecha.TabIndex = 21;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.Location = new System.Drawing.Point(15, 160);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(266, 21);
            this.txtdescripcion.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "DESCRIPCIÓN";
            // 
            // txtnfactura
            // 
            this.txtnfactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnfactura.Location = new System.Drawing.Point(15, 116);
            this.txtnfactura.Name = "txtnfactura";
            this.txtnfactura.Size = new System.Drawing.Size(266, 21);
            this.txtnfactura.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "NO. FACTURA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "FECHA";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(286, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "GUARDAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "VIAJES ASIGNADOS";
            // 
            // listBoxviajes
            // 
            this.listBoxviajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxviajes.FormattingEnabled = true;
            this.listBoxviajes.ItemHeight = 20;
            this.listBoxviajes.Location = new System.Drawing.Point(13, 213);
            this.listBoxviajes.Name = "listBoxviajes";
            this.listBoxviajes.Size = new System.Drawing.Size(268, 244);
            this.listBoxviajes.TabIndex = 12;
            // 
            // txtpreliquidacion
            // 
            this.txtpreliquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpreliquidacion.Location = new System.Drawing.Point(12, 31);
            this.txtpreliquidacion.Name = "txtpreliquidacion";
            this.txtpreliquidacion.Size = new System.Drawing.Size(269, 21);
            this.txtpreliquidacion.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "NO. PRELIQUIDACIÓN";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(321, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(824, 382);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtbuscarviaje
            // 
            this.txtbuscarviaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscarviaje.Location = new System.Drawing.Point(321, 31);
            this.txtbuscarviaje.Name = "txtbuscarviaje";
            this.txtbuscarviaje.Size = new System.Drawing.Size(236, 21);
            this.txtbuscarviaje.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(318, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "NO. VIAJE";
            // 
            // button2
            // 
            this.button2.Image = global::ISPRO_TRANSPORTES.Properties.Resources.Actions_edit_clear_icon;
            this.button2.Location = new System.Drawing.Point(596, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 24);
            this.button2.TabIndex = 42;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Image = global::ISPRO_TRANSPORTES.Properties.Resources.Zoom_icon;
            this.btnbuscar.Location = new System.Drawing.Point(560, 28);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(30, 24);
            this.btnbuscar.TabIndex = 41;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(859, 447);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(286, 44);
            this.button3.TabIndex = 43;
            this.button3.Text = "AGREGAR A PRELIQUIDACIÓN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtnoviaje
            // 
            this.txtnoviaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnoviaje.Location = new System.Drawing.Point(324, 467);
            this.txtnoviaje.Name = "txtnoviaje";
            this.txtnoviaje.Size = new System.Drawing.Size(174, 21);
            this.txtnoviaje.TabIndex = 45;
            // 
            // lblviaje
            // 
            this.lblviaje.AutoSize = true;
            this.lblviaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblviaje.Location = new System.Drawing.Point(321, 450);
            this.lblviaje.Name = "lblviaje";
            this.lblviaje.Size = new System.Drawing.Size(65, 13);
            this.lblviaje.TabIndex = 44;
            this.lblviaje.Text = "No. VIAJE";
            // 
            // txtvalorviaje
            // 
            this.txtvalorviaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalorviaje.Location = new System.Drawing.Point(536, 467);
            this.txtvalorviaje.Name = "txtvalorviaje";
            this.txtvalorviaje.Size = new System.Drawing.Size(174, 21);
            this.txtvalorviaje.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(533, 450);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "VALOR VIAJE";
            // 
            // lblidviaje
            // 
            this.lblidviaje.AutoSize = true;
            this.lblidviaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidviaje.Location = new System.Drawing.Point(433, 450);
            this.lblidviaje.Name = "lblidviaje";
            this.lblidviaje.Size = new System.Drawing.Size(20, 13);
            this.lblidviaje.TabIndex = 48;
            this.lblidviaje.Text = "ID";
            this.lblidviaje.Visible = false;
            // 
            // frmAsignarPreliquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 503);
            this.Controls.Add(this.lblidviaje);
            this.Controls.Add(this.txtvalorviaje);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtnoviaje);
            this.Controls.Add(this.lblviaje);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.txtbuscarviaje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmAsignarPreliquidacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar viajes a preliquidación";
            this.Load += new System.EventHandler(this.frmAsignarPreliquidacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxviajes;
        private System.Windows.Forms.TextBox txtpreliquidacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtbuscarviaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateTimePickerfecha;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnfactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblidviaje;
        private System.Windows.Forms.TextBox txtvalorviaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtnoviaje;
        private System.Windows.Forms.Label lblviaje;
    }
}