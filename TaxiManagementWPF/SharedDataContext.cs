using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementWPF
{
    public static class SharedDataContext
    {
        public static ObservableCollection<string> TaxiList = new ObservableCollection<string>();
        public static ObservableCollection<string> TaxiLeave = new ObservableCollection<string>();
        public static ObservableCollection<string> TaxiTakeFare = new ObservableCollection<string>();
        public static ObservableCollection<string> ViewLocation = new ObservableCollection<string>();  
        public static ObservableCollection<string> ViewFinancial = new ObservableCollection<string>();
        public static ObservableCollection<string> ViewTransactionLog = new ObservableCollection<string>(); 
    }
}
