using InventoryApp.Context;
using System;
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

        // Распечатать данные
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
                table.Cell(1, 8).Range.Text = "Комплектность - наименование)";
                table.Cell(1, 9).Range.Text = "Комплектность – серийный номер";
                table.Cell(1, 10).Range.Text = "Документация";
                table.Cell(1, 11).Range.Text = "Состояние списания";
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
                document.SaveAs2($"{Environment.CurrentDirectory}\\ведомость.docx");
                document.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                word.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
                MessageBox.Show("Сохранение прошло успешно!", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " выдал исключение!", MessageBoxButton.OK, MessageBoxImage.Error);
                word.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
            }
        }

        // Поиск данных
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataList.ItemsSource = AppData.db.InventoryObject.Where(item => item.Title.Contains(txbSearch.Text) ||
            item.Employe.FIO.Contains(txbSearch.Text)).ToList();
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
    }
}
