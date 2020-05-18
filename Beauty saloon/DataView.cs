using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Beauty_saloon
{
    class DataView
    {
        public client client;
        public employee employee;
        public Model1 db = new Model1();
        public DataView(client client)
        {
            this.client = client;
        }

        public DataView(employee employee)
        {
            this.employee = employee;
        }

        public DataView( )
        {
            
        }

        public void ShowInfoToClient(DataGridView dataGridView, ComboBox comboBox)
        {

            List<employee> employees = (from employee in db.employee
                                        select employee).ToList();
            //Спико врачей-специалистов
            //Список услуг
            //Активные записи           
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        var query = (from g in db.employee
                                     where g.post.ToString() != "Администратор"
                                     orderby g.id_employee
                                     select new { g.surname, g.name, g.lastlename, g.post,g.email }).ToList();
                        dataGridView.DataSource = query;
                        dataGridView.Columns[0].HeaderText = "Фамилия";
                        dataGridView.Columns[1].HeaderText = "Имя";
                        dataGridView.Columns[2].HeaderText = "Отчество";
                        dataGridView.Columns[3].HeaderText = "Должность";
                        dataGridView.Columns[4].HeaderText = "Электронная почта";
                    }
                    break;
                case 1:
                    {
                        var query = (from service in db.service
                                     select new { service.name, service.cost }).ToList();
                        dataGridView.DataSource = query;
                        dataGridView.Columns[0].HeaderText = "Наименование услуги";
                        dataGridView.Columns[1].HeaderText = "Цена";
                    }
                    break;
                case 2:
                    {
                        string s = "";
                        var query = (from procedure in db.procedure_schedule                                      
                                     join client in db.client on procedure.id_client equals client.id_client                                     
                                     join service in db.service on procedure.id_service equals service.id_service
                                     join doctor in db.employee on service.id_employee equals doctor.id_employee
                                     orderby procedure.date
                                     select new
                                     {                                        
                                         service.name,
                                         procedure.date,
                                         s = (doctor.surname + " " + doctor.name + " " + doctor.lastlename),
                                         service.cost
                                     }).ToList();
                        dataGridView.DataSource = query;                       
                        dataGridView.Columns[0].HeaderText = "Название услуги";
                        dataGridView.Columns[1].HeaderText = "Дата";
                        dataGridView.Columns[2].HeaderText = "Врач";
                        dataGridView.Columns[3].HeaderText = "Цена";                       
                    }
                    break;
            }
        }

        public void ShowInfoToDoctor(DataGridView dataGridView, employee employee, Label label)
        {
            try
            {
                label.Visible = false;
                var query = (from procedure in db.procedure_schedule
                             join client in db.client on procedure.id_client equals client.id_client
                             join service in db.service on procedure.id_service equals service.id_service
                             join doctor in db.employee on service.id_employee equals doctor.id_employee
                             where doctor.id_employee == employee.id_employee
                             select new
                             {
                                 service.name,
                                 procedure.date,
                                 s = (client.surname + " " + client.name + " " + client.lastlename),
                                 service.cost
                             }).ToList();
                dataGridView.DataSource = query;               
                dataGridView.Columns[0].HeaderText = "Название услуги";
                dataGridView.Columns[1].HeaderText = "Дата";
                dataGridView.Columns[2].HeaderText = "Клиент";
                dataGridView.Columns[3].HeaderText = "Цена";
            }
            catch
            {
                label.Visible = true;
            }
        }      
       

        public List<string> ShowInfoService()
        {
            List<string> infoEmployee = new List<string>();     
            List<service> services = (from service in db.service select service).ToList();
            string s = "не удалось";
            var query = (from service in services
                         join employee in db.employee on service.id_employee equals employee.id_employee
                         select  s = (employee.surname + " " + employee.name + " " + employee.lastlename) ).Distinct();
            foreach (string r in query) infoEmployee.Add(r);         
            return infoEmployee;
        }

        public void ShowClientList(ComboBox comboBox)
        {
            List<string> infoClient = new List<string>();
            List<client> services = (from client in db.client select client).ToList();
            string s = "не удалось";
            var query = (from client in services                         
                         select s = (client.surname + " " + client.name + " " + client.lastlename)).Distinct();           
            foreach (string r in query) infoClient.Add(r);
            foreach (string w in infoClient) comboBox.Items.Add(w);
           
        }

        public void ShowClientListForEdit(ComboBox comboBox, procedure_schedule procedure_schedule1)
        {
            List<string> infoClient = new List<string>();
            List<service> services = (from service in db.service select service).ToList();
            string s = "не удалось";
            var query = (from service in services
                         join procedure_schedule in db.procedure_schedule on service.id_service equals procedure_schedule.id_service
                         join client in db.client on procedure_schedule.id_client equals client.id_client
                         where procedure_schedule.id_procedure == procedure_schedule1.id_procedure
                         select s = (client.surname + " " + client.name + " " + client.lastlename)).Distinct();
            foreach (string r in query) infoClient.Add(r);
            foreach (string w in infoClient) comboBox.Items.Add(w);            
        }

        public void ShowServiceListForEdit(ComboBox comboBox, procedure_schedule procedure_schedule1)
        {
            List<string> infoClient = new List<string>();
            List<service> services = (from service in db.service select service).ToList();
            string s = "не удалось";
            var query = (from service in services                        
                         select service.name).Distinct();            
            foreach (string r in query) infoClient.Add(r);
            foreach (string w in infoClient) comboBox.Items.Add(w);
            service service1 = db.service.SingleOrDefault(w => w.id_service == procedure_schedule1.id_service);
            comboBox.SelectedItem = service1.name;
        }

        public void ShowAviaibleTime( ComboBox comboBox, DateTimePicker dateTimePicker, ComboBox comboBoxService)
        {            
            if (dateTimePicker.Value.ToString() != "")
            {
                List<string> AviaibleTime = new List<string>();

                List<string> qq = new List<string>();
                for (int i = 9; i <= 18; i++)
                {
                    if ((i < 10)&&(dateTimePicker.Value.Month >9))
                        AviaibleTime.Add(dateTimePicker.Value.Day + "." + dateTimePicker.Value.Month
                            + "." + dateTimePicker.Value.Year + " " + "0" + i + ":" + "00" + ":" + "00");
                    if ((i < 10) && (dateTimePicker.Value.Month < 10))
                        AviaibleTime.Add(dateTimePicker.Value.Day + ".0" + dateTimePicker.Value.Month
                            + "." + dateTimePicker.Value.Year + " " + "0" + i + ":" + "00" + ":" + "00");
                    if ((i>=10)&& (dateTimePicker.Value.Month > 9)) 
                        AviaibleTime.Add(dateTimePicker.Value.Day + "." + dateTimePicker.Value.Month
                            + "." + dateTimePicker.Value.Year + " " + i + ":" + "00" + ":" + "00");
                    if ((i >= 10) && (dateTimePicker.Value.Month < 10))
                        AviaibleTime.Add(dateTimePicker.Value.Day + ".0" + dateTimePicker.Value.Month
                            + "." + dateTimePicker.Value.Year + " " + i + ":" + "00" + ":" + "00");
                }

                List<service> servicelist = (from servic in db.service                                
                                   select servic).ToList();
                service service = servicelist.First(w => w.name == comboBoxService.SelectedItem.ToString());


                var query = (from procedure_schedule in db.procedure_schedule
                             where procedure_schedule.id_service == service.id_service
                             select procedure_schedule.date).Distinct();
                foreach(DateTime d in query.Where(w => w.Value.Day == dateTimePicker.Value.Day))
                {
                    qq.Add(d.ToString());
                }

                var result = AviaibleTime.Except(qq);
                List<DateTime> Time = new List<DateTime>();
                foreach (string s in result) Time.Add(Convert.ToDateTime(s));
                foreach (DateTime s in Time) comboBox.Items.Add(s.TimeOfDay);               
               
            }
            else MessageBox.Show("Укажите дату");
        }

        public void ShowDoctorOfService(Label label1, Label label2, Label label3, string service_name)
        {           
            service service = db.service.SingleOrDefault(w => w.name == service_name);
            employee employee = db.employee.SingleOrDefault(w => w.id_employee == service.id_employee);
            label1.Text = (employee.surname + " " + employee.name + " " + employee.lastlename);
            label2.Text = employee.number.ToString();
            label3.Text = service.cost.ToString();
        }

        public List<string> ShowDoctorOfServiceToClient(string service_name)
        {
            List<string> info = new List<string>();
            service service = db.service.SingleOrDefault(w => w.name == service_name);
            employee employee = db.employee.SingleOrDefault(w => w.id_employee == service.id_employee);        
            info.Add((employee.surname + " " + employee.name + " " + employee.lastlename));
            info.Add(employee.number.ToString());
            info.Add(service.cost.ToString());
            return info;
        }

        public void ShowServiceList(ComboBox comboBox)
        {
            List<string> infoClient = new List<string>();
            List<service> services = (from service in db.service select service).ToList();
            string s = "не удалось";
            var query = (from service in services
                         select service.name).Distinct();
            foreach (string r in query) infoClient.Add(r);
            foreach (string w in infoClient) comboBox.Items.Add(w);
        }       

       

        public void ShowInfoToAdmin(DataGridView dataGridView, ComboBox comboBox)
        {
            //Клиенты
            //Врачи
            //Администраторы
            //Список услуг
            //Записи
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        var query = (from g in db.client
                                     orderby g.id_client
                                     select new
                                     {
                                         g.id_client,
                                         g.surname,
                                         g.name,
                                         g.lastlename,
                                         g.dateofborn,
                                         g.email,
                                         g.number,
                                         g.login,
                                         g.password
                                     }).ToList();
                        dataGridView.DataSource = query;
                        dataGridView.Columns[0].HeaderText = "Id";
                        dataGridView.Columns[1].HeaderText = "Фамилия";
                        dataGridView.Columns[2].HeaderText = "Имя";
                        dataGridView.Columns[3].HeaderText = "Отчество";
                        dataGridView.Columns[4].HeaderText = "Дата рождения";
                        dataGridView.Columns[5].HeaderText = "Электронная почта";
                        dataGridView.Columns[6].HeaderText = "Номер телефона";
                        dataGridView.Columns[7].HeaderText = "Логин";
                        dataGridView.Columns[8].HeaderText = "Пароль";
                    }
                    break;
                case 1:
                    {
                        var query = (from g in db.employee
                                     where g.post.ToString() != "Администратор"
                                     orderby g.id_employee
                                     select new
                                     {
                                         g.id_employee,
                                         g.surname,
                                         g.name,
                                         g.lastlename,
                                         g.post,
                                         g.dateofborn,
                                         g.email,
                                         g.number,
                                         g.login,
                                         g.password
                                     }).ToList();
                        dataGridView.DataSource = query;
                        dataGridView.Columns[0].HeaderText = "Id";
                        dataGridView.Columns[1].HeaderText = "Фамилия";
                        dataGridView.Columns[2].HeaderText = "Имя";
                        dataGridView.Columns[3].HeaderText = "Отчество";
                        dataGridView.Columns[4].HeaderText = "Должность";
                        dataGridView.Columns[5].HeaderText = "Дата рождения";
                        dataGridView.Columns[6].HeaderText = "Электронная почта";
                        dataGridView.Columns[7].HeaderText = "Номер телефона";
                        dataGridView.Columns[8].HeaderText = "Логин";
                        dataGridView.Columns[9].HeaderText = "Пароль";
                    }
                    break;
                case 2:
                    {
                        var query = (from g in db.employee
                                     where g.post.ToString() == "Администратор"
                                     orderby g.id_employee
                                     select new
                                     {
                                         g.id_employee,
                                         g.surname,
                                         g.name,
                                         g.lastlename,
                                         g.post,
                                         g.dateofborn,
                                         g.email,
                                         g.number,
                                         g.login,
                                         g.password
                                     }).ToList();
                        dataGridView.DataSource = query;
                        dataGridView.Columns[0].HeaderText = "Id";
                        dataGridView.Columns[1].HeaderText = "Фамилия";
                        dataGridView.Columns[2].HeaderText = "Имя";
                        dataGridView.Columns[3].HeaderText = "Отчество";
                        dataGridView.Columns[4].HeaderText = "Должность";
                        dataGridView.Columns[5].HeaderText = "Дата рождения";
                        dataGridView.Columns[6].HeaderText = "Электронная почта";
                        dataGridView.Columns[7].HeaderText = "Номер телефона";
                        dataGridView.Columns[8].HeaderText = "Логин";
                        dataGridView.Columns[9].HeaderText = "Пароль";
                    }
                    break;
                case 4:
                    {
                        string s = "", r = "",m = "";
                        var query = (from procedure in db.procedure_schedule                                     
                                     join client in db.client on procedure.id_client equals client.id_client                                     
                                     join service in db.service on procedure.id_service equals service.id_service
                                     join doctor in db.employee on service.id_employee equals doctor.id_employee
                                     orderby procedure.date
                                     select new
                                     {
                                         procedure.date,
                                         service.name,
                                         r = (client.surname + " " + client.name + " " + client.lastlename),
                                         m = (doctor.surname + " " + doctor.name + " " + doctor.lastlename),
                                         service.cost
                                     }).ToList();
                        dataGridView.DataSource = query;
                        dataGridView.Columns[0].HeaderText = "Дата";
                        dataGridView.Columns[1].HeaderText = "Название услуги";
                        dataGridView.Columns[2].HeaderText = "Клиент";
                        dataGridView.Columns[3].HeaderText = "Врач";
                        dataGridView.Columns[4].HeaderText = "Цена";                      

                    }
                    break;
                case 3:
                    {
                        string s = "";
                        var query = (from g in db.service
                                     join doctor in db.employee on g.id_employee equals doctor.id_employee
                                     orderby g.id_service
                                     select new
                                     {
                                         g.name,
                                         g.cost,                                       
                                         s = (doctor.surname + " " + doctor.name + " " + doctor.lastlename)                                   
                                     }).ToList();
                        dataGridView.DataSource = query;
                        dataGridView.Columns[0].HeaderText = "Название";
                        dataGridView.Columns[1].HeaderText = "Цена";
                        dataGridView.Columns[2].HeaderText = "Врач";
                    }
                    break;              
            }
        }
    }
}
