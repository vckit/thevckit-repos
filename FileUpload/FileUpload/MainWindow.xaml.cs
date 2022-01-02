using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace FileUpload
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog() { Multiselect = true };
            bool? response = fileDialog.ShowDialog();
            if(response == true)
            {
                // Get Selected Files
                string[] files = fileDialog.FileNames;

                // Iterate and add all selected files to upload
                for (int i = 0; i < files.Length; i++)
                {
                    string filename = System.IO.Path.GetFileName(files[i]);
                    FileInfo fileInfo = new FileInfo(files[i]);
                    UploadingFilesList.Items.Add(new FileDetail()
                    {
                        FileName = filename,

                        // To Convert bytes to MB -> 1.0493+6
                        FileSize = string.Format("{0} {1}", (fileInfo.Length / 1.049e+6).ToString("0.0"), "MB"), UploadProgress = 100
                    });
                }
            }
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            // Checking what kind in of file in User dropping
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string fileName = System.IO.Path.GetFileName(files[0]);
                // Iterate and add all selected files to upload
                for (int i = 0; i < files.Length; i++)
                {
                    string filename = System.IO.Path.GetFileName(files[i]);
                    FileInfo fileInfo = new FileInfo(files[i]);
                    UploadingFilesList.Items.Add(new FileDetail()
                    {
                        FileName = filename,

                        // To Convert bytes to MB -> 1.0493+6
                        FileSize = string.Format("{0} {1}", (fileInfo.Length / 1.049e+6).ToString("0.0"), "MB"),
                        UploadProgress = 100
                    });
                }
            }
        }
    }
}
