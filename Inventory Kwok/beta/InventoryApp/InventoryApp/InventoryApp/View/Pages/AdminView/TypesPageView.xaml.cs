using InventoryApp.Context;
using InventoryApp.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.View.Pages.AdminView
{
    /// <summary>
    /// Interaction logic for TypesPageView.xaml
    /// </summary>
    public partial class TypesPageView : Page
    {
        public Model.Type SelectedType { get; set; }
        public Model.Type Type { get; set; }
        public SubType SelectedSubType { get; set; }
        public SubType SubType { get; set; }
        public TypesPageView()
        {
            InitializeComponent();
            cmbType.ItemsSource = AppData.db.Type.Select(item => item.Title).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListType.ItemsSource = AppData.db.Type.ToList();
            ListSubType.ItemsSource = AppData.db.SubType.ToList();
            cmbType.ItemsSource = AppData.db.Type.Select(item => item.Title).ToList();
        }

        private void buttonSaveType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbType.Text == "")
                    throw new Exception("ВНИМЕНИЕ! ЗАПОЛНИТЕ ПОЛЕ ТИП");
                if (SelectedType == null)
                {
                    Type = new Model.Type();
                    Type.Title = txbType.Text;
                    AppData.db.Type.Add(Type);
                }
                else
                {
                    SelectedType.Title = txbType.Text;
                }
                AppData.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Данные успешно добавлены в базу данных!", "Сохранено", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                ClearType();
            }
        }

        private void buttonSaveSubType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbSubType.Text == "" && cmbType.Text == "")
                    throw new Exception("ВНИМЕНИЕ! ЗАПОЛНИТЕ ПОЛЕ ТИП");
                if (SelectedSubType == null)
                {
                    SubType = new SubType();
                    SubType.Title = txbSubType.Text;
                    SubType.IDType = AppData.db.Type.FirstOrDefault(item => item.Title == cmbType.Text).ID;
                    AppData.db.SubType.Add(SubType);
                }
                else
                {
                    SelectedSubType.Title = txbSubType.Text;
                    SelectedSubType.IDType = AppData.db.Type.FirstOrDefault(item => item.Title == cmbType.Text).ID;
                }
                AppData.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Данные успешно добавлены в базу данных!", "Сохранено", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearSubType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                ClearSubType();
            }
        }

        private void buttonDeleteType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AppData.db.InventoryObject.FirstOrDefault(item => item.IDType == SelectedType.ID) != null) throw new Exception("Нельзя удалить тип, так как существует объект принадлежащий этому типу.");
                SelectedType = (Model.Type)ListType.SelectedItem;
                if (SelectedType != null)
                {
                    AppData.db.Type.Remove(SelectedType);
                    AppData.db.SaveChanges();
                    MessageBox.Show("Данные успешно удалены из базу данных!", "Удалено", MessageBoxButton.OK, MessageBoxImage.Information);
                    Page_Loaded(null, null);
                    ClearType();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void buttonSelectedType_Click(object sender, RoutedEventArgs e)
        {
            SelectedType = (Model.Type)ListType.SelectedItem;
            if (SelectedType != null)
            {
                txbType.Text = SelectedType.Title;
            }
        }

        private void buttonDeleteSubType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AppData.db.InventoryObject.FirstOrDefault(item => item.IDSubType == SelectedType.ID) != null) throw new Exception("Нельзя удалить подтип, так как существует объект принадлежащий этому подтипу.");
                SelectedSubType = (SubType)ListSubType.SelectedItem;
                if (SelectedSubType != null)
                {
                    AppData.db.SubType.Remove(SelectedSubType);
                    AppData.db.SaveChanges();
                    MessageBox.Show("Данные успешно удалены из базу данных!", "Удалено", MessageBoxButton.OK, MessageBoxImage.Information);
                    Page_Loaded(null, null);
                    ClearSubType();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void buttonSelectedSubType_Click(object sender, RoutedEventArgs e)
        {
            SelectedSubType = (SubType)ListSubType.SelectedItem;
            if (SelectedSubType != null)
            {
                txbSubType.Text = SelectedSubType.Title;
                cmbType.Text = AppData.db.Type.FirstOrDefault(item => item.Title == SelectedSubType.Type.Title).Title;
            }
        }
        public void ClearType()
        {
            txbType.Text = "";
            ListType.SelectedItem = null;
            SelectedType = null;
            GC.Collect();
        }

        public void ClearSubType()
        {
            txbSubType.Text = "";
            cmbType.Text = "";
            ListSubType.SelectedItem = null;
            SelectedSubType = null;
            GC.Collect();
        }
    }
}
