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
using HRIS.Controller;
using HRIS.Database;
using HRIS.Entities;

namespace HRIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string STAFF_KEY = "viewableStaff";
        private StaffController staffController;


        public MainWindow()
        {
            InitializeComponent();

            staffController = (StaffController)(Application.Current.FindResource(STAFF_KEY) as ObjectDataProvider).ObjectInstance;
        }

      
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                staffDetails.DataContext = DBAdapter.GetFullStaffDetails((Staff)e.AddedItems[0]);
            }
        }
    }
}
