using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using MongoDB.Bson.Serialization.Attributes;
using System.Data;
using MongoDB.Driver.Builders;


namespace MongoSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected static IMongoClient m_client;

        protected static IMongoDatabase m_database;

        MongoRep repo;

        public MainWindow()
        {
            InitializeComponent();

            repo = new MongoRep();

            GetDocs();
        }

        private void DeleteDoc()
        {
            AdminData recordToDelete = grdcAdminData.GetFocusedRow() as AdminData;

            if(!string.IsNullOrEmpty(repo.DeleteDocument(recordToDelete._id)))
            {
                GetDocs();
            }
        }

        private void UpdateDoc()
        {
            AdminData admindata = grdcAdminData.GetFocusedRow() as AdminData;

            if (!string.IsNullOrEmpty(repo.UpdateDocument(admindata)))
            {
                GetDocs();
            }
        }

        private void AddDocs()
        {
            AdminAddDialog addDialog = new AdminAddDialog();

            addDialog.ShowDialog();

            if (addDialog.DialogResult == true)
            {
                if (!string.IsNullOrEmpty(repo.InsertDocument(addDialog.Entity)))
                {
                    GetDocs();
                }
            }
        }

        private void GetDocs()
        {
            List<AdminData> adminList = repo.GetCollection();

            if(adminList != null)
            {
                grdcAdminData.ItemsSource = adminList;
            }
        }




        private async void MyFuncWithList()
        {
            try
            {
                m_client = new MongoClient();

                m_database = m_client.GetDatabase("MyDB");

                var collection = m_database.GetCollection<BsonDocument>("AdminData");
                var filter = new BsonDocument();
                var count = 0;
                List<BsonElement> adminData = new List<BsonElement>();
                using (var cursor = await collection.FindAsync(filter))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {

                            List<BsonElement> adminElement = document.ToList();

                            int ElementCount = adminElement.Count;

                            for (int i = 0; i < ElementCount; i++)
                            {
                                adminData.Add(adminElement[i]);
                            }

                            count++;
                        }
                    }

                    grdcAdminData.ItemsSource = adminData;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void bbAdd_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            AddDocs();
        }

        private void bbDelete_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            DeleteDoc();
        }

        private void bbRefresh_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            GetDocs();
        }

        private void grdvAdminData_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            UpdateDoc();
        }
    }
}