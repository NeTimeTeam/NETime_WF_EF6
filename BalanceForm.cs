using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace NETime_WF_EF6
{
    public partial class BalanceForm : Form
    {
        public BalanceForm()
        {
            InitializeComponent();            
        }

        private netimeContainer context = new netimeContainer();
        private int maxDebtHours = 5;

        private void BalanceForm_Load(object sender, EventArgs e)
        {
            updateUserCombobox();
            updateActivityCombobox();
            updateDataGridView();
            updateTotalHoursTextBox();
            setMaxQttyForTransaction();            
        }

        //COMBOBOX, TEXTBOX AND DATAGRIDVIEW DATA GATHER
        private List<user> getUsers()
        {
            return getUsers(this.context);
        }
        private List<user> getUsers(netimeContainer context)
        {
            List<user> users = new List<user>();
            try
            {
                users = context.userSet.ToList<user>();
            }catch(Exception err)
            {
                Console.WriteLine("getUser: " + err.Message);
            }
            
            return users;
        }
        private List<Actividades> getSelectedActivitiesByUserId(int userId)
        {
            return getSelectedActivitiesByUserId(this.context, userId);
        }
        private List<Actividades> getSelectedActivitiesByUserId(netimeContainer context, int userId)
        {
            List<Actividades> selectedActivitiesList = new List<Actividades>();
            try
            {
                //Este query debe devolver el Id de activities, no el de selected activities. De esta manera el Value devuelto por el ComboBox se puede usar directamente para obtener el userId dela actividad en la Transacción.
                selectedActivitiesList = context.Database.SqlQuery<Actividades>(
                    "Select A.Id as Id, A.name as name, A.description, U.email, C.name as category from activitiesSet as A inner join selected_activitiesSet as S on A.Id = S.activitiesId " +
                    "inner join userSet as U on U.Id = A.userId " +
                    "inner join categoriesSet as C on C.Id = A.categoriesId " +
                    "where S.userId = @Id", new SqlParameter("@id", userId)).ToList<Actividades>();
            }
            catch (Exception err)
            {
                Console.WriteLine("getSelectedActivitiesByUserId: " + err.Message);
            }            
            return selectedActivitiesList;
        }
        private List<Balance> getBalanceByUserId(int userId)
        {
            return getBalanceByUserId(this.context, userId);
        }
        private List<Balance> getBalanceByUserId(netimeContainer context, int userId)
        {
            List<Balance> balanceList = new List<Balance>();
            try
            {
                balanceList = context.Database.SqlQuery<Balance>(
                    "SELECT B.datetime, ISNULL(A.name, 'Actividad eliminada') as activity, B.qtty from balanceSet as B left join activitiesSet as A ON B.activitiesId = A.Id " +
                    "WHERE B.userId = @userId", new SqlParameter("@userId", userId)).ToList<Balance>();
            }catch (Exception err)
            {
                Console.WriteLine("getBalanceByUserId: " + err.Message);
            }            
            //List<balance> balance = context.balanceSet.Where(b => b.userId.Equals(userId)).ToList<balance>();
            return balanceList;
        }
        private int getBalanceResultByUserId(int userId)
        {
            return getBalanceResultByUserId(this.context, userId);
        }
        private int getBalanceResultByUserId(netimeContainer context, int userId)
        {
            int hours = 0;
            try
            {
                hours = context.balanceSet.Where(u => u.userId.Equals(userId)).Sum(h => h.qtty);
            }catch(Exception err)
            {
                Console.WriteLine("getBalanceResultByUserId: " + err.Message);
            }
            return hours;
        }
        private int getUserIdByActivityId(int activityId)
        {
            return getUserIdByActivityId(this.context, activityId);
        }
        private int getUserIdByActivityId(netimeContainer context, int activityId)
        {

            int userId = context.activitiesSet.Find(activityId).userId;
            return userId;
        }

        //UPDATE COMBOBOX, TEXTBOS AND DATAGRIDVIEW
        private void updateUserCombobox()
        {
            comboBox_payer.DataSource = getUsers();
            comboBox_payer.DisplayMember = "email";
            comboBox_payer.ValueMember = "Id";
        }
        private void updateActivityCombobox()
        {            
            comboBox_Activity.Text = ""; //Insertado para evitar q muestre el texto de un usuario seleccionado previamente cuando el actual no tiene actividades seleccionadas.
            int userId = Int32.Parse(comboBox_payer.SelectedValue.ToString());
            comboBox_Activity.DataSource = getSelectedActivitiesByUserId(userId);
            comboBox_Activity.DisplayMember = "name";
            comboBox_Activity.ValueMember = "Id";
        }
        private void updateDataGridView()
        {
            int userId = Int32.Parse(comboBox_payer.SelectedValue.ToString());
            dgt_balance.DataSource = getBalanceByUserId(userId);            
        }
        private void updateTotalHoursTextBox()
        {
            int userId = Int32.Parse(comboBox_payer.SelectedValue.ToString());
            textBox_total_hours.Text = getBalanceResultByUserId(userId).ToString();
        }
        private void setMaxQttyForTransaction()
        {
            int currentHours = Int32.Parse(textBox_total_hours.Text);
            currentHours += maxDebtHours;
            numericUpDown_qtty.Maximum = currentHours;
            numericUpDown_qtty.Minimum = 0;
            numericUpDown_qtty.Value = 0; //Establecer el valor de inicio en 0.
        }

        //USER SELECT DETECTION
        private void userChanged()
        {
            updateActivityCombobox();
            updateDataGridView();
            updateTotalHoursTextBox();
            setMaxQttyForTransaction();
            enablePayButton();
        }
        private void comboBox_payer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_payer.SelectedValue.GetType().Name.Equals("Int32"))
            {
                userChanged();
            }            
        }

        //FORM DATA VALIDATION: ENABLE PAY BUTTON.
        private void numericUpDown_qtty_ValueChanged(object sender, EventArgs e)
        {
            button_pay.Enabled = validForm();
        }
        private bool validForm()
        {
            if(comboBox_Activity.SelectedValue != null)
            {
                if (numericUpDown_qtty.Value > 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void enablePayButton()
        {
            button_pay.Enabled = validForm();
        }
        
        //TRANSACTIONS
        private void executeTransaction()
        {            
            int payerUserId = (int)comboBox_payer.SelectedValue;
            int activityId = (int)comboBox_Activity.SelectedValue;
            int qtty = (int)numericUpDown_qtty.Value;            
            int receiverUserId = getUserIdByActivityId(activityId);
            DateTime datetime = DateTime.Now;

            balance credit = new balance
            {
                datetime = datetime,
                userId = payerUserId,
                activitiesId = activityId,
                qtty = qtty*-1,
                sing = true
            };
            balance debit = new balance
            {
                datetime = datetime,
                userId = receiverUserId,
                activitiesId = activityId,
                qtty = qtty,
                sing = false
            };
            this.context.balanceSet.Add(credit);
            this.context.balanceSet.Add(debit);            

            try
            {
                this.context.SaveChanges();
            }catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        private void button_pay_Click(object sender, EventArgs e)
        {
            executeTransaction();
            updateDataGridView();
            updateTotalHoursTextBox();
            setMaxQttyForTransaction();
        }
    }
}
