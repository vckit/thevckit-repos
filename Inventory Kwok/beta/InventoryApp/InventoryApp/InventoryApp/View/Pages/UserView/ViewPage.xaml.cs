using InventoryApp.Context;
using InventoryApp.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.View.Pages.UserView
{
    /// <summary>
    /// Interaction logic for ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        public ViewPage()
        {
            InitializeComponent();
        }

        // Поиск данных
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataList.ItemsSource = AppData.db.InventoryObject.Where(item => item.Title.Contains(txbSearch.Text) ||
            item.Employe.FIO.Contains(txbSearch.Text) ||
            item.InventoryNumber.Contains(txbSearch.Text) ||
            item.Type.Title.Contains(txbSearch.Text) ||
            item.SubType.Title.Contains(txbSearch.Text) ||
            item.CurrentStatus.Status.Title.Contains(txbSearch.Text)).ToList();
        }

        // Выйти
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Выгрузка данных
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataList.ItemsSource = AppData.db.InventoryObject.ToList();
        }

        private void buttonListComplection_Click(object sender, RoutedEventArgs e)
        {
            var selectedInventoryObject = (InventoryObject)DataList.SelectedItem;
            if(selectedInventoryObject != null)
            {
                NavigationService.Navigate(new InventoryObjectPageView(selectedInventoryObject.Title, selectedInventoryObject.ID));
            }
        }

        private void ViewHistoryObject(object sender, RoutedEventArgs e)
        {
            var selectedInventoryObject = (InventoryObject)DataList.SelectedItem;
            if (selectedInventoryObject != null)
                NavigationService.Navigate(new HistoryPageView(selectedInventoryObject));
        }

        private void OpenDocumentation(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (InventoryObject)DataList.SelectedItem;
                if (selectedItem.DocumentationPath != "")
                {
                    if (MessageBox.Show("Хотите открыть документацию?", "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (File.Exists(selectedItem.DocumentationPath))
                        {
                            Process.Start(selectedItem.DocumentationPath);
                        }
                    }
                    else
                        throw new Exception($"Путь {selectedItem.DocumentationPath} не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс... что-то пошло не так :(", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
