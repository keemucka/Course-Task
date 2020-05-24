using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beauty_saloon
{
    class Loggining
    {
        public Model1 db = new Model1();
        public List<client> clientsheet;
        public List<employee> employeesheet;
        public Loggining()
        {
            clientsheet = (from client in db.client
                           select client).ToList();
            employeesheet = (from employee in db.employee
                             select employee).ToList();
        }

        public void Enter(TextBox textBox1, TextBox textBox2, Form1 form1)
        {
            List<client> query = (from client in db.client
                                  select client).ToList();
            if ((textBox1.Text == "") || (textBox2.Text == "")) MessageBox.Show("Введите данные");
            else
            {
                try
                {
                    client client1 = query.First(p =>
                    (p.login.ToString() == textBox1.Text.ToString()) && (p.password.ToString() == textBox2.Text.ToString()));
                    personal_account_of_Client FormClient = new personal_account_of_Client(client1, form1);
                    FormClient.Show();
                    form1.Hide();
                }               
                catch (InvalidOperationException) //Если не входит как клиент
                {
                    try
                    {
                        List<employee> employees = (from employee in db.employee
                                                    select employee).ToList();
                        employee employee1 = employees.First(p => (p.login.ToString() == textBox1.Text.ToString())
                        && (p.password.ToString() == textBox2.Text.ToString()));
                        if (employee1.post == "Администратор")
                        {
                            personal_account_of_Admin FormAdmin = new personal_account_of_Admin(employee1, form1);
                            FormAdmin.Show();
                            form1.Hide();
                        }
                        else
                        {
                            personal_account_of_Doctor FormDoctor = new personal_account_of_Doctor(employee1, form1);
                            FormDoctor.Show();
                            form1.Hide();
                        }
                    }
                    catch (InvalidOperationException) //Если не входит ни как клиент, ни как сотрудник
                    {
                        MessageBox.Show("Неверны логин или пароль");
                    }
                }
            }
        }
    }    
}
