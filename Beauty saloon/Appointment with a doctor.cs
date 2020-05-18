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
    public partial class Appointment_with_a_doctor : Form
    {
        client Client;      
        DataView DataView = new DataView();
        public int i = 0;
        public Appointment_with_a_doctor(client client)
        {
            Client = client;
            InitializeComponent();
            DataView.ShowServiceList(comboBox1);
            
            dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(5);
            i++;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> info = DataView.ShowDoctorOfServiceToClient(comboBox1.SelectedItem.ToString());
            label8.Text = info[0];
            label7.Text = info[1];
            label6.Text = info[2];
            comboBox2.Items.Clear();
            dateTimePicker1.Value = DateTime.Now.AddDays(1);
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewUser addNewUser = new AddNewUser();
                addNewUser.AddNewScheduleClient(Client, comboBox1, dateTimePicker1, comboBox2);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (i!=0) DataView.ShowAviaibleTime(comboBox2, dateTimePicker1, comboBox1);
        }
       
    }
}
