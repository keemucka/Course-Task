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
        DataView DataView = new DataView();
        Add_new_user add_New_User;
        EditService editService;
        Registration Registration;
        Procedure procedure;
        Form1 form1;
        public int number_of_schedule;
        public int number_of_service;
        public int number_of_client;
        public int number_of_employee;
        public AddNewUser(string newemployee)
        {
            this.newemployee = db.employee.SingleOrDefault(w => (w.surname + " " + w.name + " " + w.lastlename)
           == newemployee);
        }
        public AddNewUser(string newemployee, EditService editService)
        {
            this.editService = editService;
            this.newemployee = db.employee.SingleOrDefault(w => (w.surname + " " + w.name + " " + w.lastlename)
           == newemployee);
        }

        public AddNewUser()
        {

        }

        public AddNewUser(Add_new_user add_New_User)
        {
            this.add_New_User = add_New_User;
        }

        public AddNewUser(Registration Registration, Form1 form1)
        {
            this.Registration = Registration;
            this.form1 = form1;
        }

        public AddNewUser(Procedure procedure)
        {
            this.procedure = procedure;           
        }

        public void AddNewClientFromReg(List<string> info)
        {

            try
            {
                try
                {
                    number_of_client = db.client.Max(n => n.id_client) + 1;
                }
                catch (InvalidOperationException)
                {
                    number_of_client = 1;
                }
                if (!DataView.CheckLoginPassword(info[6], Convert.ToInt32(info[7])))
                {
                    MessageBox.Show("Пользователь с таким логином или паролем уже существует. Укажите другой");
                }
                else
                {
                    
                    newclient = new client
                    {
                        id_client = number_of_client,
                        surname = info[0],
                        name = info[1],
                        lastlename = info[2],
                        email = info[5],
                        number = Convert.ToInt64(info[4]),
                        dateofborn = Convert.ToDateTime(info[3]),
                        login = info[6],
                        password = Convert.ToInt32(info[7]),
                    };
                    db.client.Add(newclient);
                    db.SaveChanges();
                    MessageBox.Show("Регистрация завершена. Ради приветствовать вас!");                  
                    Registration.Close();                   
                    personal_account_of_Client personal_Account_Of_Client = new personal_account_of_Client(newclient, form1);
                    personal_Account_Of_Client.Show();
                }

            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
        }


        public void AddNewClient(List<string> info)
        {
            try
            {
                number_of_client = db.client.Max(n => n.id_client) + 1;
            }
            catch (InvalidOperationException)
            {
                number_of_client = 1;
            }
            try
            {
                if (!DataView.CheckLoginPassword(info[6], Convert.ToInt32(info[7])))
                {
                    MessageBox.Show("Пользователь с таким логином или паролем уже существует. Укажите другой");
                }

                else
                {                 
                   
                    newclient = new client
                    {
                        id_client = number_of_client,
                        surname = info[0],
                        name = info[1],
                        lastlename = info[2],
                        email = info[5],
                        number = Convert.ToInt64(info[4]),
                        dateofborn = Convert.ToDateTime(info[3]),
                        login = info[6],
                        password = Convert.ToInt32(info[7]),
                    };
                    db.client.Add(newclient);
                    db.SaveChanges();
                    MessageBox.Show("Добавлен новый клиент");
                    add_New_User.Close();                   
                }
               
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
                try
                {
                    number_of_employee = db.employee.Max(n => n.id_employee) + 1;
                }
                catch (InvalidOperationException)
                {
                    number_of_employee = 1;
                }
                if (DataView.CheckLoginPassword(info[7], Convert.ToInt32(info[8]))!=true)
                {
                    MessageBox.Show("Пользователь с таким логином или паролем уже существует. Укажите другой");
                }
                else
                {                    
                   
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
                    if (newemployee.post == "Администратор")
                        MessageBox.Show("Добавлен новый Администратор");
                    else MessageBox.Show("Добавлен новый Врач. " +
                        "Необходимо в таблице Услуги указать," +
                        " какие виды услуг данный врач оказывает");
                    add_New_User.Close();
                }                
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
                try
                {
                    number_of_service = db.service.Max(n => n.id_service) + 1;
                }
                catch (InvalidOperationException)
                {
                    number_of_service = 1;
                }
                if (!DataView.CheckServiceName(info[0]))
                {
                    MessageBox.Show("Услуга с таким наименованием уже существует");
                }
                else
                {                   
                    
                    newservice = new service
                    {
                        id_service = number_of_service,
                        name = info[0],
                        cost = Convert.ToInt32(info[1]),
                        id_employee = newemployee.id_employee
                    };
                    db.service.Add(newservice);
                    db.SaveChanges();
                    MessageBox.Show("Добавлена новая услуга");
                    editService.Close();
                }
               
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
                number_of_schedule = db.procedure_schedule.Max(n => n.id_procedure) + 1;
            }
            catch (InvalidOperationException)
            {
                number_of_schedule = 1;
            }
            try
            {            
              
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
                MessageBox.Show("Создана новая запись");
                procedure.Close();
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
                number_of_schedule = db.procedure_schedule.Max(n => n.id_procedure) + 1;
            }
            catch (InvalidOperationException)
            {
                number_of_schedule = 1;
            }
            try
            {                
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
                MessageBox.Show("Создана новая запись");
                add_New_User.Close();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
        }
    }
}
