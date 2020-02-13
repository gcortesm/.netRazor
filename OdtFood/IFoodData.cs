using FoodCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OdtFood
{
    public interface IFoodData
    {
        IEnumerable<Restauran> getAll();
        IEnumerable<Restauran> getByName(String str);
        Restauran getById(int id);
    }


    public class InMemorialData : IFoodData
    {
        List<Restauran> restaurant = new List<Restauran>() {
            new Restauran{ id=1,name="Chingon",locationn="Florencia York",type=restaurantCore.typeCusinet.Latina },
            new Restauran{ id=2,name="Re Sede 1",locationn="Florencia York",type=restaurantCore.typeCusinet.Latina },
            new Restauran{ id=3,name="Triple Sede 2",locationn="Florencia York",type=restaurantCore.typeCusinet.Latina },

        };


        public IEnumerable<Restauran> getAll()
        {
            return from r in restaurant
                   orderby r.id
                   select r;
        }

        public Restauran getById(int id)
        {
            return restaurant.FirstOrDefault(c => c.id == id);
        }

        public IEnumerable<Restauran> getByName(string str)
        {
            return from r in restaurant
                   where string.IsNullOrEmpty(str) || r.name.StartsWith(str)
                   orderby r.name
                   select r;
        }
    }
}
