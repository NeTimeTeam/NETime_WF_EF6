using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETime_WF_EF6
{
    public partial class transacciones : UserControl
    {
        public transacciones()
        {
            InitializeComponent();
            UpdateAll();
        }

        //DATA GATHERS
        private async Task<List<Actividades>> GetUserSelectedActivities()
        {
            List<Actividades> list = new List<Actividades>();
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    list = await (from s in context.selected_activitiesSet
                                  join a in context.activitiesSet on s.activitiesId equals a.Id
                                  join u in context.userSet on a.userId equals u.Id
                                  join c in context.categoriesSet on a.categoriesId equals c.Id
                                  where s.userId == CurrentUser.Id
                                  select new Actividades { selector = false, Id = s.Id, name = a.name, category = c.name, description = a.description, userId = a.userId, email = u.email, activityId = s.activitiesId }).ToListAsync<Actividades>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Messages.ErrorMessage(label_msg,"Error obteniendo la lista de actividades.");                    
                }
            }
            return list;
        }
        private async Task<List<Balance>> GetUserTransactions()
        {
            List<Balance> list = new List<Balance>();
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    list = await (from b in context.balanceSet                                  
                                  join u in context.userSet on b.userId equals u.Id
                                  where b.userId == CurrentUser.Id
                                  select new Balance { datetime = b.datetime, activity = b.activityName, qtty = b.qtty }).ToListAsync<Balance>();
                }catch(Exception e)
                {
                    Console.WriteLine($"Balance List: {e.Message}");
                    Messages.ErrorMessage(label_msg, "Error obteniendo la lista de tranasacciones.");
                }
            }
            return list;
        }
        private async Task<int> GetUserPayedHours()
        {
            int qtty = 0;
            using(netimeContainer context = new netimeContainer())
            {
                try
                {
                    qtty = await (from b in context.balanceSet where b.userId == CurrentUser.Id & b.qtty < 0 select b.qtty).DefaultIfEmpty(0).SumAsync();                    
                }
                catch (Exception err)
                {
                    Console.WriteLine($"PayedHours Fn: {err.Message}");
                    Messages.ErrorMessage(label_msg, "Error calculando la suma de horas pagadas.");
                }
            }
            return qtty;
        }
        private async Task<int> GetUserChargedHours()
        {
            int qtty = 0;
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    qtty = await (from b in context.balanceSet where b.userId == CurrentUser.Id & b.qtty > 0 select b.qtty).DefaultIfEmpty(0).SumAsync();
                }
                catch (Exception err)
                {
                    Console.WriteLine($"ChargedHours Fn: {err.Message}");
                    Messages.ErrorMessage(label_msg, "Error calculando la suma de horas cobradas.");
                }
            }
            return qtty;
        }
        private async Task<int> GetUserTotalHours()
        {
            int qtty = 0;
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    qtty = await (from b in context.balanceSet where b.userId == CurrentUser.Id select b.qtty).DefaultIfEmpty(0).SumAsync();
                }
                catch (Exception err)
                {
                    Console.WriteLine($"SumTotHours Fn: {err.Message}");
                    Messages.ErrorMessage(label_msg, "Error calculando la suma de horas totales.");
                }
            }
            return qtty;
        }        

        //UPDATE COUNTERS&GRIDS
        private async Task UpdateCounters()
        {   
            label_payed.Text = Convert.ToString(await GetUserPayedHours());
            label_charged.Text = Convert.ToString(await GetUserChargedHours());
            totHours = await GetUserTotalHours();
            label_total.Text = totHours.ToString();
        }
        private async Task UpdateGrids()
        {
            dataGridView_activities.DataSource = await GetUserSelectedActivities();
            SetDDGVActivitiesProperties(dataGridView_activities);
            dataGridView_TransLog.DataSource = await GetUserTransactions();
            SetDGVBalanceProperties(dataGridView_TransLog);
        }
        private void UpdateAll()
        {
            UpdateCounters().GetAwaiter().OnCompleted(new Action(SetNumericControlParameters));
            UpdateGrids().GetAwaiter();            
        }

        //DATAGRIDVIEW PARAMETERIZATION
        private void SetDDGVActivitiesProperties(DataGridView data)
        {
            DataGridViewColumnCollection columnList = data.Columns;
            foreach (DataGridViewColumn col in columnList)
            {
                //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //Console.WriteLine(col.Name);

                switch (col.Index)
                {
                    case 2: //name                           
                        data.Columns[col.Index].Visible = true;
                        data.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        data.Columns[col.Index].DisplayIndex = 1;
                        data.Columns[col.Index].HeaderText = "Actividad";
                        break;
                    case 4://category                        
                        data.Columns[col.Index].Visible = true;
                        data.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        data.Columns[col.Index].DisplayIndex = 2;
                        data.Columns[col.Index].HeaderText = "Categoría";
                        break;
                    case 3://Description                        
                        data.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        data.Columns[col.Index].Visible = true;
                        data.Columns[col.Index].DisplayIndex = 4;
                        data.Columns[col.Index].HeaderText = "Descripción";
                        break;
                    case 6: //email
                        data.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        data.Columns[col.Index].Visible = true;
                        data.Columns[col.Index].DisplayIndex = 3;
                        data.Columns[col.Index].HeaderText = "Email";
                        break;
                    //selector = 0, Id = 1, name = 2, category = 3, description = 4, userId = 5, email = 6 
                    case 0://Selector
                        data.Columns[col.Index].Visible = false;
                        data.Columns[col.Index].ValueType = Type.GetType("bool");
                        break;
                    case 1://Id                        
                    case 5://userId
                    case 7: //
                        data.Columns[col.Index].Visible = false;
                        data.Columns[col.Index].ValueType = Type.GetType("int");
                        break;
                }
            }
            data.MultiSelect = false;
            data.RowHeadersVisible = false;
            data.Refresh();
        }
        private void SetDGVBalanceProperties(DataGridView data)
        {
            DataGridViewColumnCollection columnList = data.Columns;
            foreach (DataGridViewColumn col in columnList)
            {
                //datetime = b.datetime, activity = a.name, qtty = b.qtty
                switch (col.Index)
                {
                    default:
                        data.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        data.Columns[col.Index].Visible = true;
                        break;
                    case 0: //datetime                        
                        data.Columns[col.Index].HeaderText = "Fecha y hora";
                        break;
                    case 1:
                        data.Columns[col.Index].HeaderText = "Actividad";
                        break;
                    case 2:
                        data.Columns[col.Index].HeaderText = "Horas";
                        break;
                }
            }            
            data.RowHeadersVisible = false;
            data.Refresh();
        }

        //NUMERIC UP/DOWN PARAMETERIZATION        
        private int totHours;
        private void SetNumericControlParameters()
        {   
            numericUpDown_qtty.Maximum = totHours + 5;            
            numericUpDown_qtty.Minimum = 0;
            numericUpDown_qtty.Increment = 1;
            numericUpDown_qtty.Value = 0;
        }

        //BUTTON STATUS CHECK
        private void Button_payStatus()
        {
            button_pay.Enabled = numericUpDown_qtty.Value > 0;
        }
        private void test_worker()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=net-6.0            
        }        

        //PAY ACTION
        private async Task Payment()
        {            
            int qtty = (int)numericUpDown_qtty.Value;
            DateTime dt = DateTime.Now;
            using(netimeContainer context = new netimeContainer())
            {
                balance debit = new balance()
                {
                    datetime = dt,
                    userId = this.selectedActivityUserId,
                    qtty = qtty,
                    activityName = this.selectedActivityId,                    
                };
                balance credit = new balance()
                {
                    datetime = dt,
                    userId = CurrentUser.Id,
                    qtty = -1*qtty,
                    activityName = this.selectedActivityId,
                };
                try
                {
                    context.balanceSet.Add(credit);
                    context.balanceSet.Add(debit);
                    await Context.saveChanges(context, label_msg, "PAYMENT FN", UpdateAll);
                }
                catch(Exception err)
                {
                    Console.WriteLine($"Payment fn: {err.Message}");
                    Messages.ErrorMessage(label_msg, "Error accediendo a la base de datos. Transacción cancelada.");
                }
            }
        }
        private int selectedActivityUserId;
        private string selectedActivityId;

        //EVENTOS DEL FORMULARIO
        private void button_pay_Click(object sender, EventArgs e)
        {
            Console.WriteLine(label_name + ": " + numericUpDown_qtty.Value);
            Payment().GetAwaiter();
        }
        private void dataGridView_activities_SelectionChanged(object sender, EventArgs e)
        {
            Button_payStatus();
            Console.WriteLine("SelectionChanged");
            if((sender as DataGridView).SelectedRows.Count > 0)
            {
                DataGridViewCellCollection data = (sender as DataGridView).SelectedRows[0].Cells;

                label_email.Text = data["email"].Value.ToString();
                label_name.Text = data["name"].Value.ToString();
                label_category.Text = data["category"].Value.ToString();

                label_email.Visible = label_name.Visible = label_category.Visible = true;

                selectedActivityId = data["name"].Value.ToString();
                selectedActivityUserId = Convert.ToInt32(data["userId"].Value);
            }
            //selector = 0, Id = 1, name = 2, category = 3, description = 4, userId = 5, email = 6 , activityId=7
        }
        private void dataGridView_TransLog_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_TransLog.ClearSelection();
        }
        private void label_total_TextChanged(object sender, EventArgs e)
        {
            Button_payStatus();
            label_total.ForeColor = totHours < 0 ? Color.Red : Color.Black;            
        }        
        private void numericUpDown_qtty_ValueChanged(object sender, EventArgs e)
        {
            Button_payStatus();
        }

        private void transacciones_Load(object sender, EventArgs e)
        {

        }
    }
}
