using System.Windows;
using System.Windows.Controls;

namespace FileUpload
{
    /// <summary>
    /// Логика взаимодействия для FileDetail.xaml
    /// </summary>
    public partial class FileDetail : UserControl
    {
        public FileDetail()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(FileDetail));

        public string FileSize
        {
            get { return (string)GetValue(FileSizeProperty); }
            set { SetValue(FileSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileSizeProperty =
            DependencyProperty.Register("FileSize", typeof(string), typeof(FileDetail));



        public int UploadProgress
        {
            get { return (int)GetValue(UploadProgressProperty); }
            set { SetValue(UploadProgressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UploadProgress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UploadProgressProperty =
            DependencyProperty.Register("UploadProgress", typeof(int), typeof(FileDetail));



        public int UploadSpeed
        {
            get { return (int)GetValue(UploadSpeedProperty); }
            set { SetValue(UploadSpeedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UploadSpeed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UploadSpeedProperty =
            DependencyProperty.Register("UploadSpeed", typeof(int), typeof(FileDetail));


    }
}
