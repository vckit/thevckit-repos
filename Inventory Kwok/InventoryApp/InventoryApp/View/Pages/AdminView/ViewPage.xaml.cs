using InventoryApp.Context;
using InventoryApp.Model;
using InventoryApp.View.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Word = Microsoft.Office.Interop.Word;

namespace InventoryApp.View.Pages.AdminView
{
    /// <summary>
    /// Interaction logic for ViewPage.xaml
    /// </summary>
    /// 

    // Главное окно администратора
    public partial class ViewPage : Page
    {
        public ViewPage()
        {
            InitializeComponent();
        }

        // Выгрузка данных из Базы Данных
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataList.ItemsSource = AppData.db.InventoryObject.ToList();
        }

        // Добавление нового объекта
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActioInventoryPageView(new InventoryObject(), new CurrentStatus(), new Invoce()));
        }

        // Редактирование выбранного объекта
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedInventoryObject = (InventoryObject)DataList.SelectedItem;
            if (selectedInventoryObject != null)
            {
                var selectedCurrentStatus = AppData.db.CurrentStatus.FirstOrDefault(item => item.ID == selectedInventoryObject.IDCurrentStatus);
                var selectedInvoce = AppData.db.Invoce.FirstOrDefault(item => item.ID == selectedInventoryObject.IDInvoce);
                var selectedCabinetInventoryObject = AppData.db.CabinetInventoryObject.FirstOrDefault(item => item.IDInventoryObject == selectedInventoryObject.ID);
                NavigationService.Navigate(new ActioInventoryPageView(selectedInventoryObject, selectedCurrentStatus, selectedInvoce));
            }
        }

        // Удаление объекта из базы данных
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (InventoryObject)DataList.SelectedItem;
                if (selectedItem != null)
                {
                    // Проверяем, можем ли мы списать объект
                    if (selectedItem.CommissioningDate.AddYears(selectedItem.LifeTime) < DateTime.Today)
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить выбранный объект? Данные будут удалены безвозвратно", "Подтвердите удаление.", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                        {
                            AppData.db.InventoryObject.Remove(selectedItem);
                            AppData.db.SaveChanges();
                            Page_Loaded(null, null);
                            MessageBox.Show("Объект был успешно уделён.", "Удалено.", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                        throw new Exception("Списать нельзя, срок годности ещё не вышел!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Закрыть приложение
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Подтвердите действие", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        // Поиск данных
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataList.ItemsSource = AppData.db.InventoryObject.Where(item => item.Title.Contains(txbSearch.Text) ||
            item.LifeTime.ToString().Contains(txbSearch.Text) ||
            item.Employe.FIO.Contains(txbSearch.Text) ||
            item.Type.Title.Contains(txbSearch.Text) ||
            item.SubType.Title.Contains(txbSearch.Text) ||
            item.CurrentStatus.Status.Title.Contains(txbSearch.Text) ||
            item.Amount.ToString().Contains(txbSearch.Text) ||
            item.Invoce.Number.Contains(txbSearch.Text)).ToList();
        }

        // Распечатать ведомость инвентаризации
        private void buttonPrint_Click(object sender, RoutedEventArgs e)
        {
            var word = new Word.Application();
            try
            {
                var document = word.Documents.Add();
                var paragrah = word.ActiveDocument.Paragraphs.Add();
                var tableRange = paragrah.Range;
                var inventoryObjectInventoryObjectDetailsList = AppData.db.InventoryObjectInentoryObjectDetails.ToList();
                var table = document.Tables.Add(tableRange, inventoryObjectInventoryObjectDetailsList.Count, 15);
                table.Borders.Enable = 1;
                table.Cell(1, 1).Range.Text = "Наименование";
                table.Cell(1, 2).Range.Text = "Инвентарный номер";
                table.Cell(1, 3).Range.Text = "Дата ввода в эксплуатацию";
                table.Cell(1, 4).Range.Text = "Срок службы";
                table.Cell(1, 5).Range.Text = "Возможность списания";
                table.Cell(1, 6).Range.Text = "Тип";
                table.Cell(1, 7).Range.Text = "Подтип";
                table.Cell(1, 8).Range.Text = "Наименование)";
                table.Cell(1, 9).Range.Text = "Серийный номер";
                table.Cell(1, 10).Range.Text = "Документация";
                table.Cell(1, 11).Range.Text = "Состояние";
                table.Cell(1, 12).Range.Text = "Номер акта";
                table.Cell(1, 13).Range.Text = "Дата акта";
                table.Cell(1, 14).Range.Text = "Ответственный";
                table.Cell(1, 15).Range.Text = "Цена";

                int i = 2;
                foreach (var item in inventoryObjectInventoryObjectDetailsList)
                {
                    table.Cell(i, 1).Range.Text = item.InventoryObject.Title;
                    table.Cell(i, 2).Range.Text = item.InventoryObject.InventoryNumber;
                    table.Cell(i, 3).Range.Text = item.InventoryObject.CommissioningDate.ToLongTimeString();
                    table.Cell(i, 4).Range.Text = item.InventoryObject.LifeTime.ToString();
                    table.Cell(i, 5).Range.Text = "ДА";
                    table.Cell(i, 6).Range.Text = item.InventoryObject.Type.Title;
                    table.Cell(i, 7).Range.Text = item.InventoryObject.SubType.Title;
                    table.Cell(i, 8).Range.Text = item.InventoryObjectDetails.Title;
                    table.Cell(i, 9).Range.Text = item.InventoryObjectDetails.SeriaNumber;
                    table.Cell(i, 10).Range.Text = item.InventoryObject.DocumentationPath;
                    table.Cell(i, 11).Range.Text = item.InventoryObject.CurrentStatus.Status.Title;
                    table.Cell(i, 12).Range.Text = item.InventoryObject.CurrentStatus.NumberAct;
                    table.Cell(i, 13).Range.Text = item.InventoryObject.CurrentStatus.Date.ToString();
                    table.Cell(i, 14).Range.Text = item.InventoryObject.Employe.FIO;
                    table.Cell(i, 15).Range.Text = item.InventoryObject.Amount.ToString();
                    i++;
                }
                document.SaveAs2($"{Environment.CurrentDirectory}\\Ведомость инвентаризации.docx");
                document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                word.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
                MessageBox.Show($"Ведомость успешно сформирована, расположение: {Environment.CurrentDirectory}\\Ведомость инвентаризации.docx!", "Ведомость успешно сформирован.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " выдал исключение!", MessageBoxButton.OK, MessageBoxImage.Error);
                word.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
            }
        }

        // Установить кабинет инвентарю
        private async void buttonSetCabinet_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (InventoryObject)DataList.SelectedItem;
            if (selectedItem != null)
            {
                SetCabinetWindow set = new SetCabinetWindow(new CabinetInventoryObject(), selectedItem);
                await set.Dispatcher.InvokeAsync(() => set.ShowDialog());
            }
        }

        // Добавляем выбронному объекту комплектующие
        private void buttonAddInventoryObjectDetails_Click(object sender, RoutedEventArgs e)
        {
            var selectedInventoryObject = (InventoryObject)DataList.SelectedItem;
            if (selectedInventoryObject != null)
            {
                var selectedInventoryObjectInentoryObjectDetails = AppData.db.InventoryObjectInentoryObjectDetails.FirstOrDefault(item => item.IDInventoryObject == selectedInventoryObject.ID);
                if (selectedInventoryObjectInentoryObjectDetails != null)
                {
                    NavigationService.Navigate(new AddInventoryObjectDetailView(new InventoryObjectDetails(), selectedInventoryObject, selectedInventoryObjectInentoryObjectDetails));
                }
                else
                {
                    NavigationService.Navigate(new AddInventoryObjectDetailView(new InventoryObjectDetails(), selectedInventoryObject, new InventoryObjectInentoryObjectDetails()));
                }
            }

        }
        // Страница добавление нового пользователя
        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPageView());
        }
        // Страница добавления нового ответственного
        private void buttonEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeePageView());
        }
        // Страница добавления нового типа и подтипа
        private void buttonTypes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TypesPageView());
        }

        // Кликните по объекту два раза, программа проверит существует ли его документация по указанному пути, если да, то откроет его
        private void DataList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var selectedItem = (InventoryObject)DataList.SelectedItem;
                if (selectedItem.DocumentationPath != "")
                {
                    if (MessageBox.Show("Хотите открыть документацию?", "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (File.Exists(selectedItem.DocumentationPath))
                        {
                            Process.Start(selectedItem.DocumentationPath);
                        }
                    }
                    else
                        throw new Exception($"Путь {selectedItem.DocumentationPath} не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Страница просмотра истории перемещений объекта
        private void ViewHistoryObject(object sender, RoutedEventArgs e)
        {
            var selectedInventoryObject = (InventoryObject)DataList.SelectedItem;
            if(selectedInventoryObject != null)
                NavigationService.Navigate(new HistoryPageView(selectedInventoryObject));
        }
        // Открыть документацию
        private void OpenDocumentation(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (InventoryObject)DataList.SelectedItem;
                if (selectedItem.DocumentationPath != "")
                {
                    if (MessageBox.Show("Хотите открыть документацию?", "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (File.Exists(selectedItem.DocumentationPath))
                        {
                            Process.Start(selectedItem.DocumentationPath);
                        }
                    }
                    else
                        throw new Exception($"Путь {selectedItem.DocumentationPath} не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        // Обновить 
        private void buttonUpdateList_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(null, null);
        }
    }
}
