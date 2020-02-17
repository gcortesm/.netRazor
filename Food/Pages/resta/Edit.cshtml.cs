using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdtFood;
using static FoodCore.restaurantCore;

namespace Food.Pages.resta
{
    public class EditModel : PageModel
    {
        private readonly IFoodData iFoodData;
        private readonly IHtmlHelper html;
       
        [BindProperty]
        public Restauran restaurant { get; set; }
        
        public IEnumerable<SelectListItem> cusines { get; set; }

        public EditModel(IFoodData iFoodData,IHtmlHelper html)
        {
            this.iFoodData = iFoodData;
            this.html = html;
        }

        public IActionResult OnGet(int restaurantId)
        {
            if (restaurantId > 0)
            {
                restaurant = iFoodData.getById(restaurantId);
                cusines = html.GetEnumSelectList<typeCusinet>();
                if (restaurant == null)
                {
                    return RedirectToPage("./notFound");
                }
            }
            else
            {
                restaurant = new Restauran();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                cusines = html.GetEnumSelectList<typeCusinet>();
                return Page();
            }

            if (restaurant.id > 0)
            {
                restaurant = iFoodData.update(restaurant);
            }
            else
            {
                restaurant = iFoodData.save(restaurant);
            }
            iFoodData.commit();
            return RedirectToPage("./details", new { restaurantId = restaurant.id });
        }
    }
}