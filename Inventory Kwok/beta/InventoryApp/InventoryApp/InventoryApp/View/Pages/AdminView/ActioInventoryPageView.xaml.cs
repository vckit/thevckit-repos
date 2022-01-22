﻿using InventoryApp.Context;
using InventoryApp.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.View.Pages.AdminView
{
    /// <summary>
    /// Interaction logic for ActioInventoryPageView.xaml
    /// </summary>
    public partial class ActioInventoryPageView : Page
    {
        public History History { get; set; }
        public List<Cabinet> Cabinets { get; set; }
        public InventoryObject InventoryObject { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public Invoce Invoce { get; set; }
        public List<Employe> Employees { get; set; }
        public List<Model.Type> Types { get; set; }
        public List<SubType> SubTypes { get; set; }
        public List<Status> Statuses { get; set; }

        public ActioInventoryPageView(InventoryObject inventoryObject, CurrentStatus currentStatus, Invoce invoce)
        {
            InitializeComponent();
            InventoryObject = inventoryObject;
            CurrentStatus = currentStatus;
            Invoce = invoce;
            Employees = AppData.db.Employe.ToList();
            Types = AppData.db.Type.ToList();
            SubTypes = AppData.db.SubType.ToList();
            Statuses = AppData.db.Status.ToList();
            txbPath.Text = inventoryObject.DocumentationPath;
            cmbLifeTime.Text = inventoryObject.LifeTime.ToString();
            Cabinets = AppData.db.Cabinet.ToList();
            this.DataContext = this;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (InventoryObject.ID == 0 && CurrentStatus.ID == 0 && Invoce.ID == 0)
                {
                    AppData.db.CurrentStatus.Add(CurrentStatus);
                    AppData.db.Invoce.Add(Invoce);
                    InventoryObject.IDCurrentStatus = CurrentStatus.ID;
                    InventoryObject.IDInvoce = Invoce.ID;
                    AppData.db.InventoryObject.Add(InventoryObject);
                    var cabinet = AppData.db.CabinetInventoryObject.FirstOrDefault(item => item.IDInventoryObject == InventoryObject.ID);
                    if (AppData.db.InventoryObject.Count(item => item.InventoryNumber == InventoryObject.InventoryNumber) > 0)
                    {
                        throw new Exception($"Объект с интерьерным номером {InventoryObject.InventoryNumber} уже существует в базе данных");
                    }
                }

                if (file.FileName != "")
                    InventoryObject.DocumentationPath = file.FileName;
                InventoryObject.LifeTime = int.Parse(cmbLifeTime.Text);
                AppData.db.SaveChanges();
                MessageBox.Show("ДАННЫЕ ДОБАВЛЕНЫ В БАЗУ ДАННЫХ.", "УСПЕШНО СОХРАНЕНО!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
                GC.Collect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        OpenFileDialog file = new OpenFileDialog();
        private void buttonSelectPath_Click(object sender, RoutedEventArgs e)
        {
            file.Filter = "file name (*.docx;*.rtf;*.doc;) | *.docx;*.rtf;*.doc;";
            if (file.ShowDialog() == true)
            {
                txbPath.Text = file.FileName;
            }
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "0123456789.".IndexOf(e.Text) < 0;
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}