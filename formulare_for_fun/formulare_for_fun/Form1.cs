using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulare_for_fun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using System.Drawing;
            using System.Windows.Forms;

            // Assuming this code is within a Form class

            // Get the current background color of the form
            Color currentColor = this.BackColor;

            // Darken the color
            Color darkerColor = ControlPaint.Dark(currentColor, 0.1); // Darken by 10%

            // Set the new, darker background color
            this.BackColor = darkerColor;

        }
    }
}
