namespace login
{
    partial class CategoriaProductos
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
            buttModificar = new Button();
            buttEliminar = new Button();
            buttGuardar = new Button();
            buttNuevo = new Button();
            textNombre = new TextBox();
            labelNombre = new Label();
            labelCategoria = new Label();
            textCategoria = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            labelDescripcion = new Label();
            textDescripcion = new TextBox();
            SuspendLayout();
            // 
            // buttModificar
            // 
            buttModificar.BackColor = Color.FromArgb(0, 0, 64);
            buttModificar.FlatStyle = FlatStyle.Flat;
            buttModificar.ForeColor = SystemColors.ControlLightLight;
            buttModificar.Location = new Point(1027, 774);
            buttModificar.Margin = new Padding(4, 5, 4, 5);
            buttModificar.Name = "buttModificar";
            buttModificar.Size = new Size(166, 50);
            buttModificar.TabIndex = 40;
            buttModificar.Text = "Modificar";
            buttModificar.UseVisualStyleBackColor = false;
            // 
            // buttEliminar
            // 
            buttEliminar.BackColor = Color.FromArgb(0, 0, 64);
            buttEliminar.FlatAppearance.BorderSize = 0;
            buttEliminar.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 64);
            buttEliminar.FlatAppearance.MouseOverBackColor = Color.Navy;
            buttEliminar.FlatStyle = FlatStyle.Flat;
            buttEliminar.ForeColor = SystemColors.ControlLightLight;
            buttEliminar.Location = new Point(755, 774);
            buttEliminar.Margin = new Padding(4, 5, 4, 5);
            buttEliminar.Name = "buttEliminar";
            buttEliminar.Size = new Size(166, 50);
            buttEliminar.TabIndex = 39;
            buttEliminar.Text = "Eliminar";
            buttEliminar.UseVisualStyleBackColor = false;
            // 
            // buttGuardar
            // 
            buttGuardar.BackColor = Color.FromArgb(0, 0, 64);
            buttGuardar.FlatAppearance.BorderSize = 0;
            buttGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 64);
            buttGuardar.FlatAppearance.MouseOverBackColor = Color.Navy;
            buttGuardar.FlatStyle = FlatStyle.Flat;
            buttGuardar.ForeColor = SystemColors.ControlLightLight;
            buttGuardar.Location = new Point(459, 774);
            buttGuardar.Margin = new Padding(4, 5, 4, 5);
            buttGuardar.Name = "buttGuardar";
            buttGuardar.Size = new Size(166, 50);
            buttGuardar.TabIndex = 38;
            buttGuardar.Text = "Guardar";
            buttGuardar.UseVisualStyleBackColor = false;
            // 
            // buttNuevo
            // 
            buttNuevo.BackColor = Color.FromArgb(0, 0, 64);
            buttNuevo.FlatAppearance.BorderSize = 0;
            buttNuevo.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 64);
            buttNuevo.FlatAppearance.MouseOverBackColor = Color.Navy;
            buttNuevo.FlatStyle = FlatStyle.Flat;
            buttNuevo.ForeColor = SystemColors.ControlLightLight;
            buttNuevo.Location = new Point(183, 774);
            buttNuevo.Margin = new Padding(4, 5, 4, 5);
            buttNuevo.Name = "buttNuevo";
            buttNuevo.Size = new Size(166, 50);
            buttNuevo.TabIndex = 37;
            buttNuevo.Text = "Nuevo";
            buttNuevo.UseVisualStyleBackColor = false;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(401, 354);
            textNombre.Margin = new Padding(4, 5, 4, 5);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(669, 31);
            textNombre.TabIndex = 31;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNombre.ForeColor = SystemColors.ControlLightLight;
            labelNombre.Location = new Point(254, 356);
            labelNombre.Margin = new Padding(4, 0, 4, 0);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(94, 28);
            labelNombre.TabIndex = 30;
            labelNombre.Text = "Nombre:";
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCategoria.ForeColor = SystemColors.ControlLightLight;
            labelCategoria.Location = new Point(254, 241);
            labelCategoria.Margin = new Padding(4, 0, 4, 0);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(108, 28);
            labelCategoria.TabIndex = 27;
            labelCategoria.Text = "Categoría:";
            // 
            // textCategoria
            // 
            textCategoria.Location = new Point(401, 239);
            textCategoria.Margin = new Padding(4, 5, 4, 5);
            textCategoria.Name = "textCategoria";
            textCategoria.Size = new Size(669, 31);
            textCategoria.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Fluent Icons", 18F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(548, 88);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(330, 36);
            label3.TabIndex = 25;
            label3.Text = "Categoría de Productos";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(557, 192);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(206, 76);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 23;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDescripcion.ForeColor = SystemColors.ControlLightLight;
            labelDescripcion.Location = new Point(254, 474);
            labelDescripcion.Margin = new Padding(4, 0, 4, 0);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(128, 28);
            labelDescripcion.TabIndex = 32;
            labelDescripcion.Text = "Descripción:";
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(401, 471);
            textDescripcion.Margin = new Padding(4, 5, 4, 5);
            textDescripcion.Multiline = true;
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(669, 147);
            textDescripcion.TabIndex = 41;
            // 
            // CategoriaProductos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1350, 1040);
            Controls.Add(textDescripcion);
            Controls.Add(buttModificar);
            Controls.Add(buttEliminar);
            Controls.Add(buttGuardar);
            Controls.Add(buttNuevo);
            Controls.Add(labelDescripcion);
            Controls.Add(textNombre);
            Controls.Add(labelNombre);
            Controls.Add(labelCategoria);
            Controls.Add(textCategoria);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CategoriaProductos";
            Text = "CategoriaProductos";
            Load += CategoriaProductos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textDescripcion;
        private Button buttModificar;
        private Button buttEliminar;
        private Button buttGuardar;
        private Button buttNuevo;
        private Label labelDescripcion;
        private TextBox textNombre;
        private Label labelNombre;
        private Label labelCategoria;
        private TextBox textCategoria;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}