using AmonicManagerApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AmonicManagerApp.UI.Pages.Planes
{
    /// <summary>
    /// Логика взаимодействия для PlanesPage.xaml
    /// </summary>
    public partial class PlanesPage : Page
    {
        public PlanesPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;

            if (StartViewModel.ViewModel.User.RoleId != 3)
            {            
                btnAddPlane.Visibility = Visibility.Collapsed;
                var thk = new Thickness();
                thk.Left = 237;
                btnUpdate.Margin = thk;
            }
            if (StartViewModel.ViewModel.ListPlanes.Count > 0)
            {
                lblNotData.Visibility = Visibility.Collapsed;
            }
            else
            {
                dgPlanes.Visibility = Visibility.Collapsed;
                drPlanes.Visibility = Visibility.Collapsed;
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (StartViewModel.ViewModel.User.RoleId == 3)
            {
                StartViewModel.ViewModel.CurrentPage = new UI.Pages.Planes.AddEdit.AddEditPlanesPage();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (StartViewModel.ViewModel.PlaneActive)
            {
                btnPlaneActive.Height = 65;
                btnPlaneActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
                btnPlaneInActive.Height = 35;
                btnPlaneInActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
            }
            else
            {
                btnPlaneActive.Height = 35;
                btnPlaneActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
                btnPlaneInActive.Height = 65;
                btnPlaneInActive.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
                CornerRadius cornerRadius = new CornerRadius();
                cornerRadius.TopLeft = 10;
                cornerRadius.TopRight = 10;
                cornerRadius.BottomLeft = 10;
                cornerRadius.BottomRight = 10;
            }
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (StartViewModel.ViewModel.User.RoleId == 3)
            {
                MessageBox.Show("Нет прав доступа");
            }
        }
    }
}
