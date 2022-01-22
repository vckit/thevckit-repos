using InventoryApp.Model;
using InventoryApp.View.Pages.AdminView;
using System.Windows;

namespace InventoryApp.View.Windows
{
    /// <summary>
    /// Interaction logic for SetCabinetWindow.xaml
    /// </summary>
    public partial class SetCabinetWindow : Window
    {
        public SetCabinetWindow(CabinetInventoryObject cabinetInventoryObject, InventoryObject inventoryObject)
        {
            InitializeComponent();
            MainFrame.Navigate(new SetCabinetPageView(cabinetInventoryObject, inventoryObject));
        }
    }
}
