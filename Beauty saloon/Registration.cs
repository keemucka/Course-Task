using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Beauty_saloon
{
    public partial class Registration : Form
    {
        Form1 form1;
        public Registration(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }            
       
        

        private void button1_Click(object sender, EventArgs e)
        {
           
             AddNewUser addNewUser = new AddNewUser(this, form1);
             List<string> info = new List<string>  { textBox1.Text, textBox2.Text, textBox3.Text,
                   textBox4.Text, textBox5.Text, textBox6.Text,  textBox7.Text, textBox8.Text };
             addNewUser.AddNewClientFromReg(info);             
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
