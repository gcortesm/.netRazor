using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdtFood;

namespace Food.Pages.resta
{
    public class indexModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IFoodData iFoodData;

        public String message { get; set; }
        public IEnumerable<Restauran> Restaureants { get; set; }

        [BindProperty (SupportsGet =true)]
        public string SearchParam { get; set; }


        public indexModel(IConfiguration configuration,IFoodData iFoodData)
        {
            this.configuration = configuration;
            this.iFoodData = iFoodData;
        }


        public void OnGet()
        {
            message = "Hello World";
         
            Restaureants = iFoodData.getByName(SearchParam);
        }
    }
}