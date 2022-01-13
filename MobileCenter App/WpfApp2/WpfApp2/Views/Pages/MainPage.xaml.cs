using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp2.Context;
using WpfApp2.Model;

namespace WpfApp2.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<SimATCAbonent> dataList { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataList = AppData.db.SimATCAbonent.ToList();
            ListData.ItemsSource = dataList;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActionPage(new ATC(), new Abonent(), new Sim(), new SimATCAbonent()));
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItemSimATCAbonent = ListData.SelectedItem as SimATCAbonent;
                if (selectedItemSimATCAbonent != null)
                {
                    if (MessageBox.Show("ДАННЫЕ БУДУТ УДАЛЕНЫ ИЗ БАЗЫ ДАННЫХ БЕЗ ВОЗМОЖНОСТИ ВОССТАНОВИТЬ, ВЫ ДЕЙТСТВИТЕЛЬНО ХОТИТЕ УДАЛИТЬ ДАННЫЕ?",
                        "ПОДТВЕРДИТЕ УДАЛЕНИЕ!", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        AppData.db.SimATCAbonent.Remove(selectedItemSimATCAbonent);
                        AppData.db.SaveChanges();
                        MessageBox.Show("ДАННЫЕ БЫЛИ УСПЕШНО УДАЛЕНЫ ИЗ БАЗЫ ДАННЫХ", "УДАЛЕНО", MessageBoxButton.OK, MessageBoxImage.Information);
                        Page_Loaded(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так :(. Текст сообщения: '{ex.Message.ToLower()}'", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItemSimATCAbonent = (SimATCAbonent)ListData.SelectedItem;
                if (selectedItemSimATCAbonent != null)
                {
                    var selectedItemSim = AppData.db.Sim.FirstOrDefault(item => item.ID == selectedItemSimATCAbonent.IDSim);
                    var selectedItemAbonent = AppData.db.Abonent.FirstOrDefault(item => item.ID == selectedItemSimATCAbonent.IDAbonent);
                    var selectedItemATC = AppData.db.ATC.FirstOrDefault(item => item.Code == selectedItemSimATCAbonent.IDATC);
                    NavigationService.Navigate(new ActionPage(selectedItemATC, selectedItemAbonent, selectedItemSim, selectedItemSimATCAbonent));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так :(. Текст сообщения: '{ex.Message.ToLower()}'", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonUpdateData_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(null, null);
        }
    }
}
