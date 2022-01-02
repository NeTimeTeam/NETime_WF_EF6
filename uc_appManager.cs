using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETime_WF_EF6
{
    public partial class appManager : UserControl
    {
        public appManager()
        {
            InitializeComponent();
            UpdateCounters().GetAwaiter();
            UpdateUserListController();            
            this.timer_counters.Start();
        }

        //DATA GATHERS
        private List<user> GetUsers()
        {
            List<user> users = new List<user>();
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    users = context.userSet.OrderBy(u => u.email).ToList<user>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
            return users;
        }
        private async Task<int> GetActivitiesCounter()
        {
            int res = -1;
            try
            {
                using(netimeContainer context = new netimeContainer())
                {
                    res = await Task.Run(() => context.activitiesSet.Count());
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.InnerException);
            }
            return res;
        }
        private async Task<int> GetUsersCounter()
        {
            int res = -1;
            try
            {
                using(netimeContainer context = new netimeContainer())
                {
                    res = await Task.Run(() => context.userSet.Count());
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return res;
        }
        private async Task<int> GetSelectedActivitesCounter()
        {
            int res = -1;
            try
            {
                using(netimeContainer context = new netimeContainer())
                {
                    res = await Task.Run(()=> context.selected_activitiesSet.Count());
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return res;
        }
        private async Task<int> GetTotalExchangedHours()
        {
            int res = -1;
            try
            {
                using(netimeContainer context = new netimeContainer())
                {
                    res = await Task.Run(() => (from b in context.balanceSet where b.qtty > 0 select b.qtty)
                    .DefaultIfEmpty(0).Sum());
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                res = 0;
            }
            return res;
        }

        //XML EXPORT/IMPORT METHODS
        private bool VerifyCategoryImportData(categories entity)
        {
            using(netimeContainer context = new netimeContainer())
            {
                if (!Utilities.nameValidation(entity.name))
                {
                    Console.WriteLine("Error importando categorías. {0} no es un nombre válido.", entity.name);
                    return false;
                }
                if (!Utilities.nameValidation(entity.family))
                {
                    Console.WriteLine("Error importando categorías. {0} no es un nombre de famila válido.", entity.family);
                    return false;
                }
                if (context.categoriesSet.Where(c => c.name.Equals(entity.name)).Count() > 0)
                {
                    Console.WriteLine("Error importando categorías. El nombre {0} ya existe en la base de datos.", entity.name);
                    return false;
                }
                Console.WriteLine("Categoría {0} - {1} importada.", entity.name, entity.family);
                return true;
            }            
        }
        private bool VerifyUserImportData(user entity)
        {
            using(netimeContainer context =new netimeContainer())
            {
                if (!Utilities.nameValidation(entity.name))
                {
                    Console.WriteLine("Error importando usuarios. {0} no es un nombre válido.", entity.name);
                    return false;
                }
                if (!Utilities.descriptionValidation(entity.address))
                {
                    Console.WriteLine("Error importando usuarios. {0} no es una dirección válida.", entity.address);
                    return false;
                }
                if (!Utilities.emailValidation(entity.email))
                {
                    Console.WriteLine("Error importando usuarios. {0} no es un email válido.", entity.email);
                    return false;
                }
                if (!Utilities.phoneValidation(entity.phone))
                {
                    Console.WriteLine("Error importando usuarios. {0} no es un teléfono válido.", entity.phone);
                    return false;
                }
                if (context.userSet.Where(u => u.email.Equals(entity.email)).Count() > 0)
                {
                    Console.WriteLine("Error importando usuarios. El email {0} ya existe en la base de datos.", entity.email);
                    return false;
                }
                Console.WriteLine("Usuario {0} importado.", entity.email);
                return true;
            }            
        }
        private async Task InsertListOfData<T>(IEnumerable<T> data)
        {
            using(netimeContainer context = new netimeContainer())
            {
                IEnumerator<T> dataEnum = data.GetEnumerator();
                while (dataEnum.MoveNext())
                {
                    switch (dataEnum.Current.GetType().Name)
                    {
                        case "user":
                            user nuser = dataEnum.Current as user;
                            if (VerifyUserImportData(nuser))
                            {
                                context.userSet.Add(nuser);
                            }
                            break;
                        case "categories":
                            categories nCategory = dataEnum.Current as categories;
                            if (VerifyCategoryImportData(nCategory))
                            {
                                context.categoriesSet.Add(nCategory);
                            }
                            break;
                    }
                }
                await Context.saveChanges(context,"IMPORT XML DATA");
            }            
        }
        //mode: {0} Users, {1} Activities, {2} Selection, {3} Categories, {4} Balance
        private void ExportData(int mode)
        {
            using(netimeContainer context = new netimeContainer())
            {
                if (mode == 0) //Users
                {
                    xmlTool.genXmlFromListOftEntities(context.userSet.ToList<user>());
                }
                if (mode == 1) //Activities
                {
                    //MessageBox.Show("Exportar actividades", "EXPORT");
                    xmlTool.genXmlFromListOftEntities(context.activitiesSet.ToList<activities>());                    
                }
                if (mode == 2) //Selection
                {
                    xmlTool.genXmlFromListOftEntities(context.selected_activitiesSet.ToList<selected_activities>());
                }
                if(mode == 3) //Categories
                {
                    //MessageBox.Show("Exportar categorías", "EXPORT");
                    xmlTool.genXmlFromListOftEntities(context.categoriesSet.ToList<categories>());
                }
                if(mode == 4) // Balance
                { }
            }            
        }
        private void ImportCategories()
        {
            var data = xmlTool.importFromFile<categories>();
            if (data.Count() > 0)
            {
                InsertListOfData<categories>(data).GetAwaiter();
            }
        }
        private void ImportUsers()
        {
            var data = xmlTool.importFromFile<user>();
            if (data.Count() > 0)
            {
                InsertListOfData<user>(data).GetAwaiter();
            }            
        }

        //BUTTON EVENTS IMPORT-EXPORT        
        private void button_export_users_Click(object sender, EventArgs e)
        {
            ExportData(0);
        }
        private void button_export_activities_Click(object sender, EventArgs e)
        {
            ExportData(1);
        }
        private void button_export_balance_Click(object sender, EventArgs e)
        {
            ExportData(4);
        }
        private void button_export_categories_Click(object sender, EventArgs e)
        {
            ExportData(3);
        }
        private void button_import_categories_Click(object sender, EventArgs e)
        {
            ImportCategories();
        }
        private void button_import_users_Click(object sender, EventArgs e)
        {
            ImportUsers();
        }

        //USER DELETION METHODS & PROPERTIES        
        private async Task DeleteUserBalance(int Id)
        {
            using(netimeContainer context = new netimeContainer())
            {
                try
                {
                    List<balance> entities= context.balanceSet.Where(b => b.userId == Id).ToList<balance>();
                    context.balanceSet.RemoveRange(entities);
                }
                catch(Exception ex)
                {
                    Console.Write(ex.InnerException);
                }
                await Context.saveChanges(context, "APP MANAGER DELETE USER BALANCE");
            }
        }
        private async Task DeleteUserSelection(int Id)
        {
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    List<selected_activities> entities = context.selected_activitiesSet.Where(sa => sa.userId == Id).ToList<selected_activities>();
                    context.selected_activitiesSet.RemoveRange(entities);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.InnerException);
                }
                await Context.saveChanges(context, "APP MANAGER DELETE USER SELECTION");
            }

        }
        private async Task DeleteUserActivities(int Id)
        {
            using(netimeContainer context = new netimeContainer())
            {
                try
                {
                    List<selected_activities> selected_Activities = (from sa in context.selected_activitiesSet join
                                                                     a in context.activitiesSet on sa.activitiesId equals a.Id
                                                                     where a.userId == Id select sa).ToList<selected_activities>();
                    selected_Activities.ForEach(sa => context.selected_activitiesSet.Remove(sa));
                    
                    List < activities > entities = context.activitiesSet.Where(a => a.userId == Id).ToList<activities>();
                    context.activitiesSet.RemoveRange(entities);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.InnerException);
                }
                await Context.saveChanges(context, "APP MANAGER DELETE USER ACTIVITIES");
            }
        }
        private async Task DeleteUser(int Id)
        {
            await DeleteUserBalance(Id);
            await DeleteUserSelection(Id);
            await DeleteUserActivities(Id);

            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    var u = context.userSet.Find(Id);
                    if (u != null)
                    {
                        context.userSet.Remove(u);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.InnerException);
                }
                await Context.saveChanges(context, "APP MANAGER DELETE USER");
            }
            if (GetSelectedUserId() == CurrentUser.Id)
            {
                CurrentUser.RemoveUser();
                this.Dispose(true);
            }
            else
            {
                UpdateUserListController();
            }            
        }
        private int GetSelectedUserId()
        {
            return (int)this.comboBox_users_list.SelectedValue;
        }        
        private void UpdateUserListController()
        {
            this.comboBox_users_list.DataSource = GetUsers();
            this.comboBox_users_list.DisplayMember = "email";
            this.comboBox_users_list.ValueMember = "Id";
            this.comboBox_users_list.SelectedText = CurrentUser.email;
            this.comboBox_users_list.SelectedValue = CurrentUser.Id;        
        }

        //BUTTON USER DELETION EVENTS
        private void button_delete_balance_Click(object sender, EventArgs e)
        {
            DeleteUserBalance(GetSelectedUserId()).GetAwaiter();
        }
        private void button_delete_selAct_Click(object sender, EventArgs e)
        {
            DeleteUserSelection(GetSelectedUserId()).GetAwaiter();
        }
        private void button_delete_activities_Click(object sender, EventArgs e)
        {
            DeleteUserActivities(GetSelectedUserId()).GetAwaiter();
        }
        private void button_delete_user_Click(object sender, EventArgs e)
        {
            DeleteUser(GetSelectedUserId()).GetAwaiter();            
        }

        //DB DELETION METHODS
        private async Task DeleteAllBalances()
        {
            using(netimeContainer context = new netimeContainer())
            {
                try
                {
                    List<balance> balances = context.balanceSet.ToList<balance>();
                    context.balanceSet.RemoveRange(balances);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                await Context.saveChanges(context, "APP MANAGER DELETE ALL BALANCES");
            }
        }
        private async Task DeleteAllSelections()
        {
            using(netimeContainer context = new netimeContainer())
            {
                try
                {
                    List<selected_activities> selected_Activities = context.selected_activitiesSet.ToList<selected_activities>();
                    context.selected_activitiesSet.RemoveRange(selected_Activities);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                await Context.saveChanges(context, "APP MANAGER DELETE ALL SELECTION");
            }
        }
        private async Task DeleteAllActivities()
        {
            await DeleteAllSelections();
            using(netimeContainer context = new netimeContainer())
            {
                try
                {
                    List<activities> activitiesList = context.activitiesSet.ToList<activities>();
                    context.activitiesSet.RemoveRange(activitiesList);
                }catch( Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                await Context.saveChanges(context, "APP MANAGER DELETION ALL ACTIVITIES");
            }
        }
        private async Task DeleteAllCategories() 
        {
            await DeleteAllActivities();
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    List<categories> catList = context.categoriesSet.ToList<categories>();
                    context.categoriesSet.RemoveRange(catList);
                }catch ( Exception ex) { Console.WriteLine(ex.InnerException); }
                await Context.saveChanges(context, "APP MANAGER DELETION ALL CATEGORIES");
            }
        }
        private async Task DeleteAllUsers()
        {
            await DeleteAllBalances();
            await DeleteAllCategories();
            using(netimeContainer context = new netimeContainer())
            {
                try
                {
                    List<user> users = context.userSet.ToList<user>();
                    context.userSet.RemoveRange(users);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                await Context.saveChanges(context, "APP MANAGER DELETION ALL USERS");
            }
            CurrentUser.RemoveUser();
            this.Dispose(true);
        }

        //BUTTON DB DELETION EVENTS
        private void button_db_balance_Click(object sender, EventArgs e)
        {
            DeleteAllBalances().GetAwaiter();
        }
        private void button_db_selAct_Click(object sender, EventArgs e)
        {
            DeleteAllSelections().GetAwaiter();
        }
        private void button_db_activities_Click(object sender, EventArgs e)
        {
            DeleteAllActivities().GetAwaiter();
        }
        private void button_db_users_Click(object sender, EventArgs e)
        {
            DeleteAllUsers().GetAwaiter();
        }
        private void button_db_categories_Click(object sender, EventArgs e)
        {
            DeleteAllCategories().GetAwaiter();
        }
        private void button_delete_all_Click(object sender, EventArgs e)
        {
            DeleteAllUsers().GetAwaiter();
        }
        
        //COUNTERS METHODS
        private async Task UpdateCounters()
        {
            await UpdateActivitiesCounter();
            await UpdateBalanceCounter();
            await UpdateSelectionCounter();
            await UpdateUsersCounter();
        }
        private async Task UpdateUsersCounter()
        {
            this.toolStripStatusLabel_user.Text = $"Usuarios: {Convert.ToString(await GetUsersCounter())}";
        }
        private async Task UpdateActivitiesCounter()
        {
            this.toolStripStatusLabel_activities.Text = $"Actividades: {Convert.ToString(await GetActivitiesCounter())}";
        }
        private async Task UpdateBalanceCounter()
        {
            this.toolStripStatusLabel_balance.Text = $"Horas: {Convert.ToString(await GetTotalExchangedHours())}";
        }
        private async Task UpdateSelectionCounter()
        {
            this.toolStripStatusLabel_selection.Text = $"Selecciones: { Convert.ToString(await GetSelectedActivitesCounter())}";
        }
        
        //TIMER
        private void timer_counters_Tick(object sender, EventArgs e)
        {
            UpdateCounters().GetAwaiter();
        }
    }
}
