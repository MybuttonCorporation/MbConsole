using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codebutton;
namespace Codebutton
{
    public partial class Form2 : Form
    {
        public Form2(string Message, Color ScreenColor)
        {
            InitializeComponent();
            this.label1.Text = Message;
            this.BackColor = ScreenColor;
            this.Text = Message;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Attempted to fix an error to continue with the app.");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
