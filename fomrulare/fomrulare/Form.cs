using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulare
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initial setup if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the current background color
            Color currentColor = this.BackColor;

            // Calculate 10% darker by ensuring we don't decrease below 0.
            // Using Math.Max to make sure values don't drop below 0.
            Color darkerColor = Color.FromArgb(
                currentColor.A, // Keep the alpha channel the same.
                Math.Max(0, (int)(currentColor.R * 0.9)), // Reduce Red by 10% or keep it at 0 if it's too low.
                Math.Max(0, (int)(currentColor.G * 0.9)), // Reduce Green by 10% or keep it at 0 if it's too low.
                Math.Max(0, (int)(currentColor.B * 0.9))  // Reduce Blue by 10% or keep it at 0 if it's too low.
            );

            // Set the new background color
            this.BackColor = darkerColor;
        }
    }
}
