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
using System.Windows.Shapes;
using MongoDB.Bson;

namespace MongoSample
{
    /// <summary>
    /// Interaction logic for AdminAddDialog.xaml
    /// </summary>
    public partial class AdminAddDialog : Window
    {
        public AdminAddDialog()
        {
            InitializeComponent();
        }

        public AdminData Entity { get; set; }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminData adminData = new AdminData();

            adminData._id = ObjectId.GenerateNewId();

            adminData.Name = teName.Text;

            adminData.SlNo = Convert.ToInt32(tcSlno.Text);

            adminData.Age = Convert.ToInt32(teAge.Text);

            adminData.Address = teAddress.Text;

            Entity = adminData;

            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
