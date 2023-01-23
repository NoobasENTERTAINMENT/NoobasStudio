using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace NoobasStudio.Views
{
    /// <summary>
    /// Логика взаимодействия для CraftGenerealView.xaml
    /// </summary>
    public partial class CraftGenerealView : Window
    {
        public CraftGenerealView()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Border_Drop(object sender, DragEventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.GetFullPath("book.png");
                if (filePath.Contains("\\bin\\Debug\\"))
                     filePath = filePath.Replace("\\bin\\Debug\\", "\\Images\\");
                borderProfileImage.ImageSource = new BitmapImage(new Uri(filePath, UriKind.Relative));
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}