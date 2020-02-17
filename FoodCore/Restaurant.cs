using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FoodCore.restaurantCore;

namespace FoodCore
{
    public partial class Restauran
    {
        [Required]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String locationn { get; set; }
        [Required]
        public typeCusinet type { get; set; }

    }
}
