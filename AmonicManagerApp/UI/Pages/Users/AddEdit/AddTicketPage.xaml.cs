using AmonicManagerApp.Data;
using AmonicManagerApp.Modules;
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
    /// Логика взаимодействия для AddTicketPage.xaml
    /// </summary>
    public partial class AddTicketPage : Page
    {
        public AddTicketPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
            btnBack.DataContext = StartViewModel.ViewModel;
            cmPricing.ItemsSource = Model.GetContext().Pricings.ToList();
            stcNewTicket.DataContext = new Ticket();
            dgTicketsUser.ItemsSource = Model.GetContext().Pricings.OrderByDescending(p => p.Id).Take(5).ToList();
            lblClient.Content = StartViewModel.ViewModel.SelectedUser.Surname + " " + StartViewModel.ViewModel.SelectedUser.Name + " " + StartViewModel.ViewModel.SelectedUser.Patronymic;
        }

        
        
    }
}
