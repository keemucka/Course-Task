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
        public RemoveInfo(DataGridView dataGridView)
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
                                 select g);
                    foreach(procedure_schedule h in query)
                        if (h.id_client == client7.id_client) cn.procedure_schedule.Remove(h);

                    cn.client.Remove(client7);
                    cn.SaveChanges();
                }
            }            
            catch
            {
                MessageBox.Show("Удалите записи, на которые записался клиент");
            }
            
        }
        public void removeemployee(employee employee)
        {
            try
            {               
                using (var cn = new Model1())
                {
                    employee = cn.employee.Where(w => w.id_employee == employee.id_employee).FirstOrDefault();
                    cn.employee.Remove(employee);
                    cn.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно произвести удаление");
            }          


        }
        public void removeService(service service)
        {
            try
            {
                using (var cn = new Model1())
                {
                    service = cn.service.Where(w => w.id_service == service.id_service).FirstOrDefault();
                    cn.service.Remove(service);
                    cn.SaveChanges();
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
                    cn.procedure_schedule.Remove(procedure_schedule);
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
