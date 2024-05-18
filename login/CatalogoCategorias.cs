using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using login.Datos;
using System.Net.NetworkInformation;
using System.Data;
using login.Entidades;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace login
{
    public partial class CatalogoCategorias : Form
    {
        public CatalogoCategorias()
        {
            InitializeComponent();
            ConfigurarColumnasDataGridView();
            txtTotal.Enabled = false;

        }
        private void ConfigurarColumnasDataGridView()
        {
            //Limpia el dataGridView antes de agregar columnas.
            dataGridView1.Columns.Clear();

            // Agrega encabezados de las columnas.
            dataGridView1.Columns.Add("Columna1", "CODIGO CATEGORIA");
            dataGridView1.Columns.Add("Columna2", "NOMBRE");
            dataGridView1.Columns.Add("Columna3", "DESCRIPCION");


            // Configura las columnas para que se ajusten y ocupen el espacio disponible.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }



        private void buttBuscar_Click(object sender, EventArgs e)
        {
            string queryConsulta = "SELECT p.COD_CATEGORIA, p.NOMBRE, p.DESCRIPCION FROM CATEGORIA_PRODUCTOS p";
            // string queryConsulta = @"SELECT p.COD_PRODUCTO, p.NOMBRE, p.PRESENTACION, m. AS MARCA, cp.NOMBRE AS CATEGORIA, p.PRECIO FROM PRODUCTOS p JOIN MARCA m ON p.COD_MARCA = m.COD_MARCA JOIN CATEGORIA_PRODUCTOS cp ON p.COD_CATEGORIA = cp.COD_CATEGORIA";
            if (ConexionBD.Conex.State != ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }
            try
            {
                using (OracleCommand commandDetalle = new OracleCommand(queryConsulta, ConexionBD.Conex))
                {
                    // commandDetalle.Parameters.Add(new OracleParameter("COD_PRODUCTO", noCodigo));
                    using (OracleDataReader readerDetalle = commandDetalle.ExecuteReader())
                    {
                        // Limpiar las filas existentes del DataGridView
                        dataGridView1.Rows.Clear();

                        // Iterar sobre los resultados y agregarlos al DataGridView
                        while (readerDetalle.Read())
                        {
                            object[] rowData = new object[3]; // 5 columnas
                            rowData[0] = readerDetalle["COD_CATEGORIA"];
                            rowData[1] = readerDetalle["NOMBRE"];
                            rowData[2] = readerDetalle["DESCRIPCION"];

                            dataGridView1.Rows.Add(rowData);

                            int cantidadFilas = dataGridView1.RowCount - 1;
                            txtTotal.Text = cantidadFilas.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttImprimir_Click(object sender, EventArgs e)
        {

        }

        private void buttImprimir_Click_1(object sender, EventArgs e)
        {
            // Crear un cuadro de diálogo para guardar el archivo PDF
            SaveFileDialog guardarDialogo = new SaveFileDialog();
            guardarDialogo.Filter = "Archivos PDF (*.pdf)|*.pdf";
            guardarDialogo.Title = "Guardar PDF";

            if (guardarDialogo.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = guardarDialogo.FileName;


                // Crear documento PDF
                Document documento = new Document(PageSize.A4);

                try
                {
                    // Crear un escritor de PDF
                    PdfWriter.GetInstance(documento, new FileStream(nombreArchivo, FileMode.Create));

                    // Abrir el documento
                    documento.Open();

                    // Agregar la palabra "Inventario" con estilo
                    iTextSharp.text.Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.BLACK);
                    Paragraph titulo = new Paragraph("CATALOGO DE CATEGORIAS", tituloFont);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    documento.Add(titulo);


                    // Crear contenido adicional para agregar al PDF
                    string contenidoAdicional = $"Código del producto: {txtTotal.Text}\n";



                    documento.Add(new Paragraph(contenidoAdicional));


                    // Agregar contenido del DataGridView al PDF
                    PdfPTable tabla = new PdfPTable(dataGridView1.Columns.Count);
                    tabla.WidthPercentage = 100;

                    // Agregar encabezados de columna
                    foreach (DataGridViewColumn columna in dataGridView1.Columns)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText));
                        tabla.AddCell(celda);
                    }

                    // Agregar filas y celdas
                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            if (celda.Value != null)
                            {
                                tabla.AddCell(celda.Value.ToString());
                            }
                        }
                    }

                    documento.Add(tabla);

                    // Cerrar el documento
                    documento.Close();

                    MessageBox.Show("PDF generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CatalogoCategorias_Load(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
