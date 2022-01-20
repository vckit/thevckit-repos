using InventoryApp.Context;
using InventoryApp.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System;

namespace InventoryApp.View.Pages.AdminView
{
    /// <summary>
    /// Interaction logic for AddInventoryObjectDetailView.xaml
    /// </summary>
    public partial class AddInventoryObjectDetailView : Page
    {
        public InventoryObjectInentoryObjectDetails selectedItem { get; set; }
        public InventoryObjectDetails InventoryObjectDetails { get; set; }
        public InventoryObjectInentoryObjectDetails InventoryObjectInentoryObjectDetails { get; set; }
        public InventoryObject InventoryObject { get; set; }
        public AddInventoryObjectDetailView(InventoryObjectDetails inventoryObjectDetails, InventoryObject inventoryObject, InventoryObjectInentoryObjectDetails inventoryObjectInentoryObjectDetails)
        {
            InitializeComponent();
            InventoryObjectDetails = inventoryObjectDetails;
            InventoryObject = inventoryObject;
            InventoryObjectInentoryObjectDetails = inventoryObjectInentoryObjectDetails;
            if (InventoryObject.ID != 0)
                txbTitleInventoryObject.Text = AppData.db.InventoryObject.FirstOrDefault(item => item.ID == InventoryObject.ID).Title;
            this.DataContext = this;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbTitle.Text == "" && txbSeraiNumber.Text == "")
                    throw new Exception("Внимание! Заполните поля!");
                if (selectedItem == null)
                {
                    if (AppData.db.InventoryObjectInentoryObjectDetails.Count(item => item.InventoryObjectDetails.SeriaNumber == txbSeraiNumber.Text) > 0)
                    {
                        throw new Exception($"Серийный номер {txbSeraiNumber.Text} уже существуюет!");
                    }
                    else
                    {
                        InventoryObjectDetails.Title = txbTitle.Text;
                        InventoryObjectDetails.SeriaNumber = txbSeraiNumber.Text;
                        AppData.db.InventoryObjectDetails.Add(InventoryObjectDetails);
                        InventoryObjectInentoryObjectDetails.IDInventoryObject = InventoryObject.ID;
                        InventoryObjectInentoryObjectDetails.IDInventoryObjectDetails = InventoryObjectDetails.ID;
                        AppData.db.InventoryObjectInentoryObjectDetails.Add(InventoryObjectInentoryObjectDetails);
                    }
                }
                else
                {
                    selectedItem.InventoryObjectDetails.Title = txbTitle.Text;
                    selectedItem.InventoryObjectDetails.SeriaNumber = txbSeraiNumber.Text;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Данные успешно сохранены в базу данных.", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                Page_Loaded(null, null);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс... что-то пошло не так :(", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (InventoryObjectInentoryObjectDetails == null)
            {
                txbStatus.Text = "Комплектующих нет!";
            }
            else
            {
                ListInventoryObjectDetails.ItemsSource = AppData.db.InventoryObjectInentoryObjectDetails.Where(item => item.InventoryObject.ID == InventoryObjectInentoryObjectDetails.IDInventoryObject).ToList();
            }
        }


        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = (InventoryObjectInentoryObjectDetails)ListInventoryObjectDetails.SelectedItem;
            if (selectedItem != null)
            {
                AppData.db.InventoryObjectInentoryObjectDetails.Remove(selectedItem);
                AppData.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Удаление прошло успешно", "Данные удалены!", MessageBoxButton.OK, MessageBoxImage.Information);
                Clear();

            }
        }
        private void buttonSelected_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = (InventoryObjectInentoryObjectDetails)ListInventoryObjectDetails.SelectedItem;
            if (selectedItem != null)
            {
                txbSeraiNumber.Text = selectedItem.InventoryObjectDetails.SeriaNumber;
                txbTitle.Text = selectedItem.InventoryObjectDetails.Title;
            }
        }

        public void Clear()
        {
            txbSeraiNumber.Text = "";
            txbTitle.Text = "";
            selectedItem = null;
            ListInventoryObjectDetails.SelectedItem = null;
            GC.Collect();
        }
    }
}
