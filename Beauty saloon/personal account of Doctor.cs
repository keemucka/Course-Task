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
    public partial class personal_account_of_Doctor : Form
    {
        Form1 form1;
        employee doctor;
        DataView DataView = new DataView();
        public personal_account_of_Doctor(employee doctor,Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            this.doctor = doctor;
            DataView.ShowInfoToDoctor(dataGridView1, doctor, label1);

        }

        private void personal_account_of_Doctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }
    }
}
