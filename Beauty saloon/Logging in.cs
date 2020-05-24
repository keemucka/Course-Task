using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beauty_saloon
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();          
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Loggining loggining = new Loggining();
                loggining.Enter(textBox1, textBox2, this);
            }
            else Application.OpenForms[0].Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Registration reg = new Registration(this);
                reg.Owner = this;
                reg.Show();
                this.Hide();
            }
            else Application.OpenForms[0].Focus();
           
        }
    }
}
