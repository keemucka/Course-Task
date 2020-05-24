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
    class RemoveInfo
    {
        public Model1 db = new Model1();
        public RemoveInfo()
        {

        }

        public void removeClient(client client1)
        {
            try
            {
                client client7;
                using (var cn = new Model1())
                {
                    client7 = cn.client.Where(w => w.id_client == client1.id_client).FirstOrDefault();
                    var query = (from g in cn.procedure_schedule
                                 where g.id_client == client7.id_client
                                 select g);
                    foreach(procedure_schedule h in query)
                        cn.procedure_schedule.Remove(h);
                    cn.SaveChanges();
                    cn.client.Remove(client7);
                    cn.SaveChanges();
                }
            }            
            catch
            {
                MessageBox.Show("Удалите записи, на которые записался клиент");
            }
            
        }
        public void removeemployee(int id_employee)
        {           
            try
            {
                employee employee7;
                using (var cn = new Model1())
                {
                    employee7 = cn.employee.Where(w => w.id_employee == id_employee).FirstOrDefault();
                    var query = (from g in cn.service
                                 where g.id_employee == employee7.id_employee
                                 select g).ToList();
                    if (query.Count == 0)
                    {
                        cn.employee.Remove(employee7);
                        cn.SaveChanges();
                        MessageBox.Show("Сотрудник удален");
                    }
                    else
                        MessageBox.Show("Нельзя удалить сотрудника, который оказывает какие-либо услуги" +
               " Либо удалите услуги(у), которые он оказывает" +
                        " Либо поменяйте сотрудников в этих услугах");
                }
            }
            catch
            {
                MessageBox.Show("Невозможно произвести удаление");
                //employee employee7;
                //employee7 = db.employee.Where(w => w.id_employee == id_employee).FirstOrDefault();
                //db.employee.Remove(employee7);
                //db.SaveChanges();
                //MessageBox.Show("Сотрудник удален");
            }


        }
        public void removeService(service service)
        {
            try
            {
                service service7;
                using (var cn = new Model1())
                {
                    service7 = cn.service.Where(w => w.id_service == service.id_service).FirstOrDefault();
                    var query = (from g in cn.procedure_schedule
                                 where g.id_service == service7.id_service
                                 select g);
                    foreach (procedure_schedule h in query)
                        cn.procedure_schedule.Remove(h);
                    cn.SaveChanges();
                    cn.service.Remove(service7);
                    cn.SaveChanges();
                    MessageBox.Show("Услуга удалена. Все записи, связанные с этой услугуй, также удалены");
                }
            }
            catch
            {
                MessageBox.Show("Невозможно произвести удаление");
            }          


        }
        public void removeProcedure(procedure_schedule procedure_schedule)
        {
            try
            {
                procedure_schedule procedure_schedule1;
                using (var cn = new Model1())
                {
                    procedure_schedule1 = cn.procedure_schedule.Where(w => w.id_procedure == procedure_schedule.id_procedure).FirstOrDefault();
                    cn.procedure_schedule.Remove(procedure_schedule1);
                    cn.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно произвести удаление");
            }
               
        }
    }
}
