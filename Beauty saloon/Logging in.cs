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
    public partial class Form1 : Form
    {
        public Model1 db = new Model1();
        public List<client> clientsheet;
        public List<employee> employeesheet;
        public Form1()
        {
            InitializeComponent();
            clientsheet = (from client in db.client
                           select client).ToList();
            employeesheet = (from employee in db.employee
                             select employee).ToList();
           
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
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
                        personal_account_of_Client FormClient = new personal_account_of_Client(client1, this);
                        //FormClient.Owner = this;
                        FormClient.Show();
                        this.Hide();
                    }
                    //InvalidOperationException - последовательность не содержит элемента
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
                                personal_account_of_Admin FormAdmin = new personal_account_of_Admin(employee1, this);
                               // FormAdmin.Owner = this;
                                FormAdmin.Show();
                                this.Hide();
                            }
                            else
                            {
                                personal_account_of_Doctor FormDoctor = new personal_account_of_Doctor(employee1, this);
                               // FormDoctor.Owner = this;
                                FormDoctor.Show();
                                this.Hide();

                            }

                        }
                        catch (InvalidOperationException) //Если не входит ни как клиент, ни как сотрудник
                        {
                            MessageBox.Show("Неверны логин или пароль");
                        }
                    }
                }
            }
            else Application.OpenForms[0].Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Registration reg = new Registration(this);
                reg.Owner = this;
                reg.Show();
                this.Hide();
            }
            else Application.OpenForms[0].Focus();
           
        }
    }
}
