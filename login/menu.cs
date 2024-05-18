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
    public partial class menu : Form
    {
        private Button btnMProductos;
        private Button btnCProdutos;
        private Button btnMMarca;
        private Button btnKardex;
        private Button btnRExistencias;
        private Button btnStocks;
        private Button btnRICatalogos;
        private Button btnConfiguracion;

        public menu()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            panelCatalogosSubMenu.Visible = false;
            panelProcesosSubMenu.Visible = false;
            panelReportesSubMenu.Visible = false;
            panelConfigSubMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelCatalogosSubMenu.Visible == true)
                panelCatalogosSubMenu.Visible = false;
            if (panelProcesosSubMenu.Visible == true)
                panelProcesosSubMenu.Visible = false;
            if (panelReportesSubMenu.Visible == true)
                panelReportesSubMenu.Visible = false;
            if (panelConfigSubMenu.Visible == true)
                panelConfigSubMenu.Visible = false;
        }
        //metodo de tipo vacio para mostrar el submenu
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        //boton principal CATALOGOS
        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCatalogosSubMenu);
        }

        private void btnMProductos_Click(object sender, EventArgs e)
        {
            opencontenedorForm(new Mantenimiento_de_Productos());
            //se coloca el codigo del enlace a lo que corresponde
            hideSubMenu();
        }

        private void btnCProdutos_Click(object sender, EventArgs e)
        {
            opencontenedorForm(new CategoriaProductos());
            hideSubMenu();
        }

        private void btnMMarca_Click(object sender, EventArgs e)
        {
            opencontenedorForm(new MantenimientoMarca());
            hideSubMenu();
        }
        //boton principal PROCESOS
        private void btnProcesos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProcesosSubMenu);
        }

        private void btnEinventario_Click(object sender, EventArgs e)
        {
            opencontenedorForm(new EntradaInventario());
            hideSubMenu();
        }

        private void btnSInventario_Click(object sender, EventArgs e)
        {
            opencontenedorForm(new SalidaInvenario());
            hideSubMenu();
        }
        //boton principal REPORTES DE INVENTARIO
        private void btnRICatalogos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReportesSubMenu);
        }

        private void btnRUsuarios_Click(object sender, EventArgs e)
        {
            opencontenedorForm(new ReporteUsuarios());
            //se coloca el codigo del enlace a lo que corresponde
            hideSubMenu();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            //se coloca el codigo del enlace a lo que corresponde
            opencontenedorForm(new Form2());
            hideSubMenu();
        }


        private void btnRExistencias_Click(object sender, EventArgs e)
        {
            //se coloca el codigo del enlace a lo que corresponde
            opencontenedorForm(new CatalogoCategorias());
            hideSubMenu();
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            //se coloca el codigo del enlace a lo que corresponde
            opencontenedorForm(new Kardex());
            hideSubMenu();
        }
        //boton principal CONFIGURACION
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            showSubMenu(panelConfigSubMenu);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //se coloca el codigo del enlace a lo que corresponde
            opencontenedorForm(new ConfiguracionUsuarios());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //se coloca el codigo del enlace a lo que corresponde
            opencontenedorForm(new ReporteUsuarios());
            hideSubMenu();
        }

        //PANEL CONTENEDOR-- NOS SIRVE PARA QUE MUESTRE TODO EN UNA SOLA VENTANA
        private Form activeForm = null;
        private void opencontenedorForm(Form contenedorForm)
        { //se utliza el if para abri y cerrar el formulario manteniendo activo
            if (activeForm != null)
                activeForm.Close();
            activeForm = contenedorForm;
            contenedorForm.TopLevel = false;
            contenedorForm.FormBorderStyle = FormBorderStyle.None;  //para quitar el borde del formulario
            contenedorForm.Dock = DockStyle.Fill;                   //para rellenar el panel contenedor
            panelcontenedorForm.Controls.Add(contenedorForm);       //para agregar a la lista el panel contenedor
            panelcontenedorForm.Tag = contenedorForm;               //para asociar el panel contenedor
            contenedorForm.BringToFront();                          //para jalar el formulario enfrente
            contenedorForm.Show();                                   //mostrar el formulario

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //se coloca el codigo del enlace a lo que corresponde
            opencontenedorForm(new ReporteUsuarios());
            hideSubMenu();
        }
    }
}
