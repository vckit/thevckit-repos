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
        public InventoryObject InventoryObject { get; set; }
        public InventoryObjectDetails InventoryObjectDetails { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public Invoce Invoce { get; set; }
        public List<Employe> Employees { get; set; }
        public List<Model.Type> Types { get; set; }
        public List<SubType> SubTypes { get; set; }
        public List<Status> Statuses { get; set; }

        public ActioInventoryPageView(InventoryObject inventoryObject, InventoryObjectDetails inventoryObjectDetails, CurrentStatus currentStatus, Invoce invoce)
        {
            InitializeComponent();
            InventoryObject = inventoryObject;
            CurrentStatus = currentStatus;
            Invoce = invoce;
            InventoryObjectDetails = inventoryObjectDetails;
            Employees = AppData.db.Employe.ToList();
            Types = AppData.db.Type.ToList();
            SubTypes = AppData.db.SubType.ToList();
            Statuses = AppData.db.Status.ToList();
            txbPath.Text = inventoryObject.DocumentationPath;
            this.DataContext = this;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (InventoryObject.ID == 0 && InventoryObjectDetails.ID == 0 & CurrentStatus.ID == 0 && Invoce.ID == 0)
                {
                    AppData.db.CurrentStatus.Add(CurrentStatus);
                    AppData.db.InventoryObjectDetails.Add(InventoryObjectDetails);
                    AppData.db.Invoce.Add(Invoce);
                    InventoryObject.IDCurrentStatus = CurrentStatus.ID;
                    InventoryObject.IDInvoce = Invoce.ID;
                    InventoryObject.IDInventoryObjectDetail = InventoryObjectDetails.ID;
                    InventoryObject.DocumentationPath = file.FileName;
                    AppData.db.InventoryObject.Add(InventoryObject);
                }
                AppData.db.SaveChanges();
                MessageBox.Show("ДАННЫЕ ДОБАВЛЕНЫ В БАЗУ ДАННЫХ.", "УСПЕШНО СОХРАНЕНО!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс... что-то пошло не так :(", MessageBoxButton.OK, MessageBoxImage.Warning);
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
    }
}