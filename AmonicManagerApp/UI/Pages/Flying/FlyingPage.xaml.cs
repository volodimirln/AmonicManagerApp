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

namespace AmonicManagerApp.UI.Pages.Flying
{
    /// <summary>
    /// Логика взаимодействия для FlyingPage.xaml
    /// </summary>
    public partial class FlyingPage : Page
    {
        public FlyingPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
            btnAdd.Visibility = Visibility.Visible;
            if (StartViewModel.ViewModel.User.RoleId == 3)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                var thk = new Thickness();
                thk.Left = 180;
                btnCompleteFlyight.Margin = thk;
            }
            if (StartViewModel.ViewModel.ListFlyings.Count > 0)
            {
                lblNotData.Visibility = Visibility.Collapsed;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (StartViewModel.ViewModel.FlyingStatus == 1)
            {
                lblSort.Content = "Выполненые рейсы";
            }
            if (StartViewModel.ViewModel.FlyingStatus == 2)
            {
                lblSort.Content = "Отмененные рейсы";
            }
            if (StartViewModel.ViewModel.FlyingType == "Международный")
            {
                btnInternational.Height = 65;
                btnInternational.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
                btnInsaid.Height = 35;
                btnInsaid.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
            }
            else
            {
                btnInternational.Height = 35;
                btnInternational.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
                btnInsaid.Height = 65;
                btnInsaid.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
                CornerRadius cornerRadius = new CornerRadius();
                cornerRadius.TopLeft = 10;
                cornerRadius.TopRight = 10;
                cornerRadius.BottomLeft = 10;
                cornerRadius.BottomRight = 10;
                brdMain.CornerRadius = cornerRadius;
            }
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartViewModel.ViewModel.User.RoleId == 3)
            {
                MessageBox.Show("Нет прав доступа");
            }
        }

        private void btnInsaid_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
