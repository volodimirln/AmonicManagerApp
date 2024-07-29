using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmonicManagerApp.Data
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public string Code { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
