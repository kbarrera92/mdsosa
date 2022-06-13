namespace ISPRO_TRANSPORTES
{
    partial class frmVerViajes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtoncliente = new System.Windows.Forms.RadioButton();
            this.radioButtonusuario = new System.Windows.Forms.RadioButton();
            this.radioButtonpiloto = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbanio = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chkfechas = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkmes = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpilotoviaje = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcantidaddiesel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpagopiloto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtprecioviaje = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcorrelativoviaje = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.pbfacturado = new System.Windows.Forms.PictureBox();
            this.pbpagado = new System.Windows.Forms.PictureBox();
            this.pbdespachado = new System.Windows.Forms.PictureBox();
            this.pbregistrado = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfacturado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpagado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdespachado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbregistrado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1002, 499);
            this.btnSalir.Size = new System.Drawing.Size(126, 29);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1244, 340);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // txtbuscar
            // 
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(13, 38);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(370, 23);
            this.txtbuscar.TabIndex = 2;
            this.txtbuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbuscar_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar:";
            // 
            // radioButtoncliente
            // 
            this.radioButtoncliente.AutoSize = true;
            this.radioButtoncliente.Checked = true;
            this.radioButtoncliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtoncliente.Location = new System.Drawing.Point(452, 12);
            this.radioButtoncliente.Name = "radioButtoncliente";
            this.radioButtoncliente.Size = new System.Drawing.Size(98, 19);
            this.radioButtoncliente.TabIndex = 4;
            this.radioButtoncliente.TabStop = true;
            this.radioButtoncliente.Text = "Por destino";
            this.radioButtoncliente.UseVisualStyleBackColor = true;
            this.radioButtoncliente.CheckedChanged += new System.EventHandler(this.radioButtoncliente_CheckedChanged);
            // 
            // radioButtonusuario
            // 
            this.radioButtonusuario.AutoSize = true;
            this.radioButtonusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonusuario.Location = new System.Drawing.Point(555, 12);
            this.radioButtonusuario.Name = "radioButtonusuario";
            this.radioButtonusuario.Size = new System.Drawing.Size(99, 19);
            this.radioButtonusuario.TabIndex = 5;
            this.radioButtonusuario.Text = "Por usuario";
            this.radioButtonusuario.UseVisualStyleBackColor = true;
            // 
            // radioButtonpiloto
            // 
            this.radioButtonpiloto.AutoSize = true;
            this.radioButtonpiloto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonpiloto.Location = new System.Drawing.Point(452, 39);
            this.radioButtonpiloto.Name = "radioButtonpiloto";
            this.radioButtonpiloto.Size = new System.Drawing.Size(86, 19);
            this.radioButtonpiloto.TabIndex = 6;
            this.radioButtonpiloto.Text = "Por placa";
            this.radioButtonpiloto.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbanio);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.chkfechas);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.chkmes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(671, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Por fecha";
            // 
            // cmbanio
            // 
            this.cmbanio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbanio.FormattingEnabled = true;
            this.cmbanio.Location = new System.Drawing.Point(13, 25);
            this.cmbanio.Name = "cmbanio";
            this.cmbanio.Size = new System.Drawing.Size(117, 23);
            this.cmbanio.TabIndex = 27;
            // 
            // button7
            // 
            this.button7.Image = global::ISPRO_TRANSPORTES.Properties.Resources.Actions_edit_clear_icon1;
            this.button7.Location = new System.Drawing.Point(507, 51);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(28, 25);
            this.button7.TabIndex = 26;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Image = global::ISPRO_TRANSPORTES.Properties.Resources.Zoom_icon;
            this.button5.Location = new System.Drawing.Point(479, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(28, 25);
            this.button5.TabIndex = 25;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(435, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Al:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Del:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(409, 25);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(126, 23);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(276, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 23);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // chkfechas
            // 
            this.chkfechas.AutoSize = true;
            this.chkfechas.Location = new System.Drawing.Point(276, 55);
            this.chkfechas.Name = "chkfechas";
            this.chkfechas.Size = new System.Drawing.Size(134, 19);
            this.chkfechas.TabIndex = 2;
            this.chkfechas.Text = "Rango de fechas";
            this.chkfechas.UseVisualStyleBackColor = true;
            this.chkfechas.CheckedChanged += new System.EventHandler(this.chkfechas_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(136, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // chkmes
            // 
            this.chkmes.AutoSize = true;
            this.chkmes.Location = new System.Drawing.Point(15, 54);
            this.chkmes.Name = "chkmes";
            this.chkmes.Size = new System.Drawing.Size(79, 19);
            this.chkmes.TabIndex = 0;
            this.chkmes.Text = "Por mes";
            this.chkmes.UseVisualStyleBackColor = true;
            this.chkmes.CheckedChanged += new System.EventHandler(this.chkmes_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1002, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Preliquidación";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(870, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Emitir vale";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(168, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Piloto:";
            // 
            // txtpilotoviaje
            // 
            this.txtpilotoviaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpilotoviaje.Location = new System.Drawing.Point(168, 458);
            this.txtpilotoviaje.Name = "txtpilotoviaje";
            this.txtpilotoviaje.Size = new System.Drawing.Size(306, 23);
            this.txtpilotoviaje.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 485);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Cant. Diesel:";
            // 
            // txtcantidaddiesel
            // 
            this.txtcantidaddiesel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcantidaddiesel.Location = new System.Drawing.Point(12, 505);
            this.txtcantidaddiesel.Name = "txtcantidaddiesel";
            this.txtcantidaddiesel.Size = new System.Drawing.Size(150, 23);
            this.txtcantidaddiesel.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 485);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Pago al piloto:";
            // 
            // txtpagopiloto
            // 
            this.txtpagopiloto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpagopiloto.Location = new System.Drawing.Point(168, 505);
            this.txtpagopiloto.Name = "txtpagopiloto";
            this.txtpagopiloto.Size = new System.Drawing.Size(150, 23);
            this.txtpagopiloto.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(324, 485);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Precio del viaje:";
            // 
            // txtprecioviaje
            // 
            this.txtprecioviaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprecioviaje.Location = new System.Drawing.Point(324, 505);
            this.txtprecioviaje.Name = "txtprecioviaje";
            this.txtprecioviaje.Size = new System.Drawing.Size(150, 23);
            this.txtprecioviaje.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 438);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Correlativo:";
            // 
            // txtcorrelativoviaje
            // 
            this.txtcorrelativoviaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcorrelativoviaje.Location = new System.Drawing.Point(10, 458);
            this.txtcorrelativoviaje.Name = "txtcorrelativoviaje";
            this.txtcorrelativoviaje.Size = new System.Drawing.Size(150, 23);
            this.txtcorrelativoviaje.TabIndex = 22;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(870, 499);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 29);
            this.button4.TabIndex = 25;
            this.button4.Text = "Eliminar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ISPRO_TRANSPORTES.Properties.Resources.Sales_report_icon;
            this.pictureBox4.Location = new System.Drawing.Point(820, 506);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 23);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ISPRO_TRANSPORTES.Properties.Resources.Pay_Per_Click_icon;
            this.pictureBox3.Location = new System.Drawing.Point(765, 506);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ISPRO_TRANSPORTES.Properties.Resources.combu;
            this.pictureBox2.Location = new System.Drawing.Point(708, 505);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ISPRO_TRANSPORTES.Properties.Resources.cash_register_2_icon;
            this.pictureBox1.Location = new System.Drawing.Point(653, 506);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.Image = global::ISPRO_TRANSPORTES.Properties.Resources.Actions_edit_clear_icon;
            this.button6.Location = new System.Drawing.Point(410, 37);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(28, 25);
            this.button6.TabIndex = 34;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pbfacturado
            // 
            this.pbfacturado.BackColor = System.Drawing.Color.Transparent;
            this.pbfacturado.Location = new System.Drawing.Point(810, 461);
            this.pbfacturado.Name = "pbfacturado";
            this.pbfacturado.Size = new System.Drawing.Size(46, 41);
            this.pbfacturado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbfacturado.TabIndex = 29;
            this.pbfacturado.TabStop = false;
            this.pbfacturado.Click += new System.EventHandler(this.pbfacturado_Click);
            // 
            // pbpagado
            // 
            this.pbpagado.BackColor = System.Drawing.Color.Transparent;
            this.pbpagado.Location = new System.Drawing.Point(755, 461);
            this.pbpagado.Name = "pbpagado";
            this.pbpagado.Size = new System.Drawing.Size(46, 41);
            this.pbpagado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbpagado.TabIndex = 28;
            this.pbpagado.TabStop = false;
            this.pbpagado.Click += new System.EventHandler(this.pbpagado_Click);
            // 
            // pbdespachado
            // 
            this.pbdespachado.BackColor = System.Drawing.Color.Transparent;
            this.pbdespachado.Location = new System.Drawing.Point(698, 461);
            this.pbdespachado.Name = "pbdespachado";
            this.pbdespachado.Size = new System.Drawing.Size(46, 41);
            this.pbdespachado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbdespachado.TabIndex = 27;
            this.pbdespachado.TabStop = false;
            this.pbdespachado.Click += new System.EventHandler(this.pbdespachado_Click);
            // 
            // pbregistrado
            // 
            this.pbregistrado.BackColor = System.Drawing.Color.Transparent;
            this.pbregistrado.Location = new System.Drawing.Point(643, 461);
            this.pbregistrado.Name = "pbregistrado";
            this.pbregistrado.Size = new System.Drawing.Size(46, 41);
            this.pbregistrado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbregistrado.TabIndex = 26;
            this.pbregistrado.TabStop = false;
            this.pbregistrado.Click += new System.EventHandler(this.pbregistrado_Click);
            // 
            // button3
            // 
            this.button3.Image = global::ISPRO_TRANSPORTES.Properties.Resources.Zoom_icon;
            this.button3.Location = new System.Drawing.Point(383, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 25);
            this.button3.TabIndex = 24;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(555, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 19);
            this.radioButton1.TabIndex = 40;
            this.radioButton1.Text = "Por No. Viaje";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // frmVerViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 533);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.pbfacturado);
            this.Controls.Add(this.pbpagado);
            this.Controls.Add(this.pbdespachado);
            this.Controls.Add(this.pbregistrado);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtcorrelativoviaje);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtprecioviaje);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtpagopiloto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtcantidaddiesel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpilotoviaje);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonpiloto);
            this.Controls.Add(this.radioButtonusuario);
            this.Controls.Add(this.radioButtoncliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbuscar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmVerViajes";
            this.Text = "Listado de viajes";
            this.Load += new System.EventHandler(this.frmVerViajes_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.txtbuscar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.radioButtoncliente, 0);
            this.Controls.SetChildIndex(this.radioButtonusuario, 0);
            this.Controls.SetChildIndex(this.radioButtonpiloto, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.txtpilotoviaje, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtcantidaddiesel, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtpagopiloto, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtprecioviaje, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtcorrelativoviaje, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.pbregistrado, 0);
            this.Controls.SetChildIndex(this.pbdespachado, 0);
            this.Controls.SetChildIndex(this.pbpagado, 0);
            this.Controls.SetChildIndex(this.pbfacturado, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.radioButton1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfacturado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbpagado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdespachado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbregistrado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtoncliente;
        private System.Windows.Forms.RadioButton radioButtonusuario;
        private System.Windows.Forms.RadioButton radioButtonpiloto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkfechas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chkmes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpilotoviaje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcantidaddiesel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtpagopiloto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtprecioviaje;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtcorrelativoviaje;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pbregistrado;
        private System.Windows.Forms.PictureBox pbdespachado;
        private System.Windows.Forms.PictureBox pbpagado;
        private System.Windows.Forms.PictureBox pbfacturado;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox cmbanio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}