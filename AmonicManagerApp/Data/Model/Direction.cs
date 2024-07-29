namespace AmonicManagerApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Direction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direction()
        {
            Flyings = new HashSet<Flying>();
            TerminalsInDirections = new HashSet<TerminalsInDirection>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [NotMapped]
        public Terminal TerminalDeparture { set { } get { return Model.GetContext().TerminalsInDirections.FirstOrDefault(p => p.Direction.Id == Id && p.TypeLandings == "Отправление").Terminal; } }

        [NotMapped]
        public Terminal TerminalArrival { set { } get { return Model.GetContext().TerminalsInDirections.FirstOrDefault(p => p.Direction.Id == Id && p.TypeLandings == "Прибытие").Terminal; } }
        [NotMapped]
        public string way { get { return TerminalDeparture.Airport.City+", " + TerminalDeparture.Airport.Country+" ("+ TerminalDeparture.Airport.Code + ") > (" + TerminalArrival.Airport.Code+") "+" "+ TerminalArrival.Airport.City +", "+ TerminalArrival.Airport.Country + " N"+Id; } }

        public int FlightTime { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flying> Flyings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TerminalsInDirection> TerminalsInDirections { get; set; }
    }
}
