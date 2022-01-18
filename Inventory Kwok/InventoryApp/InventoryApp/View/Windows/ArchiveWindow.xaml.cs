using InventoryApp.Context;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.View.Windows
{
    /// <summary>
    /// Interaction logic for ArchiveWindow.xaml
    /// </summary>
    public partial class ArchiveWindow : Window
    {
        public ArchiveWindow()
        {
            InitializeComponent();
            ArhciveList.ItemsSource = AppData.db.ArhiveInventoryObject.ToList();
        }

        // Фильтрация по дате удаления
        private void selectedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ArhciveList.ItemsSource = AppData.db.ArhiveInventoryObject.Where(item => item.Date == selectedDate.SelectedDate).ToList();
        }

        // Экспорт в CSV файл
        private void buttonExportInCVS_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream file = new FileStream(Environment.CurrentDirectory + "\\archive.csv", FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(file))
                {
                    var archiveList = AppData.db.ArhiveInventoryObject.ToList();
                    writer.WriteLine("Наименование;Номер;Дата ввода;Срок;Тип;ПодТип;Документ;Состояние;Ответственный;Цена;Расположение;Дата удаления;");
                    foreach (var item in archiveList)
                    {
                        writer.WriteLine($"{item.Title};{item.InventoryNumber};{item.CommissioningDate};{item.LifeTime};{item.IDType};{item.IDSubType};{item.DocumentationPath};{item.IDCurrentStatus};{item.IDEmployee};{item.Amount};{item.IDInvoce};{item.Date};");
                    }
                }
            }
            MessageBox.Show("Экспорт в CVS прошло успешно!", "Отлично!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
