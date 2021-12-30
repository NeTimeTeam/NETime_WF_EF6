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
            ReLoad();
        }
        public async void ReLoad()
        {
            await UpdateCategoriesComboBox();
            await UpdataDataGridView();

        }
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
                using (netimeContainer context = new netimeContainer())
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
                using (netimeContainer context = new netimeContainer())
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
        private List<Actividades> getListOfActivities()
        {
            List<Actividades> activities;
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
                        (a, c) => new Actividades { selector = false, Id = a.Id, name = a.name, category = c.name, description = a.description, userId = 0, email = "none" })
                        .ToList<Actividades>();
                }
            }
            catch (Exception e)
            {
                activities = new List<Actividades>();
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
                using (netimeContainer context = new netimeContainer())
                {
                    activities = await (from a in context.activitiesSet
                                        join c in context.categoriesSet on a.categoriesId equals c.Id
                                        where a.userId == CurrentUser.Id
                                        select new Actividades { selector = false, Id = a.Id, name = a.name, category = c.name, description = a.description, userId = 0, email = "none" }).ToListAsync<Actividades>();
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
        private async Task<int> UpdateCategoriesComboBox()
        {
            comboBox_Category.DataSource = await getListOfCategoriesAsync();
            comboBox_Category.DisplayMember = "name";
            comboBox_Category.ValueMember = "Id";
            return 1;
        }

        //DataGridView
        private async Task<bool> UpdataDataGridView()
        {
            dataGridView_Activities.DataSource = await getListOfActivitiesAsync();

            if (dataGridView_Activities.Rows.Count > 0)
            {
                SetDataGridViewProperties(dataGridView_Activities.Columns);

            }
            return true;
        }
        private void SetDataGridViewProperties(DataGridViewColumnCollection columnList)
        {
            foreach (DataGridViewColumn col in columnList)
            {
                //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //Console.WriteLine(col.Name);

                switch (col.Index)
                {
                    case 2: //name                           
                        dataGridView_Activities.Columns[col.Index].Visible = true;
                        dataGridView_Activities.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView_Activities.Columns[col.Index].DisplayIndex = 1;
                        dataGridView_Activities.Columns[col.Index].HeaderText = "Actividad";
                        break;
                    case 4://category                        
                        dataGridView_Activities.Columns[col.Index].Visible = true;
                        dataGridView_Activities.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView_Activities.Columns[col.Index].DisplayIndex = 2;
                        dataGridView_Activities.Columns[col.Index].HeaderText = "Categoria";
                        break;
                    case 3://Description                        
                        dataGridView_Activities.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView_Activities.Columns[col.Index].Visible = true;
                        dataGridView_Activities.Columns[col.Index].DisplayIndex = 3;
                        dataGridView_Activities.Columns[col.Index].HeaderText = "Descripción";
                        break;
                    case 0://Selector           
                        dataGridView_Activities.Columns[col.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView_Activities.Columns[col.Index].Visible = true;
                        dataGridView_Activities.Columns[col.Index].DisplayIndex = 0;
                        dataGridView_Activities.Columns[col.Index].HeaderText = "Sel.";
                        break;
                    case 1://Id
                    case 6://email
                    case 5://userId
                        dataGridView_Activities.Columns[col.Index].Visible = false;
                        break;
                }
            }
            dataGridView_Activities.Refresh();
            foreach (DataGridViewColumn c in columnList)
            {
                Console.WriteLine($"Nombre: {c.Name} - Index: {c.Index}");
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
            //button_AddActivity.Enabled = this.textBox_ActivityDesc.CausesValidation & this.textBox_name.CausesValidation;
            TextBox[] textboxes = { this.textBox_name, this.textBox_ActivityDesc };
            Utilities.checkTextboxStatus(textboxes, button_AddActivity);
        }
        private async Task<bool> CreateActivity()
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
                    return false;
                }
            }
            return true;
        }
        private async void ActivityCreated()
        {
            Messages.Message(label_msg, $"Actividad {this.textBox_name.Text} creada.", Color.Black);
            CleanTextBoxes();
            await UpdataDataGridView();
        }
        private void CleanTextBoxes()
        {
            textBox_name.Text = string.Empty;
            textBox_ActivityDesc.Text = string.Empty;
        }
        private async void button_AddActivity_Click(Object sender, EventArgs e)
        {
            await CreateActivity();
        }

        //BORRAR ACTIVIDADES
        private async void button_DeleteActivity_Click(object sender, EventArgs e)
        {
            List<int> activitiesId = new List<int>();
            DataGridViewRowCollection rowList = dataGridView_Activities.Rows;
            foreach (DataGridViewRow row in rowList)
            {                
                if ((bool)row.Cells[0].Value)
                {
                    activitiesId.Add(Convert.ToInt32(row.Cells[1].Value));
                }                
            }
            await DeleteActivities(activitiesId);            
        }        
        private async Task DeleteActivities(int activityId)
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
        private async Task DeleteActivities(List<int> activitiesId)
        {
            using (netimeContainer context = new netimeContainer())
            {
                try
                {                    
                    foreach(int Id in activitiesId)
                    {
                        List<selected_activities> selActToDelete = context.selected_activitiesSet.Where(s => s.activitiesId == Id).ToList<selected_activities>();
                        foreach(selected_activities sa in selActToDelete)
                        {
                            context.selected_activitiesSet.Remove(sa);
                        }
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
        private void dataGridView_Activities_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("dataGridView_Activities_CellErrorTextChanged");
        }
        private void dataGridView_Activities_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }
        //EVENTO QUE LANZA LA ACTUALIZACIÖN DE LOS ATRIBUTOS.
        private async void dataGridView_Activities_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = sender as DataGridView;
            if (e.RowIndex >= 0 & e.ColumnIndex > 0)
            {
                int Id = Convert.ToInt32(data[1, e.RowIndex].Value);
                string value = data[e.ColumnIndex, e.RowIndex].Value.ToString();
                string attribute = data.Columns[e.ColumnIndex].Name;
                DataGridViewRow row = data.Rows[e.RowIndex];

                string name = row.Cells[2].Value.ToString();
                string cat = row.Cells[4].Value.ToString();
                string desc = row.Cells[3].Value.ToString();

                Console.WriteLine($"dataGridView_Activities_CellValueChanged: {Id} {value} {attribute}");

                ErrorObject res = IsValidNewTextInCell(e.ColumnIndex, value);

                if (res.status)
                {
                    Messages.ErrorMessage(label_msg, res.message);
                    await UpdataDataGridView();
                }
                else
                {
                    await UpdataActivityAttribute(Id, name, cat, desc);                    
                }
            }
        }

        //ACTUALIZAR ATRIBUTOS
        private bool IsValidCategoryName(string value)
        {
            if(value == null) { return false; }
            var categories = getListOfCategories();
            foreach (categories c in categories)
            {
                if (c.name.Equals(value)) { return true; }
            }
            return false;
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
                    var list = getListOfActivities();                    
                    foreach (Actividades a in list)
                    {
                        if (a.name.Equals(value))
                        {
                            err.message = $"Error: Ya dispone de una actividad con el nombre \"{value}\".";
                            err.status = true;
                            return err;
                        }
                    }                    
                    return err;
                case 4: //Category
                    ;
                    if (!IsValidCategoryName(value))
                    {
                        err.message = $"Error: \"{value}\" no es una categoría valida.";
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
        private async Task<ErrorObject> UpdataActivityAttribute(int Id, string name, string category, string description)
        {
            ErrorObject res = new ErrorObject(false, string.Empty);
            using(netimeContainer context = new netimeContainer())
            {
                activities activity;
                int categoriesId;
                try
                {
                    activity = context.activitiesSet.Find(Id);
                    categoriesId = context.categoriesSet.Where<categories>(c => c.name == category).Select(s => s.Id).FirstOrDefault();
                }
                catch (InvalidOperationException e)
                {
                    res.status = true;
                    res.message = "Error de acceso a la base de datos. Transacción cancelada.";
                    Console.WriteLine(e.Message);
                    return res;
                }
                
                activity.name = name;
                activity.categoriesId = categoriesId;
                activity.description = description;
                
                await Context.saveChanges(context, label_msg, "UPDATE ATTRIBUTE", UpdataDataGridView);                
            }
            return res;
        }
        private async Task<ErrorObject> UpdataActivityAttribute(int Id, string name, int category, string description)
        {
            ErrorObject res = new ErrorObject(false, string.Empty);
            using (netimeContainer context = new netimeContainer())
            {
                activities activity;
                try
                {
                    activity = context.activitiesSet.Find(Id);                    
                }
                catch (InvalidOperationException e)
                {
                    res.status = true;
                    res.message = "Error de acceso a la base de datos. Transacción cancelada.";
                    Console.WriteLine(e.Message);
                    return res;
                }

                activity.name = name;
                activity.categoriesId = category;
                activity.description = description;

                await Context.saveChanges(context, label_msg, "UPDATE ATTRIBUTE", UpdataDataGridView);
            }
            return res;
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

        
    }
}
