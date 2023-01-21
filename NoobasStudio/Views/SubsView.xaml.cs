using NoobasStudio.Core;
using System;
using System.Collections.Specialized;
using System.Windows.Controls;

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
            SubsListView.ScrollToCenterOfView(SubsListView.SelectedItem);
        }
    }
}
