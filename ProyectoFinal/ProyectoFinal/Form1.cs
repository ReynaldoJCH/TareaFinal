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
