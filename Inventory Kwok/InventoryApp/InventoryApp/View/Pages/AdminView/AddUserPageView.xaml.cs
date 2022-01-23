using InventoryApp.Context;
using InventoryApp.Model;
using System.Linq;
using System.Windows;
using System;
using System.Windows.Controls;

namespace InventoryApp.View.Pages.AdminView
{
    /// <summary>
    /// Interaction logic for AddUserPageView.xaml
    /// </summary>
    public partial class AddUserPageView : Page
    {
        // Объявляем объекты
        public User SelectedUser { get; set; }
        public User User { get; set; }
        public int Role { get; set; }

        public AddUserPageView()
        {
            InitializeComponent();
        }

        // Добавляем нового пользователя
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbUsername.Text == "" && txbPassword.Text == "")
                    throw new Exception("Внимание! Заполните все поля!");
                if (SelectedUser == null)
                {
                    if (AppData.db.User.Count(item => item.Username == txbUsername.Text) > 0)
                    {
                        throw new Exception($"Пользователь с именем пользователем {txbUsername.Text} уже существует!");
                    }
                    else
                    {
                        User = new User();
                        User.Username = txbUsername.Text;
                        User.Password = txbPassword.Text;
                        User.Role = Role;
                        AppData.db.User.Add(User);
                    }
                }
                else
                {
                    SelectedUser.Username = txbUsername.Text;
                    SelectedUser.Password = txbPassword.Text;
                    SelectedUser.Role = Role;
                }
                AppData.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Данные успешно добавлены в базу данных!", "Сохранено", MessageBoxButton.OK, MessageBoxImage.Information);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                Clear();
            }
        }

        // Выбираем роль пользователя
        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbRole.SelectedIndex == 0) Role = 1;
            else Role = 2;
        }
        // Удаляем выбранного пользователя из базы данных
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            SelectedUser = (User)ListUser.SelectedItem;
            if (SelectedUser != null)
            {
                AppData.db.User.Remove(SelectedUser);
                AppData.db.SaveChanges();
                MessageBox.Show("Данные успешно удалены!", "Удалено.", MessageBoxButton.OK, MessageBoxImage.Information);
                Page_Loaded(null, null);
                Clear();
            }
        }

        private void buttonSelected_Click(object sender, RoutedEventArgs e)
        {
            SelectedUser = (User)ListUser.SelectedItem;
            if (SelectedUser != null)
            {
                txbUsername.Text = SelectedUser.Username;
                txbPassword.Text = SelectedUser.Password;
                cmbRole.SelectedIndex = SelectedUser.Role == 1 ? 0 : 1;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListUser.ItemsSource = AppData.db.User.ToList();
        }

        private void buttonCancelSelected_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            ListUser.SelectedItem = null;
            SelectedUser = null;
            GC.Collect();
            txbUsername.Text = "";
            txbPassword.Text = "";
            cmbRole.Text = "";
        }
    }
}
