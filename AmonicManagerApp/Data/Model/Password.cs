namespace AmonicManagerApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Password
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(300)]
        public string HashPassword { get; set; }

        public DateTime AddDate { get; set; }

        public bool Active { get; set; }

        public virtual User User { get; set; }
    }
}
