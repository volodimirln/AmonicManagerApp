using AmonicManagerApp.ViewModels;
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

namespace AmonicManagerApp.UI.Pages.Airports
{
    /// <summary>
    /// Логика взаимодействия для AirportsPage.xaml
    /// </summary>
    public partial class AirportsPage : Page
    {
        public AirportsPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void DataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            StartViewModel.ViewModel.CurrentPage = new UI.Pages.Airports.Info.TerminalsPage();

        }
    }
}
