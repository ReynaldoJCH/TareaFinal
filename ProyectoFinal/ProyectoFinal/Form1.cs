using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Form1 : Form
    {
        private Timer timerMensaje;

        List<Producto> listaProductos = new List<Producto>();

        string rutaImagen = "";

        public Form1()
        {
            InitializeComponent();

            timerMensaje = new Timer();
            timerMensaje.Interval = 3000;
            timerMensaje.Tick += (s, e) =>
            {
                lblMensaje.Visible = false;
                timerMensaje.Stop();
            };
        }

        void MostrarMensaje(string texto, bool esError = false)
        {
            lblMensaje.Text = texto;

            if (esError)
            {
                lblMensaje.ForeColor = Color.White;
                lblMensaje.BackColor = Color.IndianRed;
            }
            else
            {
                lblMensaje.ForeColor = Color.White;
                lblMensaje.BackColor = Color.SeaGreen;
            }


            lblMensaje.Visible = true;
            panelContenedor.Visible = true;
            panelContenedor.BringToFront();

            timerMensaje.Stop();
            timerMensaje.Start();
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImagenProducto.Image = Image.FromFile(openFileDialog1.FileName);
            }
            else
            {
                MostrarMensaje("No se selecciono un archivo", true);
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Producto p = new Producto();

            p.Nombre = txtNombreProducto.Text;
            p.Precio = txtPrecioProducto.Text;
            p.Descripcion = txtDescripcionProducto.Text;
            p.Telefono = txtTelefono.Text;
            p.Productora = txtProductora.Text;
            p.Imagen = rutaImagen;

            listaProductos.Add(p);

            MostrarMensaje("Producto guardado");
            LimpiarCampos();
        }

        private bool ValidarCampos()
        {
            List<TextBox> campos = new List<TextBox>()
            {
                txtNombreProducto, txtPrecioProducto, txtDescripcionProducto, txtTelefono, txtProductora
            };

            foreach (TextBox txt in campos)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    string nombreCampo = txt.Tag != null ? txt.Tag.ToString() : "este campo";
                    MostrarMensaje($"El  campo {nombreCampo} esta vacío", true);
                    txt.Focus();
                    return false;
                }
            }
            //
            return true;
        }

        private void LimpiarCampos()
        {
            List<TextBox> campos = new List<TextBox>()
            {
                txtNombreProducto, txtPrecioProducto, txtDescripcionProducto, txtProductora, txtTelefono
            };

            foreach (TextBox txt in campos)
            {
                txt.Clear();
            }
            if (pictureBoxImagenProducto.Image != null)
            {
                pictureBoxImagenProducto.Image.Dispose();
                pictureBoxImagenProducto.Image = null;
            }

            rutaImagen = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              
        }
    }

    class Producto
    {
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Productora { get; set; }
        public string Imagen { get; set; }
    }
}
