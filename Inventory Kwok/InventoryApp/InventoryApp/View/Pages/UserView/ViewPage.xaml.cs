using InventoryApp.Context;
using InventoryApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace InventoryApp.View.Pages.UserView
{
    /// <summary>
    /// Interaction logic for ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        public ViewPage()
        {
            InitializeComponent();
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

        // Выйти
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Выгрузка данных
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataList.ItemsSource = AppData.db.InventoryObject.ToList();
        }

        private void buttonListComplection_Click(object sender, RoutedEventArgs e)
        {
            var selectedInventoryObject = (InventoryObject)DataList.SelectedItem;
            if(selectedInventoryObject != null)
            {
                NavigationService.Navigate(new InventoryObjectPageView(selectedInventoryObject.Title, selectedInventoryObject.ID));
            }
        }

        // Посмотреть историю
        private void ViewHistoryObject(object sender, RoutedEventArgs e)
        {
            var selectedInventoryObject = (InventoryObject)DataList.SelectedItem;
            if (selectedInventoryObject != null)
                NavigationService.Navigate(new HistoryPageView(selectedInventoryObject));
        }

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
                MessageBox.Show(ex.Message, "Упс... что-то пошло не так :(", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

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
                    if (item.InventoryObject.CommissioningDate.AddYears(item.InventoryObject.LifeTime) < DateTime.Today)
                        table.Cell(i, 5).Range.Text = "НЕТ";
                    else
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

        private List<InventoryObject> CheckDateObject(List<InventoryObject> collection)
        {
            List<InventoryObject> list = new List<InventoryObject>();
            foreach (InventoryObject item in collection)
            {
                if (item.CommissioningDate.AddYears(item.LifeTime) < DateTime.Today) list.Add(item);
            }
            if (list.Count > 0) return list; else return null;
        }

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

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Page_Loaded(null, null);
        }

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
                inventoryObjects = inventoryObjects.Where(item => item.Title.Contains(txbSearch.Text) ||
                item.LifeTime.ToString().Contains(txbSearch.Text) ||
                item.Employe.FIO.Contains(txbSearch.Text) ||
                item.Type.Title.Contains(txbSearch.Text) ||
                item.SubType.Title.Contains(txbSearch.Text) ||
                item.CurrentStatus.Status.Title.Contains(txbSearch.Text) ||
                item.Amount.ToString().Contains(txbSearch.Text) ||
                item.Invoce.Number.Contains(txbSearch.Text)).ToList();
            }
            DataList.ItemsSource = inventoryObjects;
        }
        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search((cmbStatus.SelectedItem as ComboBoxItem).Content.ToString(), txbSearch.Text);
        }
    }
}
