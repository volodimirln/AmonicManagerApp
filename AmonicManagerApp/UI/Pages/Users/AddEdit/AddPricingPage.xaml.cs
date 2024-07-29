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

namespace AmonicManagerApp.UI.Pages.Users.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddPricingPage.xaml
    /// </summary>
    public partial class AddPricingPage : Page
    {
        public AddPricingPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
            btnBack.DataContext = StartViewModel.ViewModel;
            stcNewPricing.DataContext = new Data.Pricing();
            cmbFlying.ItemsSource = Data.Model.GetContext().Flyings.ToList();
        }

        private void cmbFlying_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.Flying item = (cmbFlying.SelectedItem as Data.Flying);
            int model = item.PlaneId;
            if (model == 3 || model == 4 || model == 5 || model == 9 || model == 13 || model == 14)
            {
                imgScheme.Source = new BitmapImage(new Uri("/UI/images/scheme/737.png", UriKind.Relative));
            }
            else if (model == 8)
            {
                imgScheme.Source = new BitmapImage(new Uri("/UI/images/scheme/A319.png", UriKind.Relative));
            }
            else if (model == 1 || model == 2 || model == 12 || model == 7)
            {
                imgScheme.Source = new BitmapImage(new Uri("/UI/images/scheme/A320.png", UriKind.Relative));
            }
            else if (model == 15 || model == 5 || model == 10)
            {
                imgScheme.Source = new BitmapImage(new Uri("/UI/images/scheme/A321.png", UriKind.Relative));
            }
            else
            {
                imgScheme.Source = null;
            }
        }
    }
}
