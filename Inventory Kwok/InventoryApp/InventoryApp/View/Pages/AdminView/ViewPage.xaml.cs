﻿using InventoryApp.Context;
using InventoryApp.Model;
using InventoryApp.View.Windows;
using System;
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
            NavigationService.Navigate(new ActioInventoryPageView(new Model.InventoryObject(), new Model.InventoryObjectDetails(), new Model.CurrentStatus(), new Model.Invoce()));
        }

        // Редактирование выбранного объекта
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedInventoryObject = (InventoryObject)DataList.SelectedItem;
            if (selectedInventoryObject != null)
            {
                var selectedInventoryObjectDetails = AppData.db.InventoryObjectDetails.FirstOrDefault(item => item.ID == selectedInventoryObject.IDInventoryObjectDetail);
                var selectedCurrentStatus = AppData.db.CurrentStatus.FirstOrDefault(item => item.ID == selectedInventoryObject.IDCurrentStatus);
                var selectedInvoce = AppData.db.Invoce.FirstOrDefault(item => item.ID == selectedInventoryObject.IDInvoce);
                NavigationService.Navigate(new ActioInventoryPageView(selectedInventoryObject, selectedInventoryObjectDetails, selectedCurrentStatus, selectedInvoce));
            }
        }

        // Удаление объекта из базы данных
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (InventoryObject)DataList.SelectedItem;
            if (selectedItem != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранный объект? Данные будут удалены безвозвратно", "Подтвердите удаление.", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    ArhiveInventoryObject arhiveInventoryObject = new ArhiveInventoryObject();
                    arhiveInventoryObject.ID = selectedItem.ID;
                    arhiveInventoryObject.Title = selectedItem.Title;
                    arhiveInventoryObject.InventoryNumber = selectedItem.InventoryNumber;
                    arhiveInventoryObject.DocumentationPath = selectedItem.DocumentationPath;
                    arhiveInventoryObject.IDType = selectedItem.Type.Title;
                    arhiveInventoryObject.IDSubType = selectedItem.SubType.Title;
                    arhiveInventoryObject.LifeTime = selectedItem.LifeTime;
                    arhiveInventoryObject.IDInvoce = selectedItem.Invoce.Number;
                    arhiveInventoryObject.IDCurrentStatus = selectedItem.CurrentStatus.Status.Title;
                    arhiveInventoryObject.Amount = selectedItem.Amount;
                    arhiveInventoryObject.IDEmployee = selectedItem.Employe.FIO;
                    arhiveInventoryObject.IDInventoryObjectDetail = selectedItem.InventoryObjectDetails.GetTitle;
                    arhiveInventoryObject.Date = DateTime.Now;
                    AppData.db.ArhiveInventoryObject.Add(arhiveInventoryObject);
                    AppData.db.InventoryObject.Remove(selectedItem);
                    AppData.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("ДАННЫЕ БЫЛИ УСПЕШНО УДАЛЕНЫ ИЗ БАЗЫ ДАННЫХ.", "УДАЛЕНИЕ ПРОШЛО УСПЕШНО!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
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
            item.Employe.FirstName.Contains(txbSearch.Text) || item.Employe.LastName.Contains(txbSearch.Text) || 
            item.Employe.Patronymic.Contains(txbSearch.Text)).ToList();
        }

        // Распечатать
        private void buttonPrint_Click(object sender, RoutedEventArgs e)
        {
            var word = new Word.Application();

            try
            {
                var document = word.Documents.Add();
                var paragrah = word.ActiveDocument.Paragraphs.Add();
                var tableRange = paragrah.Range;
                var inventoryObjectsList = AppData.db.InventoryObject.ToList();
                var table = document.Tables.Add(tableRange, inventoryObjectsList.Count, 15);
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
                foreach (var item in inventoryObjectsList)
                {
                    table.Cell(i, 1).Range.Text = item.Title;
                    table.Cell(i, 2).Range.Text = item.InventoryNumber;
                    table.Cell(i, 3).Range.Text = item.CommissioningDate.ToLongTimeString();
                    table.Cell(i, 4).Range.Text = item.LifeTime.ToString();
                    table.Cell(i, 5).Range.Text = "ДА";
                    table.Cell(i, 6).Range.Text = item.Type.Title;
                    table.Cell(i, 7).Range.Text = item.SubType.Title;
                    table.Cell(i, 8).Range.Text = item.InventoryObjectDetails.Title;
                    table.Cell(i, 9).Range.Text = item.InventoryObjectDetails.SeriaNumber;
                    table.Cell(i, 10).Range.Text = item.DocumentationPath;
                    table.Cell(i, 11).Range.Text = item.CurrentStatus.Status.Title;
                    table.Cell(i, 12).Range.Text = item.CurrentStatus.NumberAct;
                    table.Cell(i, 13).Range.Text = item.CurrentStatus.Date.ToShortDateString();
                    table.Cell(i, 14).Range.Text = item.Employe.FIO;
                    table.Cell(i, 15).Range.Text = item.Amount.ToString();
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

        // Установить кабинет инвентарю
        private async void buttonSetCabinet_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (InventoryObject)DataList.SelectedItem;
            if(selectedItem != null)
            {
                SetCabinetWindow set = new SetCabinetWindow(new CabinetInventoryObject(), selectedItem);
                await set.Dispatcher.InvokeAsync(() => set.ShowDialog());
            }
        }


        // Посмотреть Архив
        private void buttonArchiveView_Click(object sender, RoutedEventArgs e)
        {
            ArchiveWindow archive = new ArchiveWindow();
            archive.ShowDialog();
        }
    }
}
