using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Flow.Launcher.Plugin.FandomSearch
{
    public partial class SettingsControl : UserControl
    {
        public ObservableCollection<SettingsItem> SettingsItems { get; set; }

        public SettingsControl(Settings settings)
        {
            InitializeComponent();
            // _settings = settings;
            // Initialize the ObservableCollection

            SettingsItems = new ObservableCollection<SettingsItem>();

            // Set the DataGrid's ItemsSource to the ObservableCollection
            SettingsDataGrid.ItemsSource = SettingsItems;
        }
        // Event handler for the "Add New Row" button click
        private void AddNewRow_Click(object sender, RoutedEventArgs e)
        {
            // Add a new SettingsItem to the ObservableCollection
            SettingsItems.Add(new SettingsItem());
        }
    }
    // Class to represent each row in the DataGrid
    public class SettingsItem
    {
        public string ActionKeyword { get; set; }
        public string Title { get; set; }
    }
}
