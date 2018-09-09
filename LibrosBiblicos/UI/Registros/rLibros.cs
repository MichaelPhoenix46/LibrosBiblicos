using LibrosBiblicos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrosBiblicos.UI.Registros
{
    public partial class RLibros : Form
    {
        public RLibros()
        {
            InitializeComponent();
        }

        private Libros LLenaClase()
        {
            Libros Libro = new Libros();
            Libro.LibroId = Convert.ToInt32(IdnumericUpDown.Value);
            Libro.Descripcion = DescripciontextBox.Text;
            Libro.Siglas = SiglastextBox.Text;
            Libro.TipoId = Convert.ToInt32(TipoIdnumericUpDown.Value);

            return Libro;
        }

        public bool Validar()
        {

            if (string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                errorProvider.SetError(DescripciontextBox, "llenar el campo de descripcion");
                return false;
            }
            if (string.IsNullOrEmpty(SiglastextBox.Text))
            {
                errorProvider.SetError(SiglastextBox, "llenar el campo de siglas");
                return false;
            }

            return true;
        }


        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Libros Libro = BLL.LibrosBLL.Buscar(id);

            if (Libro != null)
            {
                
                DescripciontextBox.Text = Libro.Descripcion;
                SiglastextBox.Text = Libro.Siglas;
                TipoIdnumericUpDown.Value = Libro.TipoId;
            }
            else
            {
                MessageBox.Show("no se encontro", "buscar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
            {
                MessageBox.Show("llenar el campo vacio", "trate de guardar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Libros Libro = LLenaClase();
                bool paso = false;

                if (IdnumericUpDown.Value == 0)
                {
                    paso = BLL.LibrosBLL.Guardar(Libro);
                }
                else
                {
                    paso = BLL.LibrosBLL.Modificar(Libro);
                }

                if (paso)
                {
                    MessageBox.Show("Se ha guardado", "aceptado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            SiglastextBox.Clear();
            TipoIdnumericUpDown.Value = 0;

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            if (BLL.LibrosBLL.Eliminar(id))

            {
                MessageBox.Show("eliminado", "exitosamente",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                IdnumericUpDown.Value = 0;
                DescripciontextBox.Clear();
                SiglastextBox.Clear();
                TipoIdnumericUpDown.Value = 0;
            }
            else
            {
                MessageBox.Show("no fue eliminado", "trate de nuevo",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            errorProvider.Clear();
        }

        private void TipoIdnumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}