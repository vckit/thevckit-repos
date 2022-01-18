using InventoryApp.View.Pages.UserView;
using System;
using System.Windows;

namespace InventoryApp.View.Windows
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        /// <summary>
        /// Окно пользователя
        /// </summary>
        public UserWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ViewPage());
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MainFrsame_ContentRendered(object sender, EventArgs e)
        {
            buttonBack.Visibility = MainFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
