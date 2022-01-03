using CRUDListView.Views.Pages;
using System;
using System.Windows;

namespace CRUDListView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new DataViewPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            BackBtn.Visibility = MainFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
            GC.Collect();
        }
    }
}
