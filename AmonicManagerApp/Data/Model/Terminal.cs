namespace AmonicManagerApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Terminal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Terminal()
        {
            TerminalsInDirections = new HashSet<TerminalsInDirection>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Type { get; set; }

        public int AiroportId { get; set; }

        [Required]
        [StringLength(150)]
        public string TypeReception { get; set; }

        public virtual Airport Airport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TerminalsInDirection> TerminalsInDirections { get; set; }
    }
}
