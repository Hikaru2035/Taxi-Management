using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaxiManagementAssignment;

namespace TaxiManagementWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RankManager _rankManager;
        private TaxiManager _taxiManager;
        private TransactionManager _transactionManager;
        private ViewTaxiLocation _viewTaxiLocationWindow;
        private ViewFinancial _viewFinancial;
        private ViewTransactionLog _viewTransactionLog;


        public MainWindow()
        {
            InitializeComponent();
            _rankManager = new RankManager();
            _taxiManager = new TaxiManager();
            _transactionManager = new TransactionManager();
        }

        private void ViewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (_viewTaxiLocationWindow == null || !_viewTaxiLocationWindow.IsLoaded)
            {
                _viewTaxiLocationWindow = new ViewTaxiLocation(_rankManager, _taxiManager, _transactionManager)
                {
                    Owner = this
                };
                _viewTaxiLocationWindow.Closed += (s, args) => _viewTaxiLocationWindow = null;
                _viewTaxiLocationWindow.Show();
            }
            else
            {
                if (_viewTaxiLocationWindow.WindowState == WindowState.Minimized)
                {
                    _viewTaxiLocationWindow.WindowState = WindowState.Normal;
                }
                _viewTaxiLocationWindow.Activate();
            }
        }


        private void ViewFinancial_Click (object sender, RoutedEventArgs e)
        {
            if (_viewFinancial == null || !_viewFinancial.IsLoaded)
            {
                _viewFinancial = new ViewFinancial(_rankManager, _taxiManager, _transactionManager)
                {
                    Owner = this
                };
                _viewFinancial.Closed += (s, args) => _viewFinancial = null;
                _viewFinancial.Show();
            }
            else
            {
                if (_viewFinancial.WindowState == WindowState.Minimized)
                {
                    _viewFinancial.WindowState = WindowState.Normal;
                }
                _viewFinancial.Activate();
            }
        }

        private void ViewTransactionLog_Click (object sender, RoutedEventArgs e)
        {
            if (_viewTransactionLog == null || !_viewTransactionLog.IsLoaded)
            {
                _viewTransactionLog = new ViewTransactionLog(_rankManager, _taxiManager, _transactionManager)
                {
                    Owner = this
                };
                _viewTransactionLog.Closed += (s, args) => _viewTransactionLog = null;
                _viewTransactionLog.Show();
            }
            else
            {
                if (_viewTransactionLog.WindowState == WindowState.Minimized)
                {
                    _viewTransactionLog.WindowState = WindowState.Normal;
                }
                _viewTransactionLog.Activate();
            }
        }
    }
}