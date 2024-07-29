namespace AmonicManagerApp.Data
{
    using AmonicManagerApp.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Windows;

    public partial class Plane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plane()
        {
            Flyings = new HashSet<Flying>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string TailNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [StringLength(150)]
        public string Type { get; set; }

        [NotMapped]
        public string Name { get { return ReleaseCompany + " " + Model + " (" + TailNumber + ")"; } set { } }

        public int NumberOfFlights { get; set; }

        public int FlightHours { get; set; }

        [Required]
        [StringLength(150)]
        public string ReleaseCompany { get; set; }

        [Required]
        [StringLength(150)]
        public string Model { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flying> Flyings { get; set; }


        private RelayCommand addItem;
        public RelayCommand AddItem
        {
            get
            {
                return addItem ?? new RelayCommand(obj =>
                {
                    Plane item = (Plane)obj;
                    if (!string.IsNullOrEmpty(item.TailNumber) && !string.IsNullOrEmpty(item.DateOfIssue.ToLongDateString())
                    && !string.IsNullOrEmpty(item.Type) && !string.IsNullOrEmpty(item.NumberOfFlights.ToString())
                    && !string.IsNullOrEmpty(item.FlightHours.ToString()) && !string.IsNullOrEmpty(item.ReleaseCompany)
                    && !string.IsNullOrEmpty(item.Model))
                    {
                        try
                        {
                            
                            Data.Model.GetContext().Planes.AddOrUpdate((Plane)item);
                            Data.Model.GetContext().SaveChanges();
                            
                            MessageBox.Show("Сохранено");
                            StartViewModel.ViewModel.CurrentPage = new UI.Pages.Planes.PlanesPage();
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
