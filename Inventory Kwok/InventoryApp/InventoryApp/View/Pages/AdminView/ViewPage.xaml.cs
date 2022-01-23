using InventoryApp.Context;
using InventoryApp.Model;
using InventoryApp.View.Windows;
using System;
using System.Collections.Generic;
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
    public partial class ViewPage : System.Windows.Controls.Page
    {
        public ViewPage()
        {
            InitializeComponent();
        }

        // Выгрузка данных из Базы Данных
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Search();
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
                System.Windows.Application.Current.Shutdown();
            }
        }

        // Поиск данных
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search(cmbStatus.Text, txbSearch.Text);
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
                var table = document.Tables.Add(tableRange, inventoryObjectInventoryObjectDetailsList.Count, 16);
                table.Range.Font.Size = 10;
                table.Borders.Enable = 1;
                table.Title = "Ведомость инвентаризации";
                table.Cell(1, 1).Range.Text = "Наименование";
                table.Cell(1, 2).Range.Text = "Инвентарный номер";
                table.Cell(1, 3).Range.Text = "Дата ввода в эксплуатацию";
                table.Cell(1, 4).Range.Text = "Срок службы";
                table.Cell(1, 5).Range.Text = "Возможность списания";
                table.Cell(1, 6).Range.Text = "Тип";
                table.Cell(1, 7).Range.Text = "Подтип";
                table.Cell(1, 8).Range.Text = "Комплектующие";
                table.Cell(1, 9).Range.Text = "";
                table.Cell(1, 10).Range.Text = "";
                table.Cell(1, 11).Range.Text = "Документация";
                table.Cell(1, 12).Range.Text = "Состояние";
                table.Cell(1, 13).Range.Text = "Номер акта";
                table.Cell(1, 14).Range.Text = "Дата акта";
                table.Cell(1, 15).Range.Text = "Ответственный";
                table.Cell(1, 16).Range.Text = "Цена";

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
                    table.Cell(i, 8).Range.Text = item.InventoryObjectDetails.ID.ToString();
                    table.Cell(i, 9).Range.Text = item.InventoryObjectDetails.Title;
                    table.Cell(i, 10).Range.Text = item.InventoryObjectDetails.SeriaNumber;
                    table.Rows[1].Cells[8].Merge(table.Rows[1].Cells[9]);
                    table.Cell(i, 11).Range.Text = item.InventoryObject.DocumentationPath;
                    table.Cell(i, 12).Range.Text = item.InventoryObject.CurrentStatus.Status.Title;
                    table.Cell(i, 13).Range.Text = item.InventoryObject.CurrentStatus.NumberAct;
                    table.Cell(i, 14).Range.Text = item.InventoryObject.CurrentStatus.Date.ToString();
                    table.Cell(i, 15).Range.Text = item.InventoryObject.Employe.FIO;
                    table.Cell(i, 16).Range.Text = item.InventoryObject.Amount.ToString();
                    i++;
                }
                document.SaveAs2($"{Environment.CurrentDirectory}\\Ведомость инвентаризации.docx");
                document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                word.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
                MessageBox.Show($"Ведомость успешно сформирована, расположение: {Environment.CurrentDirectory}\\Ведомость инвентаризации.docx!", "Ведомость успешно сформирован.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (selectedInventoryObject != null)
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
        // Метод подсчёта объектов, которых можно списть
        private List<InventoryObject> CheckDateObject(List<InventoryObject> collection)
        {
            List<InventoryObject> list = new List<InventoryObject>();
            foreach (InventoryObject item in collection)
            {
                if (item.CommissioningDate.AddYears(item.LifeTime) < DateTime.Today) list.Add(item);
            }
            if (list.Count > 0) return list; else return null;
        }
        // Событие при котором происходит выводе объектов, которых можно списать
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckDateObject(AppData.db.InventoryObject.ToList()) != null)
            {
                DataList.ItemsSource = CheckDateObject(AppData.db.InventoryObject.ToList());
            }
            else
            {
                MessageBox.Show("Объектов, у которых срок годности истек - НЕТ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                checkDate.IsChecked = false;
            }
        }
        // Если убрать галочку, выводим всё объекты
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Page_Loaded(null, null);
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search((cmbStatus.SelectedItem as ComboBoxItem).Content.ToString(), txbSearch.Text);
        }
        // Метод поиска и сортировки
        private void Search(string status = "", string search = "")
        {
            var inventoryObjects = AppData.db.InventoryObject.ToList();
            if (!string.IsNullOrEmpty(status) && !string.IsNullOrEmpty(status))
            {
                if (status == "Рабочее")
                {
                    inventoryObjects = inventoryObjects.Where(item => item.CurrentStatus.Status.Title == "Рабочее").ToList();
                }
                if (status == "На ремонте")
                {
                    inventoryObjects = inventoryObjects.Where(item => item.CurrentStatus.Status.Title == "На ремонте").ToList();
                }
                if (status == "Списано")
                {
                    inventoryObjects = inventoryObjects.Where(item => item.CurrentStatus.Status.Title == "Списано").ToList();
                }
                if (status == "Подразделение")
                {
                    inventoryObjects = inventoryObjects.Where(item => item.CurrentStatus.Status.Title == "Подразделение").ToList();
                }
                if (status == "Все")
                {
                    inventoryObjects = inventoryObjects.ToList();
                }
            }
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(search))
            {
                inventoryObjects = inventoryObjects.Where(item => item.Title.Contains(search) ||
                item.LifeTime.ToString().Contains(search) ||
                item.Employe.FIO.Contains(search) ||
                item.Type.Title.Contains(search) ||
                item.SubType.Title.Contains(search) ||
                item.CurrentStatus.Status.Title.Contains(search) ||
                item.Amount.ToString().Contains(search) ||
                item.Invoce.Number.Contains(search)).ToList();
            }
            DataList.ItemsSource = inventoryObjects;
        }
    }
}