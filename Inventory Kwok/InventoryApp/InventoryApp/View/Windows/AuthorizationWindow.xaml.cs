using InventoryApp.Context;
using System.Linq;
using System.Windows;

namespace InventoryApp.View.Windows
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void PasswordTxb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txbPassword.Text = PasswordTxb.Password;
        }

        // Показать пароль
        private void buttonShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordVisible.Visibility == Visibility.Visible)
            {
                PasswordVisible.Visibility = Visibility.Collapsed;
                PasswordCollabsed.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordVisible.Visibility = Visibility.Visible;
                PasswordCollabsed.Visibility = Visibility.Collapsed;
            }
        }

        // Авторизация
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = AppData.db.User.FirstOrDefault(item => item.Username == txbUsername.Text && item.Password == PasswordTxb.Password);
            if (currentUser != null)
            {
                switch (currentUser.IDRole)
                {
                    case "a":
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        break;
                    case "u":
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("ПОЛЬЗОВАТЕЛЬ НЕ НАЙДЕН.", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Закрыть приложение
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
