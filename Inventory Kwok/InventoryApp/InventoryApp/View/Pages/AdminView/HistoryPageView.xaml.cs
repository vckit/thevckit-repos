using InventoryApp.Context;
using InventoryApp.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.View.Pages.AdminView
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
