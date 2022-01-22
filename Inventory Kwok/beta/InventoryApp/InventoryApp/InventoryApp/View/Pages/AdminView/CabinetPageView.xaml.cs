using InventoryApp.Context;
using InventoryApp.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.View.Pages.AdminView
{
    /// <summary>
    /// Interaction logic for CabinetPageView.xaml
    /// </summary>
    public partial class CabinetPageView : Page
    {
        public Cabinet Cabinet { get; set; }
        public Cabinet SelectedCabinet { get; set; }
        public CabinetPageView()
        {
            InitializeComponent();
        }

        private void buttonSelected_Click(object sender, RoutedEventArgs e)
        {
            SelectedCabinet = (Cabinet)ListCabinet.SelectedItem;
            if(SelectedCabinet != null)
            {
                txbNumber.Text = SelectedCabinet.Number;
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            SelectedCabinet = (Cabinet)ListCabinet.SelectedItem;
            if(SelectedCabinet != null)
            {
                AppData.db.Cabinet.Remove(SelectedCabinet);
                AppData.db.SaveChanges();
                MessageBox.Show("Данные были успешно удалены из базы данных.", "Удаление прошло успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                Page_Loaded(null, null);
                Clear();
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedCabinet == null)
            {
                Cabinet = new Cabinet();
                Cabinet.Number = txbNumber.Text;
                AppData.db.Cabinet.Add(Cabinet);
            }
            else
            {
                SelectedCabinet.Number = txbNumber.Text;
            }
            AppData.db.SaveChanges();
            MessageBox.Show("Данные успешно добавлены в базу данных.", "Сохранение прошло успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            Page_Loaded(null, null);
            Clear();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListCabinet.ItemsSource = AppData.db.Cabinet.ToList();
        }

        public void Clear()
        {
            txbNumber.Text = "";
            ListCabinet.SelectedItem = null;
            SelectedCabinet = null;
            GC.Collect();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
