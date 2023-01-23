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
            Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}