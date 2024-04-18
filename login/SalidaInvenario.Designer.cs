namespace login
{
    partial class SalidaInvenario
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
            label3 = new Label();
            textSubTotal = new TextBox();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            buttInsertar = new Button();
            buttBuscar = new Button();
            textTotal = new TextBox();
            label10 = new Label();
            textCantidad2 = new TextBox();
            label11 = new Label();
            label9 = new Label();
            textNoDoc = new TextBox();
            label8 = new Label();
            textFecha = new TextBox();
            textCosto = new TextBox();
            label7 = new Label();
            textCantidad = new TextBox();
            label5 = new Label();
            textExistencia = new TextBox();
            label4 = new Label();
            textObservacion = new TextBox();
            label1 = new Label();
            buttNuevo = new Button();
            buttEliminar = new Button();
            buttLimpiar = new Button();
            buttImprimir = new Button();
            textDescripcion = new TextBox();
            labelNombre = new Label();
            labelCategoria = new Label();
            textCodigo = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Fluent Icons", 18F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(341, 25);
            label3.Name = "label3";
            label3.Size = new Size(197, 24);
            label3.TabIndex = 45;
            label3.Text = "Salida del Inventario";
            // 
            // textSubTotal
            // 
            textSubTotal.Location = new Point(671, 167);
            textSubTotal.Name = "textSubTotal";
            textSubTotal.Size = new Size(81, 23);
            textSubTotal.TabIndex = 108;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(599, 168);
            label6.Name = "label6";
            label6.Size = new Size(66, 17);
            label6.TabIndex = 107;
            label6.Text = "SubTotal:";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Location = new Point(98, 209);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(736, 127);
            dataGridView1.TabIndex = 106;
            // 
            // buttInsertar
            // 
            buttInsertar.BackColor = Color.FromArgb(0, 0, 64);
            buttInsertar.FlatAppearance.BorderSize = 0;
            buttInsertar.FlatStyle = FlatStyle.Flat;
            buttInsertar.ForeColor = SystemColors.ControlLightLight;
            buttInsertar.Location = new Point(768, 165);
            buttInsertar.Name = "buttInsertar";
            buttInsertar.Size = new Size(66, 25);
            buttInsertar.TabIndex = 105;
            buttInsertar.Text = "Insertar";
            buttInsertar.UseVisualStyleBackColor = false;
            // 
            // buttBuscar
            // 
            buttBuscar.BackColor = Color.FromArgb(0, 0, 64);
            buttBuscar.FlatAppearance.BorderSize = 0;
            buttBuscar.FlatStyle = FlatStyle.Flat;
            buttBuscar.ForeColor = SystemColors.ControlLightLight;
            buttBuscar.Location = new Point(309, 115);
            buttBuscar.Name = "buttBuscar";
            buttBuscar.Size = new Size(66, 25);
            buttBuscar.TabIndex = 104;
            buttBuscar.Text = "Buscar";
            buttBuscar.UseVisualStyleBackColor = false;
            buttBuscar.Click += buttBuscar_Click;
            // 
            // textTotal
            // 
            textTotal.Location = new Point(753, 359);
            textTotal.Name = "textTotal";
            textTotal.Size = new Size(81, 23);
            textTotal.TabIndex = 103;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(704, 359);
            label10.Name = "label10";
            label10.Size = new Size(43, 17);
            label10.TabIndex = 102;
            label10.Text = "Total:";
            // 
            // textCantidad2
            // 
            textCantidad2.Location = new Point(595, 360);
            textCantidad2.Name = "textCantidad2";
            textCantidad2.Size = new Size(81, 23);
            textCantidad2.TabIndex = 101;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ControlLightLight;
            label11.Location = new Point(522, 361);
            label11.Name = "label11";
            label11.Size = new Size(67, 17);
            label11.TabIndex = 100;
            label11.Text = "Cantidad:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(248, 69);
            label9.Name = "label9";
            label9.Size = new Size(110, 17);
            label9.TabIndex = 99;
            label9.Text = "No. Documento:";
            // 
            // textNoDoc
            // 
            textNoDoc.Location = new Point(364, 68);
            textNoDoc.Name = "textNoDoc";
            textNoDoc.ReadOnly = true;
            textNoDoc.Size = new Size(152, 23);
            textNoDoc.TabIndex = 98;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(98, 68);
            label8.Name = "label8";
            label8.Size = new Size(47, 17);
            label8.TabIndex = 97;
            label8.Text = "Fecha:";
            // 
            // textFecha
            // 
            textFecha.Location = new Point(151, 68);
            textFecha.Name = "textFecha";
            textFecha.ReadOnly = true;
            textFecha.Size = new Size(80, 23);
            textFecha.TabIndex = 96;
            // 
            // textCosto
            // 
            textCosto.Location = new Point(487, 165);
            textCosto.Name = "textCosto";
            textCosto.Size = new Size(81, 23);
            textCosto.TabIndex = 95;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(434, 166);
            label7.Name = "label7";
            label7.Size = new Size(47, 17);
            label7.TabIndex = 94;
            label7.Text = "Costo:";
            // 
            // textCantidad
            // 
            textCantidad.Location = new Point(342, 166);
            textCantidad.Name = "textCantidad";
            textCantidad.Size = new Size(66, 23);
            textCantidad.TabIndex = 93;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(269, 167);
            label5.Name = "label5";
            label5.Size = new Size(67, 17);
            label5.TabIndex = 92;
            label5.Text = "Cantidad:";
            // 
            // textExistencia
            // 
            textExistencia.Location = new Point(182, 167);
            textExistencia.Name = "textExistencia";
            textExistencia.Size = new Size(66, 23);
            textExistencia.TabIndex = 91;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(97, 168);
            label4.Name = "label4";
            label4.Size = new Size(79, 17);
            label4.TabIndex = 90;
            label4.Text = "Existencias:";
            // 
            // textObservacion
            // 
            textObservacion.Location = new Point(206, 360);
            textObservacion.Name = "textObservacion";
            textObservacion.Size = new Size(292, 23);
            textObservacion.TabIndex = 89;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(98, 361);
            label1.Name = "label1";
            label1.Size = new Size(102, 17);
            label1.TabIndex = 88;
            label1.Text = "Observaciones:";
            // 
            // buttNuevo
            // 
            buttNuevo.BackColor = Color.FromArgb(0, 0, 64);
            buttNuevo.FlatAppearance.BorderSize = 0;
            buttNuevo.FlatStyle = FlatStyle.Flat;
            buttNuevo.ForeColor = SystemColors.ControlLightLight;
            buttNuevo.Location = new Point(364, 432);
            buttNuevo.Name = "buttNuevo";
            buttNuevo.Size = new Size(116, 30);
            buttNuevo.TabIndex = 87;
            buttNuevo.Text = "Nuevo";
            buttNuevo.UseVisualStyleBackColor = false;
            // 
            // buttEliminar
            // 
            buttEliminar.BackColor = Color.FromArgb(0, 0, 64);
            buttEliminar.FlatAppearance.BorderSize = 0;
            buttEliminar.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 64);
            buttEliminar.FlatAppearance.MouseOverBackColor = Color.DarkRed;
            buttEliminar.FlatStyle = FlatStyle.Flat;
            buttEliminar.ForeColor = SystemColors.ControlLightLight;
            buttEliminar.Location = new Point(636, 432);
            buttEliminar.Name = "buttEliminar";
            buttEliminar.Size = new Size(116, 30);
            buttEliminar.TabIndex = 86;
            buttEliminar.Text = "Eliminar";
            buttEliminar.UseVisualStyleBackColor = false;
            // 
            // buttLimpiar
            // 
            buttLimpiar.BackColor = Color.FromArgb(0, 0, 64);
            buttLimpiar.FlatAppearance.BorderSize = 0;
            buttLimpiar.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 64);
            buttLimpiar.FlatAppearance.MouseOverBackColor = Color.Navy;
            buttLimpiar.FlatStyle = FlatStyle.Flat;
            buttLimpiar.ForeColor = SystemColors.ControlLightLight;
            buttLimpiar.Location = new Point(500, 432);
            buttLimpiar.Name = "buttLimpiar";
            buttLimpiar.Size = new Size(116, 30);
            buttLimpiar.TabIndex = 85;
            buttLimpiar.Text = "Limpiar";
            buttLimpiar.UseVisualStyleBackColor = false;
            // 
            // buttImprimir
            // 
            buttImprimir.BackColor = Color.FromArgb(0, 0, 64);
            buttImprimir.FlatAppearance.BorderSize = 0;
            buttImprimir.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 64);
            buttImprimir.FlatAppearance.MouseOverBackColor = Color.Navy;
            buttImprimir.FlatStyle = FlatStyle.Flat;
            buttImprimir.ForeColor = SystemColors.ControlLightLight;
            buttImprimir.Location = new Point(225, 432);
            buttImprimir.Name = "buttImprimir";
            buttImprimir.Size = new Size(116, 30);
            buttImprimir.TabIndex = 84;
            buttImprimir.Text = "Imprimir";
            buttImprimir.UseVisualStyleBackColor = false;
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(478, 117);
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(356, 23);
            textDescripcion.TabIndex = 83;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNombre.ForeColor = SystemColors.ControlLightLight;
            labelNombre.Location = new Point(388, 117);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(84, 17);
            labelNombre.TabIndex = 82;
            labelNombre.Text = "Descripción:";
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCategoria.ForeColor = SystemColors.ControlLightLight;
            labelCategoria.Location = new Point(96, 118);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(56, 17);
            labelCategoria.TabIndex = 81;
            labelCategoria.Text = "Código:";
            // 
            // textCodigo
            // 
            textCodigo.Location = new Point(160, 117);
            textCodigo.Name = "textCodigo";
            textCodigo.Size = new Size(143, 23);
            textCodigo.TabIndex = 80;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(324, 37);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 79;
            // 
            // SalidaInvenario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(930, 499);
            Controls.Add(textSubTotal);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Controls.Add(buttInsertar);
            Controls.Add(buttBuscar);
            Controls.Add(textTotal);
            Controls.Add(label10);
            Controls.Add(textCantidad2);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(textNoDoc);
            Controls.Add(label8);
            Controls.Add(textFecha);
            Controls.Add(textCosto);
            Controls.Add(label7);
            Controls.Add(textCantidad);
            Controls.Add(label5);
            Controls.Add(textExistencia);
            Controls.Add(label4);
            Controls.Add(textObservacion);
            Controls.Add(label1);
            Controls.Add(buttNuevo);
            Controls.Add(buttEliminar);
            Controls.Add(buttLimpiar);
            Controls.Add(buttImprimir);
            Controls.Add(textDescripcion);
            Controls.Add(labelNombre);
            Controls.Add(labelCategoria);
            Controls.Add(textCodigo);
            Controls.Add(label2);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalidaInvenario";
            Text = "SalidaInvenario";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox textSubTotal;
        private Label label6;
        private DataGridView dataGridView1;
        private Button buttInsertar;
        private Button buttBuscar;
        private TextBox textTotal;
        private Label label10;
        private TextBox textCantidad2;
        private Label label11;
        private Label label9;
        private TextBox textNoDoc;
        private Label label8;
        private TextBox textFecha;
        private TextBox textCosto;
        private Label label7;
        private TextBox textCantidad;
        private Label label5;
        private TextBox textExistencia;
        private Label label4;
        private TextBox textObservacion;
        private Label label1;
        private Button buttNuevo;
        private Button buttEliminar;
        private Button buttLimpiar;
        private Button buttImprimir;
        private TextBox textDescripcion;
        private Label labelNombre;
        private Label labelCategoria;
        private TextBox textCodigo;
        private Label label2;
    }
}