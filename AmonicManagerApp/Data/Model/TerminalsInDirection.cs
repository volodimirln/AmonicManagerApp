namespace AmonicManagerApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TerminalsInDirection
    {
        public int Id { get; set; }

        public int TerminalId { get; set; }

        [Required]
        [StringLength(150)]
        public string TypeLandings { get; set; }

        public int DirectionId { get; set; }

        public virtual Direction Direction { get; set; }

        public virtual Terminal Terminal { get; set; }
    }
}
