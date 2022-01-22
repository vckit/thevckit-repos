using InventoryApp.Context;
using InventoryApp.Model;
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

namespace InventoryApp.View.Pages.UserView
{
    /// <summary>
    /// Interaction logic for HistoryPageView.xaml
    /// </summary>
    public partial class HistoryPageView : Page
    {
        public InventoryObject InventoryObject { get; set; }
        public HistoryPageView(InventoryObject inventoryObject)
        {
            InitializeComponent();
            InventoryObject = inventoryObject;
            txbNumberInventoryObject.Text = "Инвент. номер: " + inventoryObject.InventoryNumber;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var collection = AppData.db.History.Where(item => item.IDInventoryObject == InventoryObject.ID).ToList();
            if (collection.Any())
            {
                ListHitoryObject.ItemsSource = collection;
            }
            else
            {
                NonHistory.Visibility = Visibility.Visible;
            }
        }
    }
}
