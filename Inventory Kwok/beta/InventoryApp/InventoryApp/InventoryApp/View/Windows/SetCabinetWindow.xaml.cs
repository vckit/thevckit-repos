using InventoryApp.Context;
using InventoryApp.Model;
using InventoryApp.View.Pages.AdminView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace InventoryApp.View.Windows
{
    /// <summary>
    /// Interaction logic for SetCabinetWindow.xaml
    /// </summary>
    public partial class SetCabinetWindow : Window
    {
        //public CabinetInventoryObject CabinetInventoryObject { get; set; }
        //public InventoryObject InventoryObject { get; set; }
        //public Cabinet Cabinet { get; set; }
        //public List<Cabinet> Cabinets { get; set; }
        //public List<Employe> Employes { get; set; }
        public SetCabinetWindow(CabinetInventoryObject cabinetInventoryObject, InventoryObject inventoryObject)
        {
            InitializeComponent();
            MainFrame.Navigate(new SetCabinetPageView(cabinetInventoryObject, inventoryObject));
            //CabinetInventoryObject = cabinetInventoryObject;
            //InventoryObject = inventoryObject;
            //Cabinets = AppData.db.Cabinet.ToList();
            //Employes = AppData.db.Employe.ToList();
            //this.DataContext = this;
        }

        //private void buttonSave_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (cmbFIO.Text == "" && cmbCabinet.Text == "")
        //            throw new Exception("ВНИМАНИЕ! ЗАПОЛНИТЕ ПОЛЯ!");
        //        if (CabinetInventoryObject.ID == 0)
        //        {
        //            CabinetInventoryObject.IDInventoryObject = InventoryObject.ID;
        //            AppData.db.CabinetInventoryObject.Add(CabinetInventoryObject);
        //        }
        //        InventoryObject.Employe.FIO = cmbFIO.Text;
        //        AppData.db.SaveChanges();
        //        MessageBox.Show("Данные успешно добавлены в базу данных", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Упс... что-то пошло не так :(", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //}

        //private void buttonAddCabinet_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
