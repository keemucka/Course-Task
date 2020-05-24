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
    public partial class personal_account_of_Admin : Form
    {
        Form1 form1;
        employee admin;
        public Model1 db = new Model1();
        DataView dw;

        public personal_account_of_Admin(employee admin, Form1  form1)
        {
            this.form1 = form1;
            this.admin = admin;
            InitializeComponent();
            dw = new DataView(admin);
        }

        private void personal_account_of_Admin_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            dw.ShowInfoToAdmin(dataGridView1, comboBox1);           
        }

        private void button2_Click(object sender, EventArgs e)// Изменить
        {
            if (comboBox1.SelectedIndex == 0)
            {
                List<client> query = (from client in db.client
                                      select client).ToList();
                client item = query.First(w => w.id_client.ToString() ==
                   dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                EditUser editUser = new EditUser(item);
                editUser.Owner = this;
                editUser.Show();
            }

            if ((comboBox1.SelectedIndex == 1)||(comboBox1.SelectedIndex == 2))
            {
                List<employee> query = (from employee in db.employee
                                        select employee).ToList();
                employee item = query.First(w => w.id_employee.ToString() ==
                   dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                EditUser editUser = new EditUser(item);
                editUser.Owner = this;
                editUser.Show();
            }

            if (comboBox1.SelectedIndex == 3)
            {
                List<service> query = (from service in db.service
                                       select service).ToList();
                service item = query.First(w => w.name.ToString() ==
                   dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                EditService editUser = new EditService(item);
                editUser.Owner = this;
                editUser.Show();
            }

            if (comboBox1.SelectedIndex == 4)
            {
                List<procedure_schedule> query = (from procedure_schedule in db.procedure_schedule
                                                  select procedure_schedule).ToList();
                procedure_schedule item = query.First(w => w.date.ToString() ==
                   dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                Procedure procedure = new Procedure(item);
                procedure.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)// Add
        {
            /*Клиенты
            Врачи
            Администраторы
            Список услуг
            Записи*/
            string usertype = "";
            switch (comboBox1.SelectedIndex)
            {
                
                case 0:
                    {
                        usertype = "Клиент";
                        Add_new_user add_New_User = new Add_new_user(usertype);
                        add_New_User.Show();
                    }
                    break;
                case 1:
                    {
                        usertype = "Сотрудник";
                        Add_new_user add_New_User = new Add_new_user(usertype);
                        add_New_User.Show();
                    }
                    break;
                case 2:
                    {
                        usertype = "Сотрудник";
                        Add_new_user add_New_User = new Add_new_user(usertype);
                        add_New_User.Show();
                    }                    break;
                case 3:
                    {
                        EditService editService = new EditService();
                        editService.Show();
                    }                    break;
                case 4:
                    {
                        Procedure procedure = new Procedure();
                        procedure.Show();
                    }                    break;
            }           
        }
        private void button3_Click(object sender, EventArgs e)// remove
        {
            RemoveInfo removeInfo = new RemoveInfo();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        List<client> query = (from client in db.client
                                              select client).ToList();
                        client item = query.First(w => w.id_client.ToString() ==
                           dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                        removeInfo.removeClient(item);
                        dw.ShowInfoToAdmin(dataGridView1, comboBox1);
                    }
                    break;
                case 1:
                    {
                        List<employee> query = (from employee in db.employee
                                                select employee).ToList();
                        employee item = query.First(w => w.id_employee.ToString() ==
                           dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                        if (admin == item)
                        {
                            MessageBox.Show("Нельзя удалить самого себя");
                        }
                        else
                        {
                            removeInfo.removeemployee(item.id_employee);
                            dw.ShowInfoToAdmin(dataGridView1, comboBox1);
                        }
                    }
                    break;
                case 2:
                    {
                        
                        List<employee> query = (from employee in db.employee
                                                select employee).ToList();
                        employee item = query.First(w => w.id_employee.ToString() ==
                           dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                        if (admin == item)
                        {
                            MessageBox.Show("Нельзя удалить самого себя");
                        }
                        else
                        {
                            removeInfo.removeemployee(item.id_employee);
                            dw.ShowInfoToAdmin(dataGridView1, comboBox1);
                        }
                       
                    }
                    break;
                case 3:
                    {
                        List<service> query = (from service in db.service
                                               select service).ToList();
                        service item = query.First(w => w.name.ToString() ==
                           dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());                       
                        removeInfo.removeService(item);
                        dw.ShowInfoToAdmin(dataGridView1, comboBox1);
                    }
                    break;
                case 4:
                    {
                        List<procedure_schedule> query = (from procedure_schedule in db.procedure_schedule
                                                          select procedure_schedule).ToList();
                        procedure_schedule item = query.First(w => w.date.ToString() ==
                           dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                        removeInfo.removeProcedure(item);
                        dw.ShowInfoToAdmin(dataGridView1, comboBox1);
                    }
                    break;
            }
            
        }

        private void personal_account_of_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dw.ShowInfoToAdmin(dataGridView1, comboBox1);
        }
    }
}
