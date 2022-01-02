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
            UpdateUserListController();
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
        private void button1_Click(object sender, EventArgs e)
        {
            //botón_db_categories
        }
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
        private void DeleteUserBalance(int Id) { }
        private void DeleteUserSelectio(int Id) { }
        private void DeleteUserActivities(int Id) { }
        private void DeleteUser(int Id) { }
        private int GetSelectedUserId()
        {
            return (int)this.comboBox_users_list.SelectedValue;
        }
        private List<user> GetUsers()
        {
            List<user> users = new List<user>();
            using(netimeContainer context = new netimeContainer())
            {
                try
                {
                    users = context.userSet.OrderBy(u => u.email).ToList<user>();
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
            return users;
        }
        private void UpdateUserListController()
        {
            this.comboBox_users_list.DataSource = GetUsers();
            this.comboBox_users_list.DisplayMember = "email";
            this.comboBox_users_list.ValueMember = "Id";
            this.comboBox_users_list.SelectedText = CurrentUser.email;
            this.comboBox_users_list.SelectedValue = CurrentUser.Id;        
        }

        //BUTTON EVENTS USER DELETION
        private void button_delete_balance_Click(object sender, EventArgs e)
        {

        }
        private void button_delete_selAct_Click(object sender, EventArgs e)
        {

        }
        private void button_delete_activities_Click(object sender, EventArgs e)
        {

        }
        private void button_delete_user_Click(object sender, EventArgs e)
        {

        }

     
    }
}
