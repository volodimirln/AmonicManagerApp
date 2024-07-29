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

namespace AmonicManagerApp.UI.Pages.Flying.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditFlyingPage.xaml
    /// </summary>
    public partial class AddEditFlyingPage : Page
    {
        public AddEditFlyingPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
            if (StartViewModel.ViewModel.SelectedFlying == null)
            {
                stcForm.DataContext = new Data.Flying();
                AddItem.Height =  45;
                EditItem.Height = 65;
            }
            else
            {
                stcForm.DataContext = StartViewModel.ViewModel.SelectedFlying;
                AddItem.Height = 65;
                EditItem.Height = 45;
            }
           
            cmbDirection.ItemsSource = Model.GetContext().Directions.ToList();
            cmbPlane.ItemsSource = Model.GetContext().Planes.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (StartViewModel.ViewModel.SelectedFlying == null)
            {
                AddItem.Height = 55;
                EditItem.Height = 35;
                
                AddItem.CornerRadius = new CornerRadius(8, 8,0,0);
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
