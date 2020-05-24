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
    public partial class personal_account_of_Client : Form
    {
        Form1 form1;
        public client client;      
        public personal_account_of_Client(client client, Form1 form1)
        {
            this.form1 = form1;
            this.client = client;
            InitializeComponent();           
        }
        public personal_account_of_Client(client client)
        {           
            this.client = client;
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dw = new DataView(client);
            dw.ShowInfoToClient(dataGridView1, comboBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Appointment_with_a_doctor appointment_With_A_Doctor = new Appointment_with_a_doctor(client);           
            appointment_With_A_Doctor.Show();
        }

        private void personal_account_of_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }
    }
}
