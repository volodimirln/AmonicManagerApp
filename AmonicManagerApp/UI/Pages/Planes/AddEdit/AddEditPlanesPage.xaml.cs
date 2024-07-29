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

namespace AmonicManagerApp.UI.Pages.Planes.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditPlanesPage.xaml
    /// </summary>
    public partial class AddEditPlanesPage : Page
    {
        public AddEditPlanesPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
            if (StartViewModel.ViewModel.SelectedPlanes == null)
            {
                stcForm.DataContext = new Data.Plane();
            }
            else
            {
                stcForm.DataContext = StartViewModel.ViewModel.SelectedPlanes;
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (StartViewModel.ViewModel.SelectedPlanes == null)
            {
                AddItem.Height = 55;
                EditItem.Height = 35;

                AddItem.CornerRadius = new CornerRadius(8, 8, 0, 0);
                EditItem.CornerRadius = new CornerRadius(8, 8, 8, 8);
                lblEdit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
            }
            else
            {
                AddItem.Height = 35;
                EditItem.Height = 55;
                EditItem.CornerRadius = new CornerRadius(8, 8, 0, 0);
                AddItem.CornerRadius = new CornerRadius(8, 8, 8, 8);
                lblAdd.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#757575"));
            }
        }
    }
}
