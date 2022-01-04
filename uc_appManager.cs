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
                    NetimeLogger(ex.InnerException.ToString());
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
                NetimeLogger(ex.InnerException.ToString());
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
                NetimeLogger(ex.InnerException.ToString());
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
                NetimeLogger(ex.InnerException.ToString());
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
                NetimeLogger(ex.InnerException.ToString());
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
                    NetimeLogger($"Error importando categorías. {entity.name} no es un nombre válido.");
                    return false;
                }
                if (!Utilities.nameValidation(entity.family))
                {
                    NetimeLogger($"Error importando categorías. {entity.family} no es un nombre de famila válido.");
                    return false;
                }
                if (context.categoriesSet.Where(c => c.name.Equals(entity.name)).Count() > 0)
                {
                    NetimeLogger($"Error importando categorías. El nombre {entity.name} ya existe en la base de datos.");
                    return false;
                }
                NetimeLogger($"Categoría {entity.name} - {entity.family} importada.");
                return true;
            }            
        }
        private bool VerifyUserImportData(user entity)
        {
            using(netimeContainer context =new netimeContainer())
            {
                if (!Utilities.nameValidation(entity.name))
                {
                    NetimeLogger($"Error importando usuarios. {entity.name} no es un nombre válido.");
                    return false;
                }
                if (!Utilities.descriptionValidation(entity.address))
                {
                    NetimeLogger($"Error importando usuarios. {entity.address} no es una dirección válida.");
                    return false;
                }
                if (!Utilities.emailValidation(entity.email))
                {
                    NetimeLogger($"Error importando usuarios. {entity.email} no es un email válido.");
                    return false;
                }
                if (!Utilities.phoneValidation(entity.phone))
                {
                    NetimeLogger($"Error importando usuarios. {entity.phone} no es un teléfono válido.");
                    return false;
                }
                if (context.userSet.Where(u => u.email.Equals(entity.email)).Count() > 0)
                {
                    NetimeLogger($"Error importando usuarios. El email {entity.email} ya existe en la base de datos.");
                    return false;
                }
                NetimeLogger($"Usuario {entity.email} importado.");                
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
                UpdateUserListController();
            }            
        }
        //mode: {0} Users, {1} Activities, {2} Selection, {3} Categories, {4} Balance
        private void ExportData(int mode)
        {            
            using (netimeContainer context = new netimeContainer())
            {
                if (mode == 0) //Users
                {                    
                    xmlTool.genXmlFromListOftEntities(context.userSet.ToList<user>());
                    NetimeLogger($"Exportando usuarios.");
                }
                if (mode == 1) //Activities
                {
                    var data = context.activitiesSet.ToList<activities>();
                    if(data.Count > 0)
                    {
                        xmlTool.genXmlFromListOftEntities(data as List<activities>);
                        NetimeLogger($"Exportando {data.Count()} actividades.");
                        return;                        
                    }
                    NetimeLogger("La base de datos no contiene actividades.");
                    return;
                }
                if (mode == 2) //Selection
                {
                    var data = context.selected_activitiesSet.ToList<selected_activities>();
                    if(data.Count < 1)
                    {
                        NetimeLogger("No hay actividades actividades seleccionadas en la base de datos.");
                        return;
                    }
                    xmlTool.genXmlFromListOftEntities(data as List<selected_activities>);
                    NetimeLogger($"Exportando {data.Count()} actividades seleccionadas.");
                    return;
                }
                if(mode == 3) //Categories
                {
                    var data = context.categoriesSet.ToList<categories>();
                    if(data.Count() < 1)
                    {
                        NetimeLogger("No hay difinida ninguna categoría en la base de datos.");
                        return;
                    }
                    xmlTool.genXmlFromListOftEntities(data as List<categories>);
                    NetimeLogger($"Exportando {data.Count()} categorías.");
                    return;
                }
                if(mode == 4) // Balance
                { NetimeLogger("Exportación del balance no disponible todavía."); return; }
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
        //TODO: implementar un LOGGER de verdad >> un list<string> un formato y un Task.Run q actualice el txtbox con los datos del list del último al primero. Máx. 200 lineas.
        private void NetimeLogger(string txt)
        {
            string newtxt = $"{DateTime.Now}: {txt}";
            List<string> oldtxt = textBox_info.Lines.ToList<string>();
            oldtxt.Insert(0, newtxt);
            textBox_info.Lines = oldtxt.ToArray<string>();
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
                    NetimeLogger(ex.InnerException.ToString());
                }
                await Context.saveChanges(context, "APP MANAGER DELETE USER BALANCE");
                NetimeLogger($"Se ha borrado el balance del usuario {comboBox_users_list.Text}.");
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
                    NetimeLogger(ex.InnerException.ToString());
                }
                await Context.saveChanges(context, "APP MANAGER DELETE USER SELECTION");
            }
            NetimeLogger($"Se han eliminado las actividades seleccionadas del usuario {comboBox_users_list.Text}.");
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
                    NetimeLogger(ex.InnerException.ToString());
                }
                await Context.saveChanges(context, "APP MANAGER DELETE USER ACTIVITIES");
            }
            NetimeLogger($"Se han eliminado las actividades del usuario {comboBox_users_list.Text}.");
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
                    NetimeLogger(ex.InnerException.ToString());
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
                NetimeLogger($"Usuario {comboBox_users_list.SelectedText} eliminado.");
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
                    NetimeLogger(ex.InnerException.ToString());
                }
                await Context.saveChanges(context, "APP MANAGER DELETE ALL BALANCES");
            }
            NetimeLogger($"Se han eliminado todos los registros de tranascciones.");
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
                    NetimeLogger(ex.InnerException.ToString());
                }
                await Context.saveChanges(context, "APP MANAGER DELETE ALL SELECTION");
            }
            NetimeLogger($"Se han deseleccionado todas las actividades.");
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
                    NetimeLogger(ex.InnerException.ToString());
                }
                await Context.saveChanges(context, "APP MANAGER DELETION ALL ACTIVITIES");
            }
            NetimeLogger($"Se han eliminado todas las actividades.");
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
                }catch ( Exception ex) { NetimeLogger(ex.InnerException.ToString()); }
                await Context.saveChanges(context, "APP MANAGER DELETION ALL CATEGORIES");
            }
            NetimeLogger($"Categorías eliminadas. Es necesario disponer de al menos una categoría para poder crear actividades.");
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
                    NetimeLogger(ex.InnerException.ToString());
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
