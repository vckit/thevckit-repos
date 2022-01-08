using CRUDListView.Context;
using CRUDListView.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CRUDListView.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ActionViewPage.xaml
    /// </summary>
    public partial class ActionViewPage : Page
    {
        public UserPersonal UserPersonal { get; set; }
        public List<Status> Status { get; set; }

        public ActionViewPage(UserPersonal user)
        {
            InitializeComponent();
            UserPersonal = user;
            Status = AppData.db.Status.ToList();
            TxbFileName.Text = user.Photo;
            this.DataContext = this;
        }

        OpenFileDialog fileDialog = new OpenFileDialog();
        private void ChooseFileBtn_Click(object sender, RoutedEventArgs e)
        {
            fileDialog.Filter = "Image (*.png; *.jpeg; *.jpg;) | *.png; *.jpeg; *.jpg;";
            if (fileDialog.ShowDialog() == true)
            {
                BitmapImage imgBitmap = new BitmapImage(new Uri(fileDialog.FileName));
                Pic.Source = imgBitmap;
                TxbFileName.Text = Path.GetFileName(fileDialog.FileName);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserPersonal.ID == 0)
                {
                    AppData.db.UserPersonal.Add(UserPersonal);
                }
                File.Copy(fileDialog.FileName, $"photos\\{Path.GetFileName(fileDialog.FileName).Trim()}", true);
                UserPersonal.GetPhoto = Path.GetFileName(fileDialog.FileName);
                AppData.db.SaveChanges();
                MessageBox.Show("Data saved.", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                GC.Collect();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "+1234567890".IndexOf(e.Text) < 0;
        }
    }
}
