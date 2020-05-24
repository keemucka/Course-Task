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
            textBox7.Enabled = false;
            textBox1.Text = client.surname;
            textBox2.Text = client.name;
            textBox3.Text = client.lastlename;
            textBox4.Text = client.dateofborn.ToString();
            textBox5.Text = client.number.ToString();
            textBox6.Text = client.email;
            textBox9.Text = client.login;
            textBox10.Text = client.password.ToString();
        }

        public EditUser(employee employee)
        {
            this.employee = employee;
            i = 2;
            InitializeComponent();           
            textBox1.Text = employee.surname;
            textBox2.Text = employee.name;
            textBox3.Text = employee.lastlename;
            textBox4.Text = employee.dateofborn.ToString();
            textBox5.Text = employee.number.ToString();
            textBox6.Text = employee.email;
            textBox7.Text = employee.post;
            textBox9.Text = employee.login;
            textBox10.Text = employee.password.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                List<string> info = new List<string>{ textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox9.Text, textBox10.Text};
                EditInfo editInfo = new EditInfo(client, this);
                editInfo.EditClient(info);        

            }
            if (i == 2)
            {
                EditInfo editInfo = new EditInfo(employee, this);
                List<string> info = new List<string>{ textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox7.Text, textBox9.Text, textBox10.Text};
                editInfo.EditEmployee(info);
                
            }
        }
    }
}
