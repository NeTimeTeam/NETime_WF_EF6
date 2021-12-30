using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETime_WF_EF6
{

    public partial class Select_Activities : UserControl
    {
        public Select_Activities()
        {
            InitializeComponent();
            start();
        }

        private async void start()
        {
            await UpdateLists();
        }

        
        private List<Actividades> selectedActivities;
        private List<Actividades> availableActivities;

        private async Task<bool> UpdateLists()
        {
            availableActivities = await GetAvailableActivities();
            selectedActivities = await GetSelectedActivities();
            dataGridView_Selected.DataSource = selectedActivities;
            dataGridView_Available.DataSource = availableActivities;
            SetDataGridViewProperties(dataGridView_Available);
            SetDataGridViewProperties(dataGridView_Selected);
            return true;
        }

        private void SetGridProperties(DataGridView dgv)
        {
            dgv.Columns.Add("selector", "Selector");
            dgv.Columns.Add("Id", "Id");
            dgv.Columns.Add("name", "Actividad");
            dgv.Columns.Add("category", "Categoría");
            dgv.Columns.Add("description", "Descripción");
            dgv.Columns.Add("email", "Email");
            dgv.Columns.Add("userId", "userId");

            dgv.Columns["selector"].ValueType = Type.GetType("bool");
            dgv.Columns["selector"].Visible = false;

            dgv.Columns["Id"].ValueType = Type.GetType("int");
            dgv.Columns["Id"].Visible = false;

            dgv.Columns["userId"].ValueType = Type.GetType("int");
            dgv.Columns["userId"].Visible = false;
        }
        private void SetDataGridViewProperties(DataGridView data)
        {
            if (data.Rows.Count > -1)
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
                            data.Columns[col.Index].HeaderText = "Categoria";
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
                            data.Columns[col.Index].Visible = false;
                            data.Columns[col.Index].ValueType = Type.GetType("int");
                            break;
                    }
                }
                data.RowHeadersVisible = false;
                data.Refresh();
                //foreach (DataGridViewColumn c in columnList) { Console.WriteLine($"Nombre: {c.Name} - Index: {c.Index}");}
            }
        }
        //DATA GATHER
        private async Task<List<Actividades>> GetSelectedActivities()
        {
            List<Actividades> list = new List<Actividades>();
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    list = await (from s in context.selected_activitiesSet
                                  join a in context.activitiesSet on s.activitiesId equals a.Id
                                  join u in context.userSet on s.userId equals u.Id
                                  join c in context.categoriesSet on a.categoriesId equals c.Id
                                  where s.userId == CurrentUser.Id
                                  select new Actividades { selector = false, Id = s.Id, name = a.name, category = c.name, description = a.description, userId = s.userId, email = u.email }).ToListAsync<Actividades>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        private async Task<List<Actividades>> GetAvailableActivities()
        {
            List<Actividades> list = new List<Actividades>();
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    list = await (from a in context.activitiesSet
                                  join c in context.categoriesSet on a.categoriesId equals c.Id
                                  join u in context.userSet on a.userId equals u.Id
                                  where !context.selected_activitiesSet.Any(s => s.activitiesId == a.Id) & a.userId != CurrentUser.Id
                                  select new Actividades { selector = false, Id = a.Id, name = a.name, category = c.name, description = a.description, userId = u.Id, email = u.email }).ToListAsync<Actividades>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }
        
        //EVENTS
        private void button_Select_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button_Select");
            int Id = Convert.ToInt32(dataGridView_Available.SelectedRows[0].Cells[1].Value);
            AddActivity(Id);
        }
        private void button_Dismiss_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button_Dismiss");
            int Id = Convert.ToInt32(dataGridView_Selected.SelectedRows[0].Cells[1].Value);
            RemoveActivity(Id);
        }
        private void dataGridView_Selected_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("s_CellContentDoubleClick");
            DataGridView data = sender as DataGridView;
            int Id = Convert.ToInt32(data.Rows[e.RowIndex].Cells[1].Value);
            Console.WriteLine($"RowIndex: {e.RowIndex}, Activity ID: {Id}");
            RemoveActivity(Id);
        }
        private void dataGridView_Available_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("a_CellContentDoubleClick");
            DataGridView data = sender as DataGridView;
            int Id = Convert.ToInt32(data.Rows[e.RowIndex].Cells[1].Value);
            Console.WriteLine($"RowIndex: {e.RowIndex}, Activity ID: {Id}");
            AddActivity(Id);
        }
        private void dataGridView_Selected_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("S__SelectionChanged");
            DataGridView data = sender as DataGridView;
            if (data.SelectedRows.Count > 0)
            {
                button_Dismiss.Enabled = true;
            }
            else
            {
                button_Dismiss.Enabled = false;
            }
        }
        private void dataGridView_Available_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("a_SelectionChanged");
            DataGridView data = sender as DataGridView;
            if (data.SelectedRows.Count > 0)
            {
                button_Select.Enabled = true;
            }
            else
            {
                button_Select.Enabled = false;
            }            
        }
        
        //ADD-REMOVE SEL.ACTIVITIES
        private async Task<bool> AddActivity(int Id)
        {
            using (netimeContainer context = new netimeContainer())
            {
                selected_activities sa = new selected_activities
                {
                    userId = CurrentUser.Id,
                    activitiesId = Id
                };
                context.selected_activitiesSet.Add(sa);
                return await Context.saveChanges(context, label_msg, "SEL.ACTIVITIES.ADD", UpdateLists);
            }
        }
        private async Task<bool> RemoveActivity(int Id)
        {
            using (netimeContainer context = new netimeContainer())
            {
                selected_activities sa = context.selected_activitiesSet.Find(Id);
                context.selected_activitiesSet.Remove(sa);
                return await Context.saveChanges(context, label_msg, "SEL.ACTIVITIES.REMOVE", UpdateLists);
            }
        }
    }
}
