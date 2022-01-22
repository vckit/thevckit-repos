using InventoryApp.Context;
using System.Linq;
using System.Windows.Controls;

namespace InventoryApp.View.Pages.UserView
{
    /// <summary>
    /// Interaction logic for InventoryObjectPageView.xaml
    /// </summary>
    public partial class InventoryObjectPageView : Page
    {
        public InventoryObjectPageView(string numberInventoryObject, int idInventoryObject)
        {
            InitializeComponent();
            txbObjectNumber.Text = numberInventoryObject;
            ListInventoryObjectDetails.ItemsSource = AppData.db.InventoryObjectInentoryObjectDetails.Where(item => item.IDInventoryObject == idInventoryObject).ToList();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListInventoryObjectDetails.ItemsSource = AppData.db.InventoryObjectInentoryObjectDetails.Where(item => item.InventoryObjectDetails.Title.Contains(txbSearch.Text) ||
            item.InventoryObjectDetails.SeriaNumber.Contains(txbSearch.Text)).ToList();
        }
    }
}
