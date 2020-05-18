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
    public partial class EditService : Form
    {
        service service;
        public Model1 db = new Model1();
        public EditService(service service)
        {
            InitializeComponent();
            this.service = service;
            button1.Text = "Изменить";
            DataView dataView = new DataView();
            List<string> infoEmployee = dataView.ShowInfoService();           
            textBox1.Text = service.name;
            textBox2.Text = service.cost.ToString();
            foreach (string s in infoEmployee) comboBox1.Items.Add(s);         
           
        }

        public EditService()
        {
            this.service = new service();
            InitializeComponent();
            button1.Text = "Добавить";
            DataView dataView = new DataView();
            List<string> infoEmployee = dataView.ShowInfoService();
            foreach (string s in infoEmployee) comboBox1.Items.Add(s);          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Изменить")
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox1.SelectedItem.ToString() != ""))
                {
                    EditInfo editInfo = new EditInfo(service, comboBox1.SelectedItem.ToString());
                    editInfo.EditService(new List<string> { textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString() });
                    this.Close();
                }
                else MessageBox.Show("Введите данные и укажите врача");

            }
            if (button1.Text == "Добавить")
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox1.SelectedItem.ToString() != ""))
                {
                    AddNewUser addNewUser = new AddNewUser(comboBox1.SelectedItem.ToString());
                    addNewUser.AddNewService(new List<string> { textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString() });
                    this.Close();
                }
                else MessageBox.Show("Введите данные и укажите врача");
            }
        }
    }
}
