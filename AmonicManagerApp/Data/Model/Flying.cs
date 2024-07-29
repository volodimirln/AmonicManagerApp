namespace AmonicManagerApp.Data
{
    using AmonicManagerApp.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows;

    [Table("Flying")]
    public partial class Flying
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flying()
        {
            Pricings = new HashSet<Pricing>();
        }
        [NotMapped]
        public string DateTimeDepartureString { get; set; }
        [NotMapped]
        public string DateTimeArrivalString { get; set; }
        public int Id { get; set; }

        public string FlyingNumber { get; set; }

        public int PlaneId { get; set; }

        public int DirectonId { get; set; }

        public int NumberOfSeats { get; set; }

        [Required]
        [StringLength(150)]
        public string TypeFlying { get; set; }

        [Required]
        [StringLength(150)]
        public string Restrictions { get; set; }

        public bool Completed { get; set; }

        public bool Canceled { get; set; }


        public DateTime FlyingDate { get; set; }
        public DateTime DateTimeDeparture { get; set; }
        public DateTime DateTimeArrival { get; set; }

        public virtual Direction Direction { get; set; }

        public virtual Plane Plane { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pricing> Pricings { get; set; }
        [NotMapped]
        public string DirectionFlyingTime { get { return Direction.FlightTime.ToString() + " мин."; } set { } } 

        [NotMapped]
        public Terminal TerminalDeparture { set { } get { return Model.GetContext().TerminalsInDirections.FirstOrDefault(p => p.Direction.Id == DirectonId && p.TypeLandings == "Отправление").Terminal; } }
        
        [NotMapped]
        public Terminal TerminalArrival { set { } get { return Model.GetContext().TerminalsInDirections.FirstOrDefault(p => p.Direction.Id == DirectonId && p.TypeLandings == "Прибытие").Terminal; } }
        [NotMapped]
        public string way { get { return TerminalDeparture.Airport.Code +" > "+ TerminalArrival.Airport.Code; } }
        [NotMapped]
        public string PlaceDeparture  { get { return TerminalDeparture.Airport.City + ", TER "+ TerminalDeparture.Title; } }
        [NotMapped]
        public string PlaceArrival  { get { return TerminalArrival.Airport.City + ", TER " + TerminalArrival.Title; } }
        [NotMapped]
        public string PlaneStrins { get { return "Самолет: "+ Plane.ReleaseCompany +" "+ Plane.Model + " ("+ Plane.TailNumber+")"; } }

        [NotMapped]
        public string TimeDeparture { get { return DateTimeDeparture.ToString("HH:mm"); } }
        [NotMapped]
        public string TimeArrival { get { return DateTimeArrival.ToString("HH:mm"); } }

        [NotMapped]
        public string Info { get { return FlyingNumber + ". " + TimeDeparture + " - " + TerminalDeparture.Airport.Country + ", " + TerminalDeparture.Airport.City + way + " " + TerminalArrival.Airport.Country + ", " + TerminalArrival.Airport.City; } }



        private RelayCommand addItem;
        public RelayCommand AddItem
        {
            get
            {
                return addItem ?? new RelayCommand(obj => {
                    Flying item = (Flying)obj;
                    if (!string.IsNullOrEmpty(item.PlaceArrival) && !string.IsNullOrEmpty(item.PlaceDeparture) 
                    && !string.IsNullOrEmpty(item.PlaneId.ToString()) && !string.IsNullOrEmpty(item.DirectonId.ToString()) 
                    && !string.IsNullOrEmpty(item.TypeFlying) && !string.IsNullOrEmpty(item.Restrictions))
                    {
                        try
                        {
                            if (item.Id == 0)
                            {
                                item.Canceled = false;
                                item.Completed = false;
                            }
                         
                            item.FlyingDate = DateTime.Today;
                            Model.GetContext().Flyings.AddOrUpdate((Flying)item);
                            Model.GetContext().SaveChanges();
                            MessageBox.Show("Сохранено");
                            StartViewModel.ViewModel.CurrentPage = new UI.Pages.Flying.FlyingPage();
                        }
                        catch { MessageBox.Show("Ошибка"); }
                    }
                    else
                    {
                        MessageBox.Show("Не все поля заполнены");
                    }
                    
                });
            }
        }
    }
}
