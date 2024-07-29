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

namespace AmonicManagerApp.UI.Pages.Users.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditUserPage.xaml
    /// </summary>
    public partial class AddEditUserPage : Page
    {
        public AddEditUserPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
            btnBack.DataContext = StartViewModel.ViewModel;
            if (StartViewModel.ViewModel.SelectedUser != null)
            {
                dgTicketsUser.ItemsSource = Model.GetContext().Tickets.Where(p => p.UserId == StartViewModel.ViewModel.SelectedUser.Id).ToList();
            }
            else
            {
                StartViewModel.ViewModel.SelectedUser = new User();
                lblTicket.Visibility = Visibility.Collapsed;
                dgTicketsUser.Visibility = Visibility.Collapsed;
                btnAddTIcket.Visibility = Visibility.Collapsed;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (StartViewModel.ViewModel.SelectedUser.Id == 0)
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
