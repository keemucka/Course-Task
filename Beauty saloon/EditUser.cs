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
    public partial class EditUser : Form
    {
        client client;
        employee employee;
        byte i;
        public EditUser(client client)
        {
            this.client = client;
            i = 1;
            InitializeComponent();
        }

        public EditUser(employee employee)
        {
            this.employee = employee;
            i = 2;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                List<string> info = new List<string>{ textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox9.Text, textBox10.Text};
                EditInfo editInfo = new EditInfo(client);
                editInfo.EditClient(info);
                this.Close();

            }
            if (i == 2)
            {
                EditInfo editInfo = new EditInfo(employee);
                List<string> info = new List<string>{ textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox7.Text, textBox9.Text, textBox10.Text};
                editInfo.EditEmployee(info);
                this.Close();
            }
        }
    }
}
