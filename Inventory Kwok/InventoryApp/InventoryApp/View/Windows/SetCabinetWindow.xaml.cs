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
using InventoryApp.Model;
using InventoryApp.Context;


namespace InventoryApp.View.Windows
{
    /// <summary>
    /// Interaction logic for SetCabinetWindow.xaml
    /// </summary>
    public partial class SetCabinetWindow : Window
    {
        public CabinetInventoryObject CabinetInventoryObject { get; set; }
        public InventoryObject InventoryObject { get; set; }
        public List<Cabinet> Cabinets { get; set; }
        public SetCabinetWindow(CabinetInventoryObject cabinetInventoryObject, InventoryObject inventoryObject)
        {
            InitializeComponent();
            CabinetInventoryObject = cabinetInventoryObject;
            InventoryObject = inventoryObject;
            Cabinets = AppData.db.Cabinet.ToList();
            this.DataContext = this;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if(CabinetInventoryObject.ID == 0)
            {
                CabinetInventoryObject.IDInventoryObject = InventoryObject.ID;
                AppData.db.CabinetInventoryObject.Add(CabinetInventoryObject);
            }
            AppData.db.SaveChanges();
            MessageBox.Show("Успех");
        }
    }
}
