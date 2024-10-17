using System.Windows;

namespace TaxiManagementWPF
{
    public partial class AddTaxiToRank : Window
    {
        public AddTaxiToRank()
        {
            InitializeComponent();
        }

        // OK button click handler
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate inputs here if necessary
            this.DialogResult = true;
            this.Close();
        }

        // Cancel button click handler
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}