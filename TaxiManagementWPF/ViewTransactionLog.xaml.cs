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
using System.Windows.Shapes;
using TaxiManagementAssignment;

namespace TaxiManagementWPF
{
    /// <summary>
    /// Interaction logic for ViewTransactionLog.xaml
    /// </summary>
    public partial class ViewTransactionLog : Window
    {
        private RankManager _rankManager;
        private TaxiManager _taxiManager;
        private TransactionManager _transactionManager;
        private UserUI _userUI;

        public ViewTransactionLog(RankManager rankManager, TaxiManager taxiManager, TransactionManager transactionManager)
        {
            InitializeComponent();
            _rankManager = rankManager;
            _taxiManager = taxiManager;
            _transactionManager = transactionManager;
            _userUI = new UserUI(_rankManager, _taxiManager, _transactionManager);

            // Use shared collections
            ViewLocation.ItemsSource = SharedDataContext.ViewTransactionLog;
        }

        private void ViewLocation_Click(object sender, RoutedEventArgs e)
        {
            List<string> resultList = _userUI.ViewTransactionLog();
            SharedDataContext.ViewTransactionLog.Clear();
            foreach (var item in resultList)
            {
                SharedDataContext.ViewTransactionLog.Add(item);
            }
        }

        // Event handler for cancel button
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
