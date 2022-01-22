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
                switch (currentUser.Role)
                {
                    case 1:
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                        break;
                    case 2:
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        this.Close();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Закрыть приложение
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
