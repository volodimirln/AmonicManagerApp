using AmonicManagerApp.Data;
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

namespace AmonicManagerApp.UI.Pages.Home
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = StartViewModel.ViewModel;
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            if (StartViewModel.ViewModel.User.RoleId == 3)
            {

                MessageBox.Show("Нет прав доступа");
            }
        }

        private void btnPlane_Click(object sender, RoutedEventArgs e)
        {
            if (StartViewModel.ViewModel.User.RoleId == 3)
            {
                MessageBox.Show("Нет прав доступа");
            }
        }
    }
}
