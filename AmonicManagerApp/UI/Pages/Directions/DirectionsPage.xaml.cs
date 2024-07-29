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

namespace AmonicManagerApp.UI.Pages.Directions
{
    /// <summary>
    /// Логика взаимодействия для DirectionsPage.xaml
    /// </summary>
    public partial class DirectionsPage : Page
    {
        public DirectionsPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;

            if (StartViewModel.ViewModel.ListDirections.Count > 0)
            {
                lblNotData.Visibility = Visibility.Collapsed;
            }
            else
            {
                dgPlanes.Visibility = Visibility.Collapsed;
                drPlanes.Visibility = Visibility.Collapsed;
            }
        }

       

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (StartViewModel.ViewModel.DirectionActive)
            {
                btnActive.Height = 70;
                btnActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
                btnInActive.Height = 40;
                btnInActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
            }
            else
            {
                btnActive.Height = 40;
                btnActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
                btnInActive.Height = 70;
                btnInActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
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
