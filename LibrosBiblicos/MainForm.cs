using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibrosBiblicos
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibrosBiblicos.UI.Registros.RLibros r = new LibrosBiblicos.UI.Registros.RLibros();
            r.Show();
        }

        private void LibrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
