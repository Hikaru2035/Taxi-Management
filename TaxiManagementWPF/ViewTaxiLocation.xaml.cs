using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TaxiManagementAssignment;

namespace TaxiManagementWPF
{
    public partial class ViewTaxiLocation : Window
    {
        private RankManager _rankManager;
        private TaxiManager _taxiManager;
        private TransactionManager _transactionManager;
        private UserUI _userUI;

        public ViewTaxiLocation(RankManager rankManager, TaxiManager taxiManager, TransactionManager transactionManager)
        {
            InitializeComponent();
            _rankManager = rankManager;
            _taxiManager = taxiManager;
            _transactionManager = transactionManager;
            _userUI = new UserUI(_rankManager, _taxiManager, _transactionManager);

            // Use shared collections
            JoinRank.ItemsSource = SharedDataContext.TaxiList;
            LeaveRank.ItemsSource = SharedDataContext.TaxiLeave;
            DropFare.ItemsSource = SharedDataContext.TaxiTakeFare;
            ViewLocation.ItemsSource = SharedDataContext.ViewLocation;
        }

        // Event handler for adding a taxi to a rank
        private void AddTaxiToRank_Click(object sender, RoutedEventArgs e)
        {
            var addTaxiWindow = new AddTaxiToRank
            {
                Owner = this
            };

            try
            {
                bool? result = addTaxiWindow.ShowDialog();
                if (result == true)
                {
                    int taxiNum = Convert.ToInt32(addTaxiWindow.TaxiNum.Text);
                    int rankNum = Convert.ToInt32(addTaxiWindow.RankNum.Text);

                    // Call method to add taxi to rank and get the result list
                    List<string> resultList = _userUI.TaxiJoinsRank(taxiNum, rankNum);

                    // Add all items from the result list to the observable collection
                    foreach (var item in resultList)
                    {
                        SharedDataContext.TaxiList.Add(item);
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers for Taxi and Rank.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        // Event handler for taxi leaving a rank
        private void TaxiLeaveRank_Click(object sender, RoutedEventArgs e)
        {
            var leaveTaxiWindow = new TaxiLeaveRank
            {
                Owner = this
            };

            try
            {
                bool? result = leaveTaxiWindow.ShowDialog();
                if (result == true)
                {
                    int taxiNum = Convert.ToInt32(leaveTaxiWindow.TaxiNum.Text);
                    double agreedPrice = Convert.ToInt32(leaveTaxiWindow.AgreedPrice.Text);
                    string destination = leaveTaxiWindow.Destination.Text;

                    // Call method to add taxi to rank and get the result list
                    List<string> resultList = _userUI.TaxiLeavesRank(taxiNum, destination, agreedPrice);

                    // Add all items from the result list to the observable collection
                    foreach (var item in resultList)
                    {
                        SharedDataContext.TaxiLeave.Add(item);
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers for Taxi and Rank.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        // Event handler for dropping fare
        private void TaxiDropFare_Click(object sender, RoutedEventArgs e)
        {
            var dropFareTaxiWindow = new TaxiDropFare
            {
                Owner = this
            };

            try
            {
                bool? result = dropFareTaxiWindow.ShowDialog();
                if (result == true)
                {
                    int taxiNum = Convert.ToInt32(dropFareTaxiWindow.TaxiNum.Text);
                    ComboBoxItem selectedItem = (ComboBoxItem)dropFareTaxiWindow.PaidOrNot.SelectedItem;
                    if (selectedItem != null)
                    {
                        bool agreedPrice = (selectedItem.Content.ToString() == "Paid");
                        List<string> resultList = _userUI.TaxiDropsFare(taxiNum, agreedPrice);
                        foreach (var item in resultList)
                        {
                            SharedDataContext.TaxiTakeFare.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select whether the price is paid or not.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers for Taxi and Rank.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        // Event handler for viewing taxi locations
        private void ViewLocation_Click(object sender, RoutedEventArgs e)
        {
            List<string> resultList = _userUI.ViewTaxiLocations();
            SharedDataContext.ViewLocation.Clear();
            foreach (var item in resultList)
            {
                SharedDataContext.ViewLocation.Add(item);

            }
        }

        // Event handler for cancel button
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
