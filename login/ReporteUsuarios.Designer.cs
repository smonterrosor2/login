namespace login
{
    partial class ReporteUsuarios
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
            label1 = new Label();
            buttBuscar = new Button();
            buttImprimir = new Button();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            txtTotal = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Location = new Point(327, 29);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 2;
            label1.Text = "Catalogo Usuarios";
            // 
            // buttBuscar
            // 
            buttBuscar.BackColor = Color.FromArgb(0, 0, 64);
            buttBuscar.FlatAppearance.BorderSize = 0;
            buttBuscar.FlatStyle = FlatStyle.Flat;
            buttBuscar.ForeColor = SystemColors.ControlLightLight;
            buttBuscar.Location = new Point(192, 91);
            buttBuscar.Name = "buttBuscar";
            buttBuscar.Size = new Size(101, 30);
            buttBuscar.TabIndex = 128;
            buttBuscar.Text = "Buscar";
            buttBuscar.UseVisualStyleBackColor = false;
            buttBuscar.Click += buttBuscar_Click;
            // 
            // buttImprimir
            // 
            buttImprimir.BackColor = Color.FromArgb(0, 0, 64);
            buttImprimir.FlatAppearance.BorderSize = 0;
            buttImprimir.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 64);
            buttImprimir.FlatAppearance.MouseOverBackColor = Color.Navy;
            buttImprimir.FlatStyle = FlatStyle.Flat;
            buttImprimir.ForeColor = SystemColors.ControlLightLight;
            buttImprimir.Location = new Point(477, 91);
            buttImprimir.Name = "buttImprimir";
            buttImprimir.Size = new Size(116, 30);
            buttImprimir.TabIndex = 132;
            buttImprimir.Text = "Imprimir";
            buttImprimir.UseVisualStyleBackColor = false;
            buttImprimir.Click += buttImprimir_Click_2;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridView1.Location = new Point(27, 153);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView1.Size = new Size(736, 162);
            dataGridView1.TabIndex = 133;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(27, 340);
            label5.Name = "label5";
            label5.Size = new Size(136, 17);
            label5.TabIndex = 134;
            label5.Text = "TOTAL DE USUARIOS";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(189, 338);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(245, 23);
            txtTotal.TabIndex = 135;
            txtTotal.TextChanged += txtTotal_TextChanged;
            // 
            // ReporteUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(txtTotal);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(buttImprimir);
            Controls.Add(buttBuscar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReporteUsuarios";
            Text = "ReporteUsuarios";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttBuscar;
        private Button buttImprimir;
        private DataGridView dataGridView1;
        private Label label5;
        private TextBox txtTotal;
    }
}