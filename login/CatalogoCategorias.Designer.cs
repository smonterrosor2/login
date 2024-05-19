namespace login
{
    partial class CatalogoCategorias
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
            buttImprimir = new Button();
            txtTotal = new TextBox();
            label5 = new Label();
            dataGridView1 = new DataGridView();
            buttBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Location = new Point(286, 27);
            label1.Name = "label1";
            label1.Size = new Size(155, 15);
            label1.TabIndex = 1;
            label1.Text = "CATALOGO DE CATEGORIAS";
            // 
            // buttImprimir
            // 
            buttImprimir.BackColor = Color.FromArgb(0, 0, 64);
            buttImprimir.FlatAppearance.BorderSize = 0;
            buttImprimir.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 64);
            buttImprimir.FlatAppearance.MouseOverBackColor = Color.Navy;
            buttImprimir.FlatStyle = FlatStyle.Flat;
            buttImprimir.ForeColor = SystemColors.ControlLightLight;
            buttImprimir.Location = new Point(459, 84);
            buttImprimir.Name = "buttImprimir";
            buttImprimir.Size = new Size(116, 30);
            buttImprimir.TabIndex = 131;
            buttImprimir.Text = "Imprimir";
            buttImprimir.UseVisualStyleBackColor = false;
            buttImprimir.Click += buttImprimir_Click_1;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(216, 381);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(245, 23);
            txtTotal.TabIndex = 130;
            txtTotal.TextChanged += txtTotal_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(32, 382);
            label5.Name = "label5";
            label5.Size = new Size(151, 17);
            label5.TabIndex = 129;
            label5.Text = "TOTAL DE PRODUCTOS";
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
            dataGridView1.Location = new Point(32, 144);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(736, 218);
            dataGridView1.TabIndex = 133;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // buttBuscar
            // 
            buttBuscar.BackColor = Color.FromArgb(0, 0, 64);
            buttBuscar.FlatAppearance.BorderSize = 0;
            buttBuscar.FlatStyle = FlatStyle.Flat;
            buttBuscar.ForeColor = SystemColors.ControlLightLight;
            buttBuscar.Location = new Point(174, 84);
            buttBuscar.Name = "buttBuscar";
            buttBuscar.Size = new Size(101, 30);
            buttBuscar.TabIndex = 127;
            buttBuscar.Text = "Buscar";
            buttBuscar.UseVisualStyleBackColor = false;
            buttBuscar.Click += buttBuscar_Click;
            // 
            // CatalogoCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(buttImprimir);
            Controls.Add(txtTotal);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(buttBuscar);
            Controls.Add(label1);
            Name = "CatalogoCategorias";
            Text = "CATALOGO DE USUARIOS";
            Load += CatalogoCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttImprimir;
        private TextBox txtTotal;
        private Label label5;
        private DataGridView dataGridView1;
        private Button buttBuscar;
    }
}