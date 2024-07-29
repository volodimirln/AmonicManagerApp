namespace AmonicManagerApp.Data
{
    using AmonicManagerApp.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows;

    [Table("Pricing")]
    public partial class Pricing
    {
        public Pricing()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public int FlyingId { get; set; }

        [Required]
        [StringLength(50)]
        public string Class { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Place { get; set; }

        public virtual Flying Flying { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }

        [NotMapped]
        public string Info { get { return Flying.FlyingNumber + ". "+ Flying.TimeDeparture +" - " + Flying.TerminalDeparture.Airport.Country+", "+ Flying.TerminalDeparture.Airport.City + Flying.way + " " + Flying.TerminalArrival.Airport.Country + ", " + Flying.TerminalArrival.Airport.City + " "+ Price+ "₽"; } }

        private RelayCommand addItem;
        public RelayCommand AddItem
        {
            get
            {
                return addItem ?? new RelayCommand(obj =>
                {
                    try
                    {
                        Pricing item = obj as Pricing;
                        item.FlyingId = item.Flying.Id;
                        Model.GetContext().Pricings.Add(item);
                        Model.GetContext().SaveChanges();
                        MessageBox.Show("Места созданы");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка");
                    }
                });
            }
        }
        }
}
