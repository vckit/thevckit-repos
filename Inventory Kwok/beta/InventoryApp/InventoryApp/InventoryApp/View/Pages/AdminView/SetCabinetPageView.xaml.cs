using InventoryApp.Context;
using InventoryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace InventoryApp.View.Pages.AdminView
{
    /// <summary>
    /// Interaction logic for SetCabinetPageView.xaml
    /// </summary>
    public partial class SetCabinetPageView : Page
    {
        public History History { get; set; }
        public CabinetInventoryObject CabinetInventoryObject { get; set; }
        public InventoryObject InventoryObject { get; set; }
        public List<Cabinet> Cabinets { get; set; }
        public List<Employe> Employes { get; set; }
        public SetCabinetPageView(CabinetInventoryObject cabinetInventoryObject, InventoryObject inventoryObject)
        {
            InitializeComponent();
            CabinetInventoryObject = cabinetInventoryObject;
            InventoryObject = inventoryObject;
            Cabinets = AppData.db.Cabinet.ToList();
            Employes = AppData.db.Employe.ToList();
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbFIO.Text == "" && cmbCabinet.Text == "")
                    throw new Exception("ВНИМАНИЕ! ЗАПОЛНИТЕ ПОЛЯ!");
                if (CabinetInventoryObject.ID == 0)
                {
                    CabinetInventoryObject.IDInventoryObject = InventoryObject.ID;
                    AppData.db.CabinetInventoryObject.Add(CabinetInventoryObject);
                }
                History = new History();
                History.FIO = cmbFIO.Text;
                History.CabinetNumber = cmbCabinet.Text;
                History.IDInventoryObject = InventoryObject.ID;
                History.Date = DateTime.Now;
                AppData.db.History.Add(History);

                InventoryObject.Employe.FIO = cmbFIO.Text;
                AppData.db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены в базу данных", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void buttonAddCabinet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CabinetPageView());
        }
    }
}
