using CRUDListView.Context;
using CRUDListView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CRUDListView.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataViewPage.xaml
    /// </summary>
    public partial class DataViewPage : Page
    {
        public List<UserPersonal> UserPersonals { get; set; }
        public DataViewPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserPersonals = AppData.db.UserPersonal.ToList();
            listViewData.ItemsSource = UserPersonals;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActionViewPage(new UserPersonal()));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (UserPersonal)listViewData.SelectedItem;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new ActionViewPage(selectedItem));
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (UserPersonal)listViewData.SelectedItem;
                if(selectedItem != null)
                {
                    AppData.db.UserPersonal.Remove(selectedItem);
                    AppData.db.SaveChanges();
                    MessageBox.Show("Data deleted.", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    Page_Loaded(null, null);
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
           listViewData.ItemsSource = UserPersonals.Where(item => item.Email.Contains(SearchTxb.Text)).ToList();
        }
    }
}
