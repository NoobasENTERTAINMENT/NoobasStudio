using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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
            if(SubsListView.SelectedIndex < SubsListView.Items.Count-1)
            {
                int index = SubsListView.SelectedIndex+1;
                object item = SubsListView.Items.GetItemAt(index);
                SubsListView.ScrollIntoView(item);
            }
        }
    }
}
