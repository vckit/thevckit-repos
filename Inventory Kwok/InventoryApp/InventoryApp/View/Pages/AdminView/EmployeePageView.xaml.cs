using InventoryApp.Context;
using InventoryApp.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.View.Pages.AdminView
{
    /// <summary>
    /// Interaction logic for EmployeePageView.xaml
    /// </summary>
    public partial class EmployeePageView : Page
    {
        public Employe Employe { get; set; }
        public Employe SelectedEmployee { get; set; }
        public EmployeePageView()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (txbFIO.Text == "" || txbFIO.Text == "")
                throw new Exception("ВНИМАНИЕ! ЗАПОЛНИТЕ ПОЛЯ");
            if (SelectedEmployee == null)
            {
                Employe = new Employe();
                Employe.FIO = txbFIO.Text;
                Employe.Position = txbPosition.Text;
                AppData.db.Employe.Add(Employe);
            }
            else
            {
                SelectedEmployee.FIO = txbFIO.Text;
                SelectedEmployee.Position = txbPosition.Text;
            }
            AppData.db.SaveChanges();
            Page_Loaded(null, null);
            MessageBox.Show("Данные успешно сохранены!", "Сохранено", MessageBoxButton.OK, MessageBoxImage.Information);
            Clear();


        }

        private void buttonSelected_Click(object sender, RoutedEventArgs e)
        {
            SelectedEmployee = (Employe)ListEmployee.SelectedItem;
            if (SelectedEmployee != null)
            {
                txbFIO.Text = SelectedEmployee.FIO;
                txbPosition.Text = SelectedEmployee.Position;
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            SelectedEmployee = (Employe)ListEmployee.SelectedItem;
            if (SelectedEmployee != null)
            {
                AppData.db.Employe.Remove(SelectedEmployee);
                AppData.db.SaveChanges();
                MessageBox.Show("Данные успешно удалены!", "Удалено.", MessageBoxButton.OK, MessageBoxImage.Information);
                Page_Loaded(null, null);
                Clear();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListEmployee.ItemsSource = AppData.db.Employe.ToList();
        }
        public void Clear()
        {
            ListEmployee.SelectedItem = null;
            SelectedEmployee = null;
            GC.Collect();
            txbFIO.Text = "";
            txbPosition.Text = "";
        }
    }
}
