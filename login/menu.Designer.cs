using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    partial class menu
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(menu));
            panelSideMenu = new Panel();
            panelConfigSubMenu = new Panel();
            button14 = new Button();
            btnConfiguracion = new Button();
            panelReportesSubMenu = new Panel();
            btnKardex = new Button();
            btnRExistencias = new Button();
            btnStocks = new Button();
            btnRICatalogos = new Button();
            panelProcesosSubMenu = new Panel();
            btnSInventario = new Button();
            btnEinventario = new Button();
            btnProcesos = new Button();
            panelCatalogosSubMenu = new Panel();
            btnMMarca = new Button();
            btnCProdutos = new Button();
            btnMProductos = new Button();
            btnCatalogos = new Button();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panelcontenedorForm = new Panel();
            panelSideMenu.SuspendLayout();
            panelConfigSubMenu.SuspendLayout();
            panelReportesSubMenu.SuspendLayout();
            panelProcesosSubMenu.SuspendLayout();
            panelCatalogosSubMenu.SuspendLayout();
            panel3.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.AutoScroll = true;
            panelSideMenu.BackColor = Color.FromArgb(0, 0, 64);
            panelSideMenu.Controls.Add(panelConfigSubMenu);
            panelSideMenu.Controls.Add(btnConfiguracion);
            panelSideMenu.Controls.Add(panelReportesSubMenu);
            panelSideMenu.Controls.Add(btnRICatalogos);
            panelSideMenu.Controls.Add(panelProcesosSubMenu);
            panelSideMenu.Controls.Add(btnProcesos);
            panelSideMenu.Controls.Add(panelCatalogosSubMenu);
            panelSideMenu.Controls.Add(btnCatalogos);
            panelSideMenu.Controls.Add(panel3);
            panelSideMenu.Controls.Add(panel1);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(268, 866);
            panelSideMenu.TabIndex = 0;
            // 
            // panelConfigSubMenu
            // 
            panelConfigSubMenu.BackColor = Color.Navy;
            panelConfigSubMenu.Controls.Add(button14);
            panelConfigSubMenu.Dock = DockStyle.Top;
            panelConfigSubMenu.Location = new Point(0, 716);
            panelConfigSubMenu.Name = "panelConfigSubMenu";
            panelConfigSubMenu.Size = new Size(268, 54);
            panelConfigSubMenu.TabIndex = 9;
            // 
            // button14
            // 
            button14.Dock = DockStyle.Top;
            button14.FlatAppearance.BorderSize = 0;
            button14.FlatStyle = FlatStyle.Flat;
            button14.ForeColor = SystemColors.ControlLightLight;
            button14.Location = new Point(0, 0);
            button14.Name = "button14";
            button14.Padding = new Padding(35, 0, 0, 0);
            button14.Size = new Size(268, 41);
            button14.TabIndex = 0;
            button14.Text = "Usuarios";
            button14.TextAlign = ContentAlignment.MiddleLeft;
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.Dock = DockStyle.Top;
            btnConfiguracion.FlatAppearance.BorderSize = 0;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.ForeColor = SystemColors.ControlLightLight;
            btnConfiguracion.Location = new Point(0, 676);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Padding = new Padding(10, 0, 0, 0);
            btnConfiguracion.Size = new Size(268, 40);
            btnConfiguracion.TabIndex = 8;
            btnConfiguracion.Text = "Configuarción";
            btnConfiguracion.TextAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.UseVisualStyleBackColor = true;
            btnConfiguracion.Click += btnConfiguracion_Click;
            // 
            // panelReportesSubMenu
            // 
            panelReportesSubMenu.BackColor = Color.Navy;
            panelReportesSubMenu.Controls.Add(btnKardex);
            panelReportesSubMenu.Controls.Add(btnRExistencias);
            panelReportesSubMenu.Controls.Add(btnStocks);
            panelReportesSubMenu.Dock = DockStyle.Top;
            panelReportesSubMenu.Location = new Point(0, 540);
            panelReportesSubMenu.Name = "panelReportesSubMenu";
            panelReportesSubMenu.Size = new Size(268, 136);
            panelReportesSubMenu.TabIndex = 7;
            // 
            // btnKardex
            // 
            btnKardex.Dock = DockStyle.Top;
            btnKardex.FlatAppearance.BorderSize = 0;
            btnKardex.FlatStyle = FlatStyle.Flat;
            btnKardex.ForeColor = SystemColors.ControlLightLight;
            btnKardex.Location = new Point(0, 82);
            btnKardex.Name = "btnKardex";
            btnKardex.Padding = new Padding(35, 0, 0, 0);
            btnKardex.Size = new Size(268, 41);
            btnKardex.TabIndex = 2;
            btnKardex.Text = "Kardex";
            btnKardex.TextAlign = ContentAlignment.MiddleLeft;
            btnKardex.UseVisualStyleBackColor = true;
            btnKardex.Click += btnKardex_Click;
            // 
            // btnRExistencias
            // 
            btnRExistencias.Dock = DockStyle.Top;
            btnRExistencias.FlatAppearance.BorderSize = 0;
            btnRExistencias.FlatStyle = FlatStyle.Flat;
            btnRExistencias.ForeColor = SystemColors.ControlLightLight;
            btnRExistencias.Location = new Point(0, 41);
            btnRExistencias.Name = "btnRExistencias";
            btnRExistencias.Padding = new Padding(35, 0, 0, 0);
            btnRExistencias.Size = new Size(268, 41);
            btnRExistencias.TabIndex = 1;
            btnRExistencias.Text = "Reporte de Exitencias";
            btnRExistencias.TextAlign = ContentAlignment.MiddleLeft;
            btnRExistencias.UseVisualStyleBackColor = true;
            btnRExistencias.Click += btnRExistencias_Click;
            // 
            // btnStocks
            // 
            btnStocks.Dock = DockStyle.Top;
            btnStocks.FlatAppearance.BorderSize = 0;
            btnStocks.FlatStyle = FlatStyle.Flat;
            btnStocks.ForeColor = SystemColors.ControlLightLight;
            btnStocks.Location = new Point(0, 0);
            btnStocks.Name = "btnStocks";
            btnStocks.Padding = new Padding(35, 0, 0, 0);
            btnStocks.Size = new Size(268, 41);
            btnStocks.TabIndex = 0;
            btnStocks.Text = "Stocks";
            btnStocks.TextAlign = ContentAlignment.MiddleLeft;
            btnStocks.UseVisualStyleBackColor = true;
            btnStocks.Click += btnStocks_Click;
            // 
            // btnRICatalogos
            // 
            btnRICatalogos.Dock = DockStyle.Top;
            btnRICatalogos.FlatAppearance.BorderSize = 0;
            btnRICatalogos.FlatStyle = FlatStyle.Flat;
            btnRICatalogos.ForeColor = SystemColors.ControlLightLight;
            btnRICatalogos.Location = new Point(0, 500);
            btnRICatalogos.Name = "btnRICatalogos";
            btnRICatalogos.Padding = new Padding(10, 0, 0, 0);
            btnRICatalogos.Size = new Size(268, 40);
            btnRICatalogos.TabIndex = 6;
            btnRICatalogos.Text = "Reporte de Inventario de Catálogos";
            btnRICatalogos.TextAlign = ContentAlignment.MiddleLeft;
            btnRICatalogos.UseVisualStyleBackColor = true;
            btnRICatalogos.Click += btnRICatalogos_Click;
            // 
            // panelProcesosSubMenu
            // 
            panelProcesosSubMenu.BackColor = Color.Navy;
            panelProcesosSubMenu.Controls.Add(btnSInventario);
            panelProcesosSubMenu.Controls.Add(btnEinventario);
            panelProcesosSubMenu.Dock = DockStyle.Top;
            panelProcesosSubMenu.Location = new Point(0, 404);
            panelProcesosSubMenu.Name = "panelProcesosSubMenu";
            panelProcesosSubMenu.Size = new Size(268, 96);
            panelProcesosSubMenu.TabIndex = 5;
            // 
            // btnSInventario
            // 
            btnSInventario.Dock = DockStyle.Top;
            btnSInventario.FlatAppearance.BorderSize = 0;
            btnSInventario.FlatStyle = FlatStyle.Flat;
            btnSInventario.ForeColor = SystemColors.ControlLightLight;
            btnSInventario.Location = new Point(0, 41);
            btnSInventario.Name = "btnSInventario";
            btnSInventario.Padding = new Padding(35, 0, 0, 0);
            btnSInventario.Size = new Size(268, 41);
            btnSInventario.TabIndex = 1;
            btnSInventario.Text = "Salidas del Inventario";
            btnSInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnSInventario.UseVisualStyleBackColor = true;
            btnSInventario.Click += btnSInventario_Click;
            // 
            // btnEinventario
            // 
            btnEinventario.Dock = DockStyle.Top;
            btnEinventario.FlatAppearance.BorderSize = 0;
            btnEinventario.FlatStyle = FlatStyle.Flat;
            btnEinventario.ForeColor = SystemColors.ControlLightLight;
            btnEinventario.Location = new Point(0, 0);
            btnEinventario.Name = "btnEinventario";
            btnEinventario.Padding = new Padding(35, 0, 0, 0);
            btnEinventario.Size = new Size(268, 41);
            btnEinventario.TabIndex = 0;
            btnEinventario.Text = "Entradas del Inventario";
            btnEinventario.TextAlign = ContentAlignment.MiddleLeft;
            btnEinventario.UseVisualStyleBackColor = true;
            btnEinventario.Click += btnEinventario_Click;
            // 
            // btnProcesos
            // 
            btnProcesos.Dock = DockStyle.Top;
            btnProcesos.FlatAppearance.BorderSize = 0;
            btnProcesos.FlatStyle = FlatStyle.Flat;
            btnProcesos.ForeColor = SystemColors.ControlLightLight;
            btnProcesos.Location = new Point(0, 364);
            btnProcesos.Name = "btnProcesos";
            btnProcesos.Padding = new Padding(10, 0, 0, 0);
            btnProcesos.Size = new Size(268, 40);
            btnProcesos.TabIndex = 4;
            btnProcesos.Text = "Procesos";
            btnProcesos.TextAlign = ContentAlignment.MiddleLeft;
            btnProcesos.UseVisualStyleBackColor = true;
            btnProcesos.Click += btnProcesos_Click;
            // 
            // panelCatalogosSubMenu
            // 
            panelCatalogosSubMenu.BackColor = Color.Navy;
            panelCatalogosSubMenu.Controls.Add(btnMMarca);
            panelCatalogosSubMenu.Controls.Add(btnCProdutos);
            panelCatalogosSubMenu.Controls.Add(btnMProductos);
            panelCatalogosSubMenu.Dock = DockStyle.Top;
            panelCatalogosSubMenu.Location = new Point(0, 228);
            panelCatalogosSubMenu.Name = "panelCatalogosSubMenu";
            panelCatalogosSubMenu.Size = new Size(268, 136);
            panelCatalogosSubMenu.TabIndex = 3;
            // 
            // btnMMarca
            // 
            btnMMarca.Dock = DockStyle.Top;
            btnMMarca.FlatAppearance.BorderSize = 0;
            btnMMarca.FlatStyle = FlatStyle.Flat;
            btnMMarca.ForeColor = SystemColors.ControlLightLight;
            btnMMarca.Location = new Point(0, 82);
            btnMMarca.Name = "btnMMarca";
            btnMMarca.Padding = new Padding(35, 0, 0, 0);
            btnMMarca.Size = new Size(268, 41);
            btnMMarca.TabIndex = 2;
            btnMMarca.Text = "Mantenimiento de Marca";
            btnMMarca.TextAlign = ContentAlignment.MiddleLeft;
            btnMMarca.UseVisualStyleBackColor = true;
            btnMMarca.Click += btnMMarca_Click;
            // 
            // btnCProdutos
            // 
            btnCProdutos.Dock = DockStyle.Top;
            btnCProdutos.FlatAppearance.BorderSize = 0;
            btnCProdutos.FlatStyle = FlatStyle.Flat;
            btnCProdutos.ForeColor = SystemColors.ControlLightLight;
            btnCProdutos.Location = new Point(0, 41);
            btnCProdutos.Name = "btnCProdutos";
            btnCProdutos.Padding = new Padding(35, 0, 0, 0);
            btnCProdutos.Size = new Size(268, 41);
            btnCProdutos.TabIndex = 1;
            btnCProdutos.Text = "Categoría de Productos";
            btnCProdutos.TextAlign = ContentAlignment.MiddleLeft;
            btnCProdutos.UseVisualStyleBackColor = true;
            btnCProdutos.Click += btnCProdutos_Click;
            // 
            // btnMProductos
            // 
            btnMProductos.Dock = DockStyle.Top;
            btnMProductos.FlatAppearance.BorderSize = 0;
            btnMProductos.FlatStyle = FlatStyle.Flat;
            btnMProductos.ForeColor = SystemColors.ControlLightLight;
            btnMProductos.Location = new Point(0, 0);
            btnMProductos.Name = "btnMProductos";
            btnMProductos.Padding = new Padding(35, 0, 0, 0);
            btnMProductos.Size = new Size(268, 41);
            btnMProductos.TabIndex = 0;
            btnMProductos.Text = "Mantenimiento de Productos";
            btnMProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnMProductos.UseVisualStyleBackColor = true;
            btnMProductos.Click += btnMProductos_Click;
            // 
            // btnCatalogos
            // 
            btnCatalogos.Dock = DockStyle.Top;
            btnCatalogos.FlatAppearance.BorderSize = 0;
            btnCatalogos.FlatStyle = FlatStyle.Flat;
            btnCatalogos.ForeColor = SystemColors.ControlLightLight;
            btnCatalogos.Location = new Point(0, 188);
            btnCatalogos.Name = "btnCatalogos";
            btnCatalogos.Padding = new Padding(10, 0, 0, 0);
            btnCatalogos.Size = new Size(268, 40);
            btnCatalogos.TabIndex = 2;
            btnCatalogos.Text = "Catálogos";
            btnCatalogos.TextAlign = ContentAlignment.MiddleLeft;
            btnCatalogos.UseVisualStyleBackColor = true;
            btnCatalogos.Click += btnCatalogos_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 34);
            panel3.Name = "panel3";
            panel3.Size = new Size(268, 154);
            panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(262, 154);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(268, 34);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Navy;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(268, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1080, 34);
            panel2.TabIndex = 1;
            // 
            // panelcontenedorForm
            // 
            panelcontenedorForm.AutoSize = true;
            panelcontenedorForm.Dock = DockStyle.Fill;
            panelcontenedorForm.Location = new Point(268, 34);
            panelcontenedorForm.Name = "panelcontenedorForm";
            panelcontenedorForm.Size = new Size(1080, 832);
            panelcontenedorForm.TabIndex = 2;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1348, 866);
            Controls.Add(panelcontenedorForm);
            Controls.Add(panel2);
            Controls.Add(panelSideMenu);
            MinimumSize = new Size(950, 600);
            Name = "menu";
            Text = "menu";
            panelSideMenu.ResumeLayout(false);
            panelConfigSubMenu.ResumeLayout(false);
            panelReportesSubMenu.ResumeLayout(false);
            panelProcesosSubMenu.ResumeLayout(false);
            panelCatalogosSubMenu.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSideMenu;
        private Panel panel3;
        private Panel panel1;
        private Panel panel2;
        private Panel panelCatalogosSubMenu;
        private Button button2;
        private Button btnCatalogos;
        private Button button4;
        private Button button3;
        private Panel panelConfigSubMenu;
        private Button button14;
        private Button button15;
        private Panel panelReportesSubMenu;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Panel panelProcesosSubMenu;
        private Button button1;
        private Button btnSInventario;
        private Button btnEinventario;
        private Button btnProcesos;
        private PictureBox pictureBox1;
        private Panel panelcontenedorForm;
    }
}