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

namespace AmonicManagerApp.UI.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
        }

        private void btnPlaneActive_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUsersActive_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUsersInActive_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (StartViewModel.ViewModel.UserStatus)
            {
                btnUsersActive.Height = 65;
                btnUsersActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
                btnUsersInActive.Height = 35;
                btnUsersInActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
            }
            else
            {
                btnUsersActive.Height = 35;
                btnUsersActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
                btnUsersInActive.Height = 65;
                btnUsersInActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
                CornerRadius cornerRadius = new CornerRadius();
                cornerRadius.TopLeft = 10;
                cornerRadius.TopRight = 10;
                cornerRadius.BottomLeft = 10;
                cornerRadius.BottomRight = 10;
                //brdMain.CornerRadius = cornerRadius;
            }
        }
    }
}
