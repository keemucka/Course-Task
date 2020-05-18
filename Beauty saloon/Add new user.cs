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
        public Add_new_user()
        {
            InitializeComponent();
        }

        private void Add_new_user_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Transparent;
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();
            if (comboBox1.SelectedItem.ToString() == "Клиент")
            {
                List<string> info = new List<string>{ textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox9.Text, textBox10.Text};
                addNewUser.AddNewClient(info);
                MessageBox.Show("Добавлен новый клиент");
            }

            if (comboBox1.SelectedItem.ToString() == "Сотрудник")
            {
                List<string> info = new List<string>{ textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text,textBox7.Text, textBox9.Text, textBox10.Text};
                addNewUser.AddNewEmployee(info);
                if (textBox7.Text == "Администратор")
                MessageBox.Show("Добавлен новый Администратор");
                else MessageBox.Show("Добавлен новый Врач. " +
                    "Необходимо в таблице Услуги указать," +
                    " какие виды услуг данный врач оказывает");
            }
            this.Close();
        }
    }
}
