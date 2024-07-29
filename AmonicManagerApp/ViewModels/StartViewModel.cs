using AmonicManagerApp.Data;
using AmonicManagerApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace AmonicManagerApp.ViewModels
{
    public class StartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static StartViewModel ViewModel = new StartViewModel();

        private Plane planeMostFlyingHours { set { } get { return Model.GetContext().Planes.OrderByDescending(p => p.FlightHours).ToList().FirstOrDefault(); } }
        public Plane PlaneMostFlyingHours
        {
            get { return planeMostFlyingHours; }
            set
            {
                planeMostFlyingHours = value;
                OnPropertyChanged("PlaneMostFlyingHours");
            }
        }

        private Plane planeMostTimeHours { set { } get { return Model.GetContext().Planes.OrderByDescending(p => p.NumberOfFlights).ToList().FirstOrDefault(); } }
        public Plane PlaneMostTimeHours
        {
            get { return planeMostTimeHours; }
            set
            {
                planeMostTimeHours = value;
                OnPropertyChanged("PlaneMostTimeHours");
            }
        }

        private string planeInActiveString { set { } get { return Model.GetContext().Planes.Where(p => p.Active == false).ToList().Count().ToString() + " самолет"; } }
        public string PlaneInActiveString
        {
            get { return planeInActiveString; }
            set
            {
                planeInActiveString = value;
                OnPropertyChanged("PlaneMostFlyingTimeString");
            }
        }

        private string planeMostFlyingTimeString { set { } get { return PlaneMostTimeHours.ReleaseCompany + " " + PlaneMostTimeHours.Model + " - " + PlaneMostTimeHours.TailNumber + " (" + PlaneMostTimeHours.FlightHours + "ч.)"; } }
        public string PlaneMostFlyingTimeString
        {
            get { return planeMostFlyingTimeString; }
            set
            {
                planeMostFlyingTimeString = value;
                OnPropertyChanged("PlaneMostFlyingTimeString");
            }
        }
        private string planeMostFlyingHoursString { set { } get { return PlaneMostFlyingHours.ReleaseCompany+" "+ PlaneMostFlyingHours.Model + " - " + PlaneMostFlyingHours.TailNumber + " ("+ PlaneMostFlyingHours.FlightHours+"ч.)"; } }
        public string PlaneMostFlyingString
        {
            get { return planeMostFlyingHoursString; }
            set
            {
                planeMostFlyingHoursString = value;
                OnPropertyChanged("PlaneMostFlyingString");
            }
        }
        private int _flyingcount { set { } get { return Model.GetContext().Flyings.Count(); } }
        public int FlyingCount
        {
            get { return _flyingcount; }
            set
            {
                _flyingcount = value;
                OnPropertyChanged("FlyingCount");
            }
        }
        private int _directioncount { set { } get { return Model.GetContext().Directions.Count(); } }
        public int DirectionCount
        {
            get { return _directioncount; }
            set
            {
                _directioncount = value;
                OnPropertyChanged("DirectionCount");
            }
        }
        private int _ticketcount { set { } get { return Model.GetContext().Tickets.Count(); } }
        public int TicketCount
        {
            get { return _ticketcount; }
            set
            {
                _ticketcount = value;
                OnPropertyChanged("TicketCount");
            }
        }

        private int _planespagescount
        {
            set { }
            get
            {
                return (PlanesCount/7)+1;
            }
        }
        public int PlanesPagesCount
        {
            get { return _planespagescount; }
            set
            {
                _planescount = value;
                OnPropertyChanged("PlanesCount");
            }
        }

        private int _planescount { set { } get { 
                return SortPlanes(false).Count; 
            } }
        public int PlanesCount
        {
            get { return _planescount; }
            set
            {
                _planescount = value;
                OnPropertyChanged("PlanesCount");
            }
        }

        private Data.User user;
        public Data.User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        private string userName { set { } get { return User.Surname + " " + User.Name + " " + User.Patronymic; } }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = User.Surname +" "+ User.Name+" "+ User.Patronymic;
                OnPropertyChanged("UserName");
            }
        }

        private Page _currrentPage;
        public Page CurrentPage
        {
            get { return _currrentPage; }
            set
            {
                _currrentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        private Page _currrentPageAdd;
        

        #region Home
        private RelayCommand openHome;
        public RelayCommand Home { get { return openHome ?? new RelayCommand(obj => {
            CurrentPage = new UI.Pages.Home.HomePage();
        }); } }

        #endregion

        #region Flying
        private int _flyingStatus;
        public int FlyingStatus
        {
            get { return _flyingStatus; }
            set
            {
                _flyingStatus = value;
                OnPropertyChanged("FlyingStatus");
            }
        }
        private string _flyingType;
        public string FlyingType
        {
            get { return _flyingType; }
            set
            {
                _flyingType = value;
                OnPropertyChanged("FlyingType");
            }
        }

        private int flyingItemsOffset;
        public int FlyingItemsOffset
        {
            get { return flyingItemsOffset; }
            set
            {
                flyingItemsOffset = value;
                OnPropertyChanged("FlyingItemsOffset");
            }
        }

        private int flyingItemsLimit;
        public int FlyingItemsLimit
        {
            get { return flyingItemsLimit; }
            set
            {
                flyingItemsLimit = value;
                OnPropertyChanged("FlyingItemsLimit");
            }
        }

        private Flying selectedFlying;
        public Flying SelectedFlying
        {
            get {   
                return selectedFlying;
            }
            set
            {
                if (User.RoleId != 3)
                {
                    selectedFlying = value;
                    OnPropertyChanged("SelectedFlying");
                    CurrentPage = new UI.Pages.Flying.AddEdit.AddEditFlyingPage();
                }
            }
        }

        private string flyingsCount { get { return SortFlyings(false).Count + " зап."; } set { } }
        public string FlyingsCount
        {
            set
            {
                flyingsCount = SortFlyings(false).Count+" зап.";
                OnPropertyChanged("ListFlyings");
            }
            get { return flyingsCount; }
        }
        private string flyingsPagesCount { get { return Math.Ceiling(Convert.ToDecimal(SortFlyings(false).Count/5)) + " стр."; } set { } }
        public string FlyingsPagesCount
        {
            set
            {
                flyingsPagesCount = Math.Ceiling(Convert.ToDecimal(SortFlyings(false).Count / 5)) + " стр.";
                OnPropertyChanged("ListFlyings");
            }
            get { return flyingsPagesCount; }
        }
        private IList<Flying> flyings { get { return SortFlyings(true); } set { } }
        public IList<Flying> ListFlyings
        {
            set 
            {
                flyings = SortFlyings(true);
                OnPropertyChanged("ListFlyings");
            }
            get { return flyings; }
        }
        private IList<Flying> SortFlyings(bool pagina)
        {
            IList<Flying> items = new Model().Flyings.Where(p => p.TypeFlying == FlyingType).ToList();
            if (FlyingStatus == 1)
            {
                if (pagina)
                {
                    return items.Where(p => p.Completed == true).ToList().Skip(FlyingItemsOffset).Take(flyingItemsLimit).ToList();
                }
                else
                {
                    return items.Where(p => p.Completed == true).ToList();
                }
            }
            if(FlyingStatus == 2)
            {
                if (pagina)
                {
                    return items.Where(p => p.Canceled == true).ToList().Skip(FlyingItemsOffset).Take(flyingItemsLimit).ToList();
                }
                else
                {
                    return items.Where(p => p.Canceled == true).ToList();
                }
            }

            if (pagina)
            {
                return items.ToList().Skip(FlyingItemsOffset).Take(flyingItemsLimit).ToList();
            }
            else
            {
                return items.ToList();
            }

        }
        private RelayCommand canceledlying;
        public RelayCommand FlyingCanceled
        {
            get
            {
                return canceledlying ?? new RelayCommand(obj => {
                    selectedFlying = null;
                    FlyingStatus = 2;
                    CurrentPage = new UI.Pages.Flying.FlyingPage();
                });
            }
        }
        private RelayCommand completedlying;
        public RelayCommand FlyingCompleted
        {
            get
            {
                return completedlying ?? new RelayCommand(obj => {
                    selectedFlying = null;
                    FlyingStatus = 1;
                    CurrentPage = new UI.Pages.Flying.FlyingPage();
                });
            }
        }

        
        private RelayCommand openFlying;
        public RelayCommand Flying { get { return openFlying ?? new RelayCommand(obj => {
            selectedFlying = null;
            FlyingStatus = 0;
            CurrentPage = new UI.Pages.Flying.FlyingPage();
        }); } }

        private RelayCommand flyingNext;
        public RelayCommand FlyingNext
        {
            get
            {
                return flyingNext ?? new RelayCommand(obj => {
                    if (!(ListFlyings.Count < 6))
                    {
                        flyingItemsOffset += 6;
                        CurrentPage = new UI.Pages.Flying.FlyingPage();
                    }  
                });
            }
        }
        private RelayCommand flyingLast;
        public RelayCommand FlyingLast
        {
            get
            {
                return flyingLast ?? new RelayCommand(obj => {
                    if (flyingItemsOffset != 0)
                    {
                    flyingItemsOffset -= 6;
                    CurrentPage = new UI.Pages.Flying.FlyingPage();
                    }
                   
                });
            }
        }
        private RelayCommand flyingImternational;
        public RelayCommand FlyingInternational
        {
            get
            {
                return flyingImternational ?? new RelayCommand(obj => {

                    FlyingInternationalVoid();
                });
            }
        }
        public void FlyingInternationalVoid()
        {
            flyingItemsOffset = 0;
            flyingItemsLimit = 6;
            FlyingStatus = 0;
            FlyingType = "Международный";
            CurrentPage = new UI.Pages.Flying.FlyingPage();
        }
        private RelayCommand flyingInsaid;
        public RelayCommand FlyingInsaid
        {
            get
            {
                return flyingInsaid ?? new RelayCommand(obj => {

                    FlyingInsaidVoid();
                });
            }
        }
        public void FlyingInsaidVoid()
        {
            flyingItemsOffset = 0;
            flyingItemsLimit = 6;
            FlyingStatus = 0;
            FlyingType = "Внутренний";
            CurrentPage = new UI.Pages.Flying.FlyingPage();
        }

        private RelayCommand openAddEditFlying;
        public RelayCommand AddEditFlying { get { return openAddEditFlying ?? new RelayCommand(obj => {
            CurrentPage = null;
            CurrentPage = new UI.Pages.Flying.AddEdit.AddEditFlyingPage();
        }); } }

        #endregion

        #region Plane
        private RelayCommand planeActiveCommand;
        public RelayCommand PlaneActiveCommand
        {
            get
            {
                return planeActiveCommand ?? new RelayCommand(obj => {

                    PlaneActiveVoid();
                });
            }
        }
        public void PlaneActiveVoid()
        {
            planeItemsOffset = 0;
            planeItemsLimit = 6;
            PlaneActive = true;
            CurrentPage = new UI.Pages.Planes.PlanesPage();
        }

        private RelayCommand planeInActiveCommand;
        public RelayCommand PlaneInActiveCommand
        {
            get
            {
                return planeInActiveCommand ?? new RelayCommand(obj => {

                    PlaneInActiveVoid();
                });
            }
        }
        public void PlaneInActiveVoid()
        {
            planeItemsOffset = 0;
            planeItemsLimit = 6;
            PlaneActive = false;
            CurrentPage = new UI.Pages.Planes.PlanesPage();
        }

        private string _planeSearch;
        public string PlaneSearch
        {
            get { return _planeSearch; }
            set
            {
                _planeSearch = value;
                OnPropertyChanged("PlaneSearch");
            }
        }

        private bool _planeActive;
        public bool PlaneActive
        {
            get { return _planeActive; }
            set
            {
                _planeActive = value;
                OnPropertyChanged("PlaneActive");
            }
        }
        private int planeItemsOffset;
        public int PlaneItemsOffset
        {
            get { return planeItemsOffset; }
            set
            {
                planeItemsOffset = value;
                OnPropertyChanged("PlaneItemsOffset");
            }
        }

        private int planeItemsLimit;
        public int PlaneItemsLimit
        {
            get { return planeItemsLimit; }
            set
            {
                planeItemsLimit = value;
                OnPropertyChanged("PlaneItemsLimit");
            }
        }
        private RelayCommand planeNext;
        public RelayCommand PlaneNext
        {
            get
            {
                return planeNext ?? new RelayCommand(obj => {
                    if (!(ListPlanes.Count < 6))
                    {
                        planeItemsOffset += 7;
                        CurrentPage = new UI.Pages.Planes.PlanesPage();
                    }
                });
            }
        }
        private RelayCommand planeLast;
        public RelayCommand PlaneLast
        {
            get
            {
                return planeLast ?? new RelayCommand(obj => {
                    if (planeItemsOffset != 0)
                    {
                        planeItemsOffset -= 6;
                        CurrentPage = new UI.Pages.Planes.PlanesPage();
                    }

                });
            }
        }


        private Plane selectedPlanes;
        public Plane SelectedPlanes
        {
            get { return selectedPlanes; }
            set
            {
                if (User.RoleId != 2)
                {
                    selectedPlanes = value;
                    OnPropertyChanged("SelectedPlanes");
                }
            }
        }
        private IList<Plane> planes { get { return SortPlanes(true); } set { } }

        public IList<Plane> SortPlanes(bool pagina)
        {
            IList<Plane> item = Model.GetContext().Planes.Where(p => p.Active == PlaneActive).ToList();
            if (!string.IsNullOrEmpty(PlaneSearch))
            {
                item = item.Where(p => p.TailNumber.ToLower().Contains(PlaneSearch.ToLower())).ToList();
            }
            if (pagina)
            {

                return item.Skip(PlaneItemsOffset).Take(PlaneItemsLimit).ToList();
            }
            else
            {
                return item.ToList();
            }

        }
       
        public IList<Plane> ListPlanes
        {
            set
            {
                planes = value;
                OnPropertyChanged("ListPlanes");
            }
            get { return planes; }
        }
        private RelayCommand searchPlanes;
        public RelayCommand PlanesSearchCommand
        {
            get
            {
                return searchPlanes ?? new RelayCommand(obj => {
                    planes = SortPlanes(true);
                    PlaneItemsOffset = 0;
                    PlaneItemsLimit = 7;
                    SelectedPlanes = null;
                    CurrentPage = new UI.Pages.Planes.PlanesPage();
                });
            }
        }
        private RelayCommand openPlanes;
        public RelayCommand Planes { get { return openPlanes ?? new RelayCommand(obj => {
            CurrentPage = new UI.Pages.Planes.PlanesPage();
            SelectedPlanes = null;
        }); } }
        private RelayCommand openAddEditPlanes;
        public RelayCommand AddEditPlanes
        {
            get
            {
                return openAddEditPlanes ?? new RelayCommand(obj => {
                    CurrentPage = new UI.Pages.Planes.AddEdit.AddEditPlanesPage();
                });
            }
        }
        #endregion

        #region Airports
        private Airport selectedAirport;
        public Airport SelectedAirport
        {
            get { return selectedAirport; }
            set
            {
                selectedAirport = value;
                OnPropertyChanged("SelectedAirport");
            }
        }
        private RelayCommand searchAirports;
        public RelayCommand AirportsSearchCommand
        {
            get
            {
                return searchAirports ?? new RelayCommand(obj => {
                    airports = SortAirports();
                    AirporItemsOffset = 0;
                    AirportItemsLimit = 7;
                    CurrentPage = new UI.Pages.Airports.AirportsPage();
                });
            }
        }
        private string _airportSearch;
        public string AirportSearch
        {
            get { return _airportSearch; }
            set
            {
                _airportSearch = value;
                OnPropertyChanged("AirportSearch");
            }
        }
        private int airportItemsOffset;
        public int AirporItemsOffset
        {
            get { return airportItemsOffset; }
            set
            {
                airportItemsOffset = value;
                OnPropertyChanged("AirporItemsOffset");
            }
        }

        private int airportItemsLimit;
        public int AirportItemsLimit
        {
            get { return airportItemsLimit; }
            set
            {
                airportItemsLimit = value;
                OnPropertyChanged("AirportItemsLimit");
            }
        }
        private RelayCommand airportNext;
        public RelayCommand AirportNext
        {
            get
            {
                return airportNext ?? new RelayCommand(obj => {
                    if (!(ListAirports.Count < 6))
                    {
                        airportItemsOffset += 6;
                        CurrentPage = new UI.Pages.Airports.AirportsPage();
                    }



                });
            }
        }
        private RelayCommand airportLast;
        public RelayCommand AirportLast
        {
            get
            {
                return airportLast ?? new RelayCommand(obj => {
                    if (airportItemsOffset != 0)
                    {
                        airportItemsOffset -= 6;
                        CurrentPage = new UI.Pages.Airports.AirportsPage();
                    }

                });
            }
        }
        private IList<Airport> airports { get { return SortAirports();  } set { } }
        public IList<Airport> SortAirports()
        {
            IList<Airport> item = Model.GetContext().Airports.ToList();
            if (!string.IsNullOrEmpty(AirportSearch))
            {
                item = item.Where(p => p.Country.ToLower().Contains(AirportSearch.ToLower())).ToList();
            }
            return item.Skip(AirporItemsOffset).Take(AirportItemsLimit).ToList();
        }
        public IList<Airport> ListAirports
        {
            set
            {
                airports = value;
                OnPropertyChanged("ListAirports");
            }
            get { return airports; }
        }
        private RelayCommand openAirports;
        public RelayCommand Airports { get { return openAirports ?? new RelayCommand(obj => {
            CurrentPage = new UI.Pages.Airports.AirportsPage();
        }); } }

        #endregion

        #region Directions
        private bool _directionActive;
        public bool DirectionActive
        {
            get { return _directionActive; }
            set
            {
                _directionActive = value;
                OnPropertyChanged("DirectionActive");
            }
        }
        private RelayCommand directionActiveCommand;
        public RelayCommand DirectionsActiveCommand
        {
            get
            {
                return directionActiveCommand ?? new RelayCommand(obj => {

                    DirectionsActiveVoid();
                });
            }
        }
        public void DirectionsActiveVoid()
        {
            directionsItemsOffset = 0;
            directionsItemsLimit = 7;
            DirectionActive = true;
            CurrentPage = new UI.Pages.Directions.DirectionsPage();
        }

        private RelayCommand directionInActiveCommand;
        public RelayCommand DirectionsInActiveCommand
        {
            get
            {
                return directionInActiveCommand ?? new RelayCommand(obj => {

                    DirectionsInActiveVoid();
                });
            }
        }
        public void DirectionsInActiveVoid()
        {
            directionsItemsOffset = 0;
            directionsItemsLimit = 7;
            DirectionActive = false;
            CurrentPage = new UI.Pages.Directions.DirectionsPage();
        }

        private RelayCommand directionNext;
        public RelayCommand DirectionNext
        {
            get
            {
                return directionNext ?? new RelayCommand(obj => {
                    if (!(ListDirections.Count < 6))
                    {
                        DirectionsItemsOffset += 6;
                        CurrentPage = new UI.Pages.Directions.DirectionsPage();
                    }



                });
            }
        }
        private RelayCommand directionLast;
        public RelayCommand DirectionLast
        {
            get
            {
                return directionLast ?? new RelayCommand(obj => {
                    if (directionsItemsOffset != 0)
                    {
                        directionsItemsOffset -= 6;
                        CurrentPage = new UI.Pages.Directions.DirectionsPage();
                    }

                });
            }
        }
        private int directionsItemsOffset;
        public int DirectionsItemsOffset
        {
            get { return directionsItemsOffset; }
            set
            {
                directionsItemsOffset = value;
                OnPropertyChanged("DirectionsItemsOffset");
            }
        }

        private int directionsItemsLimit;
        public int DirectionsItemsLimit
        {
            get { return directionsItemsLimit; }
            set
            {
                directionsItemsLimit = value;
                OnPropertyChanged("DirectionsItemsLimit");
            }
        }

        private Airport selectedDirections;
        public Airport SelectedDirections
        {
            get { return selectedDirections; }
            set
            {
                selectedDirections = value;
                OnPropertyChanged("SelectedDirections");
            }
        }
        private IList<Direction> directions { get { return Model.GetContext().Directions.Where(p => p.Active == DirectionActive).ToList().Skip(DirectionsItemsOffset).Take(DirectionsItemsLimit).ToList(); } set { } }
        public IList<Direction> ListDirections
        {
            set
            {
                directions = value;
                OnPropertyChanged("ListDirections");
            }
            get { return directions; }
        }

        private RelayCommand openDirections;
        public RelayCommand Directions
        {
            get
            {
                return openDirections ?? new RelayCommand(obj => {
                    CurrentPage = new UI.Pages.Directions.DirectionsPage();
                });
            }
        }
        private RelayCommand openAddEditDirections;
        public RelayCommand AddEditDirections
        {
            get
            {
                return openAddEditDirections ?? new RelayCommand(obj => {
                   // CurrentPage = new UI.Pages.Directions.AddEdit.AddEditDirectionPage();
                });
            }
        }
        #endregion

        #region Settings
        private RelayCommand openSettings;
        public RelayCommand Settings
        {
            get
            {
                return openSettings ?? new RelayCommand(obj => {
                   CurrentPage = new UI.Pages.Settings.SettingsPage();
                });
            }
        }
        #endregion

        #region Users
        private bool _userStatus;
        public bool UserStatus
        {
            get { return _userStatus; }
            set
            {
                _userStatus = value;
                OnPropertyChanged("UserStatus");
            }
        }

        private int _userItemsOffset;
        public int UsersItemsOffset
        {
            get { return _userItemsOffset; }
            set
            {
                _userItemsOffset = value;
                OnPropertyChanged("UsersItemsOffset");
            }
        }

        private int _userItemsLimit;
        public int UserItemsLimit
        {
            get { return _userItemsLimit; }
            set
            {
                _userItemsLimit = value;
                OnPropertyChanged("UserItemsLimit");
            }
        }

        private List<Country> _citizenshipsList { get { return Model.GetContext().Countries.ToList(); } set { } }
        public List<Country> CitizenshipsList
        {
            get { return _citizenshipsList; }
            set
            {
                _citizenshipsList = value;
                OnPropertyChanged("CitizenshipsList");
            }
        }


        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
                CurrentPage = new UI.Pages.Users.AddEdit.AddEditUserPage();
            }
        }
        private int _userscount { get { return SortUsers(false).Count; } set { } }
        public int UsersCount
        {
            get { return _userscount; }
            set
            {
                _userscount = value;
                OnPropertyChanged("UsersCount");
            }
        }

        private int _userspagescount { get { return (SortUsers(false).Count/7)+1; } set { } }
        public int UsersPagesCount
        {
            get { return _userspagescount; }
            set
            {
                _userspagescount = value;
                OnPropertyChanged("UsersPagesCount");
            }
        }
        private IList<User> users { get { return SortUsers(true); } set { } }
        public IList<User> ListUsers
        {
            set
            {
                users = SortUsers(true);
                OnPropertyChanged("ListUsers");
            }
            get { return users; }
        }
        private IList<User> SortUsers(bool pagina)
        {
            IList<User> items = new Model().Users.Where(p => p.Active == UserStatus && p.RoleId == 2).ToList();
            if (pagina)
            {
                return items.ToList().Skip(_userItemsOffset).Take(_userItemsLimit).ToList();
            }
            else
            {
                return items.ToList();
            }

        }
        
        private RelayCommand openUsers;
        public RelayCommand Users
        {
            get
            {
                if (user.RoleId != 3)
                {
                    return openUsers ?? new RelayCommand(obj => {
                        selectedUser = null;
                        CurrentPage = new UI.Pages.Users.UsersPage();
                    });
                }
                else
                {
                    return null;
                }
               
            }
        }

        private RelayCommand usersNext;
        public RelayCommand UsersNext
        {
            get
            {
                return usersNext ?? new RelayCommand(obj => {
                    if (!(ListUsers.Count < 6))
                    {
                        _userItemsOffset += 6;
                        CurrentPage = new UI.Pages.Users.UsersPage();
                    }
                });
            }
        }
        private RelayCommand usersLast;
        public RelayCommand UsersLast
        {
            get
            {
                return usersLast ?? new RelayCommand(obj => {
                    if (UsersItemsOffset != 0)
                    {
                        _userItemsOffset -= 6;
                        CurrentPage = new UI.Pages.Users.UsersPage();
                    }

                });
            }
        }
       
        private RelayCommand openAddEditUsers;
        public RelayCommand AddEditUsers
        {
            get
            {
                return openAddEditUsers ?? new RelayCommand(obj => {
                    CurrentPage = null;
                    CurrentPage = new UI.Pages.Users.AddEdit.AddEditUserPage();
                });
            }
        }
        private RelayCommand userActive;
        public RelayCommand UserActive
        {
            get
            {
                return userActive ?? new RelayCommand(obj => {

                    UserActiveVoid();
                });
            }
        }
        public void UserActiveVoid()
        {
            _userItemsOffset = 0;
            _userItemsLimit = 6;
            _userStatus = true;
            CurrentPage = new UI.Pages.Users.UsersPage();
        }
        private RelayCommand userInActive;
        public RelayCommand UserInActive
        {
            get
            {
                return userInActive ?? new RelayCommand(obj => {

                    UserInActiveVoid();
                });
            }
        }
        public void UserInActiveVoid()
        {
            _userItemsOffset = 0;
            _userItemsLimit = 6;
            _userStatus = false;
            CurrentPage = new UI.Pages.Users.UsersPage();
        }
        #endregion

        #region Ticket
        private RelayCommand addItem;
        public RelayCommand AddItem
        {
            get
            {
                return addItem ?? new RelayCommand(obj =>
                {
                    Ticket ticket = obj as Ticket;
                    ticket.UserId = StartViewModel.ViewModel.SelectedUser.Id;
                    ticket.DateSale = DateTime.Now;
                    Model.GetContext().Tickets.Add(ticket);
                    Model.GetContext().SaveChanges();
                    MessageBox.Show("Билет создан");
                });
            }
        }


        #endregion
        public StartViewModel()
        {
            CurrentPage = new UI.Pages.Home.HomePage();
            flyingItemsLimit = 6;
            flyingItemsOffset = 0;
            planeItemsLimit = 7;
            planeItemsOffset = 0;
            airportItemsLimit = 7;
            airportItemsOffset = 0;
            FlyingType = "Международный";
            PlaneActive = true;
            directionsItemsLimit = 7;
            directionsItemsOffset = 0;
            DirectionActive = true;
            UserItemsLimit = 7;
            UsersItemsOffset = 0;
            UserStatus = true;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
