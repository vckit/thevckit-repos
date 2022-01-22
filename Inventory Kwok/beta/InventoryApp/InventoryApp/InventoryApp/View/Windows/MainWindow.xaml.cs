using System;
using System.Windows;
using InventoryApp.View.Pages;
using InventoryApp.View.Pages.AdminView;

namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Натягиваем страницу
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ViewPage());
        }

        // Вернуть состояние frame назад
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
            GC.Collect();
        }

        // Если frame не может вернуться, скрыть кнопку назад
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            buttonBack.Visibility = MainFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
