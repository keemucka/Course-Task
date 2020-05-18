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
    class EditInfo
    {
        public client newclient;
        public employee newemployee;
        public service newservice;
        public procedure_schedule procedure_Schedule;
        public Model1 db = new Model1();

        public EditInfo(client newclient)
        {
            this.newclient = newclient;
        }

        public EditInfo(employee newemployee)
        {
            this.newemployee = newemployee;
        }

        public EditInfo(service newservice, string newemployee)
        {
            this.newservice = newservice;
            this.newemployee = db.employee.SingleOrDefault(w => (w.surname + " " + w.name + " " + w.lastlename)
            == newemployee);
        }

        public EditInfo(procedure_schedule procedure_Schedule)
        {
            this.procedure_Schedule = procedure_Schedule;
        }

        public void EditClient(List<string> info)
        {
            try
            {
                var result = db.client.SingleOrDefault(w => w.id_client == newclient.id_client);
                result.surname = info[0];
                result.name = info[1];
                result.lastlename = info[2];
                result.email = info[5];
                result.number = Convert.ToInt64(info[4]);
                result.dateofborn = Convert.ToDateTime(info[3]);
                result.login = info[6];
                result.password = Convert.ToInt32(info[7]);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
                   
        }

        public void EditEmployee(List<string> info)
        {
            try
            {
                var result = db.employee.SingleOrDefault(w => w.id_employee == newemployee.id_employee);
                result.surname = info[0];
                result.name = info[1];
                result.lastlename = info[2];
                result.dateofborn = Convert.ToDateTime(info[3]);
                result.number = Convert.ToInt64(info[4]);
                result.email = info[5];
                result.post = info[6];
                result.login = info[7];
                result.password = Convert.ToInt32(info[8]);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }           
        }

        public void EditService(List<string> info)
        {
            try
            {
                var result = db.service.SingleOrDefault(w => w.id_service == newservice.id_service);
                result.name = info[0];
                result.cost = Convert.ToInt32(info[1]);
                result.id_employee = newemployee.id_employee;
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
           
        }

        
        public void EditProcedure(ComboBox comboBox1, ComboBox comboBox2, DateTimePicker dateTimePicker, ComboBox comboBox3)
        {
            try
            {
                var result = db.procedure_schedule.SingleOrDefault(w => w.date == procedure_Schedule.date);
                if (dateTimePicker.Value.Month >= 10)
                    result.date = Convert.ToDateTime(dateTimePicker.Value.Day + "." + dateTimePicker.Value.Month
                                + "." + dateTimePicker.Value.Year + " " + comboBox3.SelectedItem.ToString());
                if (dateTimePicker.Value.Month < 10)
                    result.date = Convert.ToDateTime(dateTimePicker.Value.Day + ".0" + dateTimePicker.Value.Month
                               + "." + dateTimePicker.Value.Year + " " + comboBox3.SelectedItem.ToString());
                var service = db.service.SingleOrDefault(w => w.name == comboBox2.SelectedItem.ToString());
                var client = db.client.SingleOrDefault(w => (w.surname + " " + w.name + " " + w.lastlename)
                 == comboBox1.SelectedItem.ToString());
                result.id_client = client.id_client;
                result.id_service = service.id_service;
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
          
        }
    }
}
