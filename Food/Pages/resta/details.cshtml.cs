using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdtFood;

namespace Food.Pages.resta
{
    public class detailsModel : PageModel
    {

        public  Restauran restaurant { get; set; }
        public IFoodData IFoodData { get; }

        public detailsModel(IFoodData iFoodData)
        {
            IFoodData = iFoodData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = IFoodData.getById(restaurantId);
            if (restaurant == null)
            {
                return RedirectToPage("./notFound");
            }
            return Page();
        }
    }
}