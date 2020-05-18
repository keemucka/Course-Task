using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Beauty_saloon
{
    class AddNewUser
    {
        public client newclient;
        public employee newemployee;
        public service newservice;
        public Model1 db = new Model1();  
        public procedure_schedule newpr = new procedure_schedule();
        public AddNewUser(string newemployee)
        {
            this.newemployee = db.employee.SingleOrDefault(w => (w.surname + " " + w.name + " " + w.lastlename)
           == newemployee);
        }

        public AddNewUser()
        {

        }
      
        public void AddNewClient(List<string> info)
        {  
            try
            {
                int number_of_client = db.client.Max(n => n.id_client) + 1;

                newclient = new client
                {
                    id_client = number_of_client,
                    surname = info[0],
                    name = info[1],
                    lastlename = info[2],
                    email = info[3],
                    number = Convert.ToInt64(info[4]),
                    dateofborn = Convert.ToDateTime(info[5]),
                    login = info[6],
                    password = Convert.ToInt32(info[7]),
                };
                db.client.Add(newclient);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
        }

        public void AddNewEmployee(List<string> info)
        {
            try
            {
                int number_of_employee = db.employee.Max(n => n.id_employee) + 1;
                newemployee = new employee
                {
                    id_employee = number_of_employee,
                    surname = info[0],
                    name = info[1],
                    lastlename = info[2],
                    dateofborn = Convert.ToDateTime(info[3]),
                    number = Convert.ToInt64(info[4]),
                    email = info[5],
                    post = info[6],
                    login = info[7],
                    password = Convert.ToInt32(info[8]),
                };
                db.employee.Add(newemployee);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
                     
        }

        public void AddNewService(List<string> info)
        {
           
            try
            {
                int number_of_service = db.service.Max(n => n.id_service) + 1;
                newservice = new service
                {
                    id_service = number_of_service,
                    name = info[0],
                    cost = Convert.ToInt32(info[1]),
                    id_employee = newemployee.id_employee
                };
                db.service.Add(newservice);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
        }

        public void AddNewSchedule(ComboBox comboBox1, ComboBox comboBox2, DateTimePicker dateTimePicker, ComboBox comboBox3)
        {
           
            try
            {
                int number_of_schedule = db.procedure_schedule.Max(n => n.id_procedure) + 1;
                service service = db.service.SingleOrDefault(w => w.name == comboBox2.SelectedItem.ToString());
                client client = db.client.SingleOrDefault(w => (w.surname + " " + w.name + " " + w.lastlename)
                == comboBox1.SelectedItem.ToString());
                newpr.id_procedure = number_of_schedule;
                newpr.id_client = client.id_client;
                newpr.id_service = service.id_service;
                if (dateTimePicker.Value.Month >= 10)
                    newpr.date = Convert.ToDateTime(dateTimePicker.Value.Day + "." + dateTimePicker.Value.Month
                                + "." + dateTimePicker.Value.Year + " " + comboBox3.SelectedItem.ToString());
                if (dateTimePicker.Value.Month < 10)
                    newpr.date = Convert.ToDateTime(dateTimePicker.Value.Day + ".0" + dateTimePicker.Value.Month
                               + "." + dateTimePicker.Value.Year + " " + comboBox3.SelectedItem.ToString());
                db.procedure_schedule.Add(newpr);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");

            }
        }

        public void AddNewScheduleClient(client client, ComboBox comboBox2, DateTimePicker dateTimePicker, ComboBox comboBox3)
        {
           
            try
            {
                int number_of_schedule = db.procedure_schedule.Max(n => n.id_procedure) + 1;
                service service = db.service.SingleOrDefault(w => w.name == comboBox2.SelectedItem.ToString());
                newpr.id_procedure = number_of_schedule;
                newpr.id_client = client.id_client;
                newpr.id_service = service.id_service;
                if (dateTimePicker.Value.Month >= 10)
                    newpr.date = Convert.ToDateTime(dateTimePicker.Value.Day + "." + dateTimePicker.Value.Month
                                + "." + dateTimePicker.Value.Year + " " + comboBox3.SelectedItem.ToString());
                if (dateTimePicker.Value.Month < 10)
                    newpr.date = Convert.ToDateTime(dateTimePicker.Value.Day + ".0" + dateTimePicker.Value.Month
                               + "." + dateTimePicker.Value.Year + " " + comboBox3.SelectedItem.ToString());
                db.procedure_schedule.Add(newpr);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");

            }
        }
    }
}
