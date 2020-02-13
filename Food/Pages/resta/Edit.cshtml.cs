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
        public Restauran restaurant;
        public IEnumerable<SelectListItem> cusines;

        public EditModel(IFoodData iFoodData,IHtmlHelper html)
        {
            this.iFoodData = iFoodData;
            this.html = html;
        }

        public ActionResult OnGet(int restaurantId)
        {
            restaurant = iFoodData.getById(restaurantId);
            cusines = html.GetEnumSelectList<typeCusinet>();
            if (restaurant == null)
            {
                return RedirectToPage("./notFound");
            }
            return Page();
        }
    }
}