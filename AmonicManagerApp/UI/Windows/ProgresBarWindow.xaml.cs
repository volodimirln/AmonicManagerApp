using AmonicManagerApp.Data;
using AmonicManagerApp.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AmonicManagerApp.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProgresBarWindow.xaml
    /// </summary>
    public partial class ProgresBarWindow : Window
    {
        public ProgresBarWindow()
        {
            InitializeComponent();
            Dispatcher.InvokeAsync(async () =>
            {
                pbStatus.Value += 10;
                Model model  = new Model();
                pbStatus.Value += 10;
                if (!model.Database.Exists())
                {
                    model.Database.CreateIfNotExists();
                    if (model.Roles.Count() == 0)
                    {
                        await Repository.SetRoles();
                        pbStatus.Value += 9;
                    }
                    if (model.Countries.Count() == 0)
                    {
                        await Repository.SetCountries();
                        pbStatus.Value += 9;
                    }
                    if (model.Users.Count() == 0)
                    {
                        await Repository.SetUsers();
                        pbStatus.Value += 9;

                    }
                    if (model.Passwords.Count() == 0)
                    {
                        await Repository.SetPasswords();
                        pbStatus.Value += 9;

                    }
                    if (model.Airports.Count() == 0)
                    {
                        await Repository.SetAirports();
                        pbStatus.Value += 9;

                    }
                    if (model.Directions.Count() == 0)
                    {
                        await Repository.SetDirections();
                        pbStatus.Value += 9;

                    }
                    if (model.Planes.Count() == 0)
                    {
                        await Repository.SetPlanes();
                        pbStatus.Value += 9;

                    }
                    if (model.Terminals.Count() == 0)
                    {
                        await Repository.SetTerminals();
                        pbStatus.Value += 9;

                    }
                    if (model.TerminalsInDirections.Count() == 0)
                    {
                        await Repository.SetTerminalsInDirections();
                        pbStatus.Value += 9;

                    }
                    if (model.Flyings.Count() == 0)
                    {
                        await Repository.SetFlyings();
                        pbStatus.Value += 9;

                    }

                    if (model.Pricings.Count() == 0)
                    {
                        await Repository.SetPricings();
                        pbStatus.Value += 9;

                    }
                    if (model.Tickets.Count() == 0)
                    {
                        await Repository.SetTickets();
                        pbStatus.Value += 9;

                    }
                }
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }, DispatcherPriority.Background);

        }
    }
}
