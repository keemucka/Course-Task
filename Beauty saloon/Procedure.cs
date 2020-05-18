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
    public partial class Procedure : Form
    {
        public int i = 0;
        public procedure_schedule procedure_schedule;
        DataView dataView = new DataView();
        public Procedure()
        {
            InitializeComponent();
            button1.Text = "Добавить";
            dataView.ShowClientList(comboBox1);
            dataView.ShowServiceList(comboBox2);
            dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(5);
            i++;
        }

        public Procedure(procedure_schedule procedure_schedule)
        {
            InitializeComponent();
            button1.Text = "Изменить";
            this.procedure_schedule = procedure_schedule;
            dataView.ShowClientListForEdit(comboBox1, procedure_schedule);
            dataView.ShowServiceListForEdit(comboBox2, procedure_schedule);
            dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(5);
            i++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Изменить")
            {
                EditInfo editInfo = new EditInfo(procedure_schedule);
                editInfo.EditProcedure(comboBox1, comboBox2,
                dateTimePicker1, comboBox3);
            }
            if (button1.Text == "Добавить")
            {               
                AddNewUser addNewUser = new AddNewUser();
                addNewUser.AddNewSchedule(comboBox1, comboBox2,
                dateTimePicker1, comboBox3);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataView.ShowDoctorOfService(label10, label7,label6, comboBox2.SelectedItem.ToString());
            comboBox3.Items.Clear();
            dateTimePicker1.Value = DateTime.Now.AddDays(1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
           if (i!=0) dataView.ShowAviaibleTime(comboBox3, dateTimePicker1, comboBox2);
        }
    }
}
