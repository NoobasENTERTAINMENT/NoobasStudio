using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoobasStudio.Views
{
    /// <summary>
    /// Логика взаимодействия для SubsView.xaml
    /// </summary>
    public partial class SubsView : UserControl
    {
        public SubsView()
        {
            InitializeComponent();
        }
        private void SubsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ListBox)sender).ScrollIntoView(SubsListView.SelectedItem);
        }
    }
}
