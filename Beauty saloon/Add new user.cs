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
    public partial class Add_new_user : Form
    {
        public string usertype;
        public Add_new_user(string usertype)
        {           
            InitializeComponent();
            this.usertype = usertype;
            if (usertype == "Клиент")
            {
                comboBox1.SelectedIndex = 0;
                textBox7.Enabled = false;
            }                
            else comboBox1.SelectedIndex = 1;

        }

        private void Add_new_user_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Transparent;
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                AddNewUser addNewUser = new AddNewUser(this);
                if (comboBox1.SelectedItem.ToString() == "Клиент")
                {
                    textBox7.Enabled = false;
                    List<string> info = new List<string>{ textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox9.Text, textBox10.Text};
                    addNewUser.AddNewClient(info);                    
                }
                if (comboBox1.SelectedItem.ToString() == "Сотрудник")
                {
                    List<string> info = new List<string>{ textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text,textBox7.Text, textBox9.Text, textBox10.Text};
                    addNewUser.AddNewEmployee(info);                   
                }                
            }            
        }
    }
}
