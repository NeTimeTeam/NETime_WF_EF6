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
    public partial class UserActivitiesMenu : UserControl
    {
        public UserActivitiesMenu()
        {
            InitializeComponent();
            Load();
        }        
        new public async void Load()
        {
            UpdateCategoriesComboBox();
            UpdataDataGridView();

        }
        //CONTEXT AND SAVECHANGES
        //netimeContainer context = new netimeContainer();


        //RESPONSE MSG
        private void Response(string msg, Color color)
        {
            label_msg.Text = msg;
            label_msg.ForeColor = color;
            label_msg.Visible = true;
        }
        private void ErrMsg(string msg)
        {
            Response(msg, Color.Red);
        }

        //DATA GATHERS
        private List<categories> getListOfCategories()
        {
            List<categories> categories = new List<categories>();
            try
            {
                using(netimeContainer context = new netimeContainer())
                {
                    categories = context.categoriesSet.ToList<categories>();
                }                
            }
            catch (Exception e)
            {
                ErrMsg("Error de acceso a la base de datos.");
                Console.WriteLine(e.Message);
            }
            return categories;
        }
        private async Task<List<categories>> getListOfCategoriesAsync()
        {
            List<categories> categories = new List<categories>();
            try
            {
                using(netimeContainer context = new netimeContainer())
                {
                    categories = await context.categoriesSet.ToListAsync<categories>();
                }                
            }
            catch (Exception e)
            {
                ErrMsg("Error de acceso a la base de datos.");
                Console.WriteLine(e.Message);
            }
            return categories;
        }
        private List<Object> getListOfActivities()
        {
            List<Object> activities;
            try
            {
                using (netimeContainer context = new netimeContainer())
                {
                    activities = context.activitiesSet
                        //
                        //
                        //https://stackoverflow.com/questions/814878/c-sharp-difference-between-and-equals
                        //
                        .Where(a => a.userId == CurrentUser.Id)
                        .Join(context.categoriesSet, a => a.categoriesId, c => c.Id,
                        (a, c) => new { a.Id, a.name, category = c.name, a.description })
                        .Select(s => s).ToList<Object>();
                }                    
            }
            catch (Exception e)
            {
                activities = new List<Object>();
                ErrMsg("Horror. La conexión a la base de datos ha fallado.");
                Console.WriteLine(e.Message);                
            }
            return activities;
        }
        private async Task<List<Actividades>> getListOfActivitiesAsync()
        {
            List<Actividades> activities;
            try
            {
                using(netimeContainer context = new netimeContainer())
                {
                    activities = await (from a in context.activitiesSet
                                        join c in context.categoriesSet on a.categoriesId equals c.Id
                                        where a.userId == CurrentUser.Id
                                        select new Actividades { selector = false, Id= a.Id, name = a.name, category = c.name, description = a.description, userId =  0, email = "none" }).ToListAsync<Actividades>();
                }                
            }
            catch (Exception e)
            {
                activities = new List<Actividades>();
                ErrMsg("Error de acceso a la base de datos.");
                Console.WriteLine(e.Message);
            }
            return activities;
        }

        //COMBOBOX
        private async void UpdateCategoriesComboBox()
        {
            comboBox_Category.DataSource = await getListOfCategoriesAsync();
            comboBox_Category.DisplayMember = "name";
            comboBox_Category.ValueMember = "Id";
        }

        //DataGridView
        private async void UpdataDataGridView()
        {
            dataGridView_Activities.DataSource = await getListOfActivitiesAsync();

            if (dataGridView_Activities.Rows.Count > 0)
            {
                SetDataGridViewProperties(dataGridView_Activities.Columns);
                //dataGridView_Activities.Columns["Id"].Visible = false;                
            }
        }
        private void SetDataGridViewProperties(DataGridViewColumnCollection columnList)
        {
            foreach(DataGridViewColumn col in columnList)
            {
                //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //Console.WriteLine(col.Name);
                
                switch (col.Name)
                {   
                    case "name":
                        dataGridView_Activities.Columns[col.Name].Name = "Actividad";
                        dataGridView_Activities.Columns[col.Name].Visible = true;
                        dataGridView_Activities.Columns[col.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView_Activities.Columns[col.Name].DisplayIndex = 1;
                        break;
                    case "category":
                        dataGridView_Activities.Columns[col.Name].Name = "Categoria";
                        dataGridView_Activities.Columns[col.Name].Visible = true;
                        dataGridView_Activities.Columns[col.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView_Activities.Columns[col.Name].DisplayIndex = 2;
                        break;
                    case "description":
                        dataGridView_Activities.Columns[col.Name].Name = "Descripción";
                        dataGridView_Activities.Columns[col.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView_Activities.Columns[col.Name].Visible = true;
                        dataGridView_Activities.Columns[col.Name].DisplayIndex = 3;
                        break;
                    case "selector":
                        dataGridView_Activities.Columns[col.Name].Name = "Sel.";
                        dataGridView_Activities.Columns[col.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView_Activities.Columns[col.Name].Visible = true;
                        dataGridView_Activities.Columns[col.Name].DisplayIndex = 0;
                        break;
                    case "Id":
                    case "email":
                    case "userId":
                        dataGridView_Activities.Columns[col.Name].Visible = false;
                        break;
                    default:
                        
                        break;
                }
            }            
        }

        //CREAR ACTIVIDAD
        //VERIFIACIÓN DE LOS DATOS INTRODUCIDOS Y ACTIVACIÓN DEL BOTÓN CREAR ACTIVIDAD.
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            isValidTextBox(textBox);
        }
        private void isValidTextBox(TextBox textBox)
        {
            switch (textBox.Name)
            {
                case "textBox_name":
                    Utilities.setTextBoxStatus(Utilities.nameValidation(textBox.Text), textBox);
                    break;
                case "textBox_ActivityDesc":
                    Utilities.setTextBoxStatus(Utilities.descriptionValidation(textBox.Text), textBox);
                    break;
            }            
        }
        private void textBox_CausesValidationChanged(object sender, EventArgs e)
        {            
            TextBox[] textboxes = { this.textBox_name, this.textBox_ActivityDesc };
            Utilities.checkTextboxStatus(textboxes, button_AddActivity);            
        }
        private void checkUserTextboxStatus()
        {
            button_AddActivity.Enabled = (textBox_ActivityDesc.CausesValidation & textBox_name.CausesValidation);
        }
        private async void CreateActivity()
        {
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    //Creamos un objeto Activities con los datos del formulario
                    activities activity = new activities()
                    {
                        name = this.textBox_name.Text,
                        description = this.textBox_ActivityDesc.Text,
                        categoriesId = Convert.ToInt32(this.comboBox_Category.SelectedValue),
                        userId = CurrentUser.Id,
                    };

                    int activityExist = (from a in context.activitiesSet
                                         where a.name.Equals(this.textBox_name.Text) & a.userId == CurrentUser.Id
                                         select a).Count();
                    if (activityExist > 0)
                    {
                        //MessageBox.Show("El usuario ya existe");
                        Messages.ErrorMessage(label_msg, $"Error: Ya existe una actividad con el nombre {this.textBox_name.Text}.");
                        Utilities.setTextBoxStatus(false, this.textBox_name);
                    }
                    else
                    {
                        //Le pasamos el objeto al context.
                        context.activitiesSet.Add(activity);
                        //Solicitamos al context que guarde los cambios en la BD.
                        await Context.saveChanges(context, this.label_msg, "CREATE USER", ActivityCreated);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }                        
        }
        private void ActivityCreated()
        {
            Messages.Message(label_msg, $"Actividad {this.textBox_name.Text} creada.", Color.Black);
            CleanTextBoxes();
            UpdataDataGridView();
        }
        private void CleanTextBoxes()
        {
            textBox_name.Text = string.Empty;
            textBox_ActivityDesc.Text = string.Empty;
        }
        private void button_AddActivity_Click(Object sender, EventArgs e)
        {
            CreateActivity();
        }

        //BORRAR ACTIVIDADES
        private void button_DeleteActivity_Click(object sender, EventArgs e)
        {
            List<int> activitiesId = new List<int>();
            DataGridViewRowCollection rowList = dataGridView_Activities.Rows;
            foreach (DataGridViewRow row in rowList)
            {                
                if ((bool)row.Cells[0].Value)
                {
                    activitiesId.Add(Convert.ToInt32(row.Cells["Id"].Value));
                }                
            }            
            DeleteActivities(activitiesId);            
        }
        private void dataGridView_Activities_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {   
        }
        private async void DeleteActivities(int activityId)
        {
            using(netimeContainer context = new netimeContainer())
            {
                
                try
                {
                    activities activity = context.activitiesSet.Find(activityId);
                    await Context.saveChanges(context, label_msg, "DELETE ACTIVITIES");
                }
                catch(Exception e)
                {
                    Messages.ErrorMessage(label_msg, "Error accediendo a la base de datos. Borrado cancelado.");
                    Console.WriteLine(e.Message);
                }
            }
        }
        private async void DeleteActivities(List<int> activitiesId)
        {
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    foreach(int Id in activitiesId)
                    {
                        activities activity = context.activitiesSet.Find(Id);
                        context.activitiesSet.Remove(activity);
                    }
                    await Context.saveChanges(context, label_msg, "DELETE ACTIVITIES", UpdataDataGridView);
                }catch(Exception e)
                {
                    Messages.ErrorMessage(label_msg, $"Error accediendo a la base de datos. Borrado cancelado.");
                    Console.WriteLine(e.Message);
                }
            }
        }

        //EVENTOS DATAGRIDVIEW
        private void dataGridView_Activities_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("dataGridView_Activities_CellEnter");
        }

        private void dataGridView_Activities_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("ataGridView_Activities_CellLeave");
        }

        private void dataGridView_Activities_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = sender as DataGridView;            
            int Id = Convert.ToInt32(data["Id", e.RowIndex].Value);
            string value = data[e.ColumnIndex, e.RowIndex].Value.ToString();
            
            Console.WriteLine("dataGridView_Activities_CellValueChanged " + Id +" "+ e.ColumnIndex +" "+value);

            ErrorObject res = IsValidNewTextInCell(e.ColumnIndex, value);
            if (res.status)
            {
                Messages.ErrorMessage(label_msg, res.message);
            }
            else
            {
                UpdataActivityAttribute(value, Id);
            }
        }
        private ErrorObject IsValidNewTextInCell(int col, string value)
        {
            ErrorObject err = new ErrorObject(false, $"Error: \"{value}\" no coumple los requisitos del campo.");
            switch (col)
            {
                case 0:
                    break;
                case 2: //Name
                    if (!Utilities.nameValidation(value))
                    {
                        err.status = true;
                        return err;
                    }
                    //Verifica si el nombre ya existe recorriendo todos los valores de colomna 1.
                    foreach (DataGridViewRow row in dataGridView_Activities.Rows)
                    {
                        if (row.Cells[2].Value.Equals(value))
                        {
                            err.message = $"Error: Ya dispone de una actividad con el nombre \"{value}\".";
                            err.status = true;
                            return err;
                        }
                    }
                    return err;
                case 4: //Category
                    if (!Utilities.nameValidation(value))
                    {
                        err.status = true;
                    }
                    //TODO: solo permitir las categorias listadas.
                    return err;
                case 3://Description
                    if (!Utilities.descriptionValidation(value))
                    {
                        err.status = true;
                    }
                    return err;
            }
            return err;
        }
        
        private void UpdataActivityAttribute(string value,  int Id)
        {
            //TODO: update attribute
        }
        private bool IsSelectedCell()
        {
            foreach(DataGridViewRow row in dataGridView_Activities.Rows)
            {
                Console.WriteLine(row.Cells[0].ValueType.Name);
                if (row.Cells[0].ValueType.Equals("Boolean"))
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        return true;
                    }                    
                }
            }
            return false;
        }

        private void dataGridView_Activities_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("dataGridView_Activities_CellErrorTextChanged");
        }
    }
}
