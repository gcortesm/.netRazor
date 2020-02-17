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

        Restauran update(Restauran restaurant);
        int commit();

        Restauran save(Restauran newRestaurant);


    }


    public class InMemorialData : IFoodData
    {
         readonly List<Restauran> restaurant;

        public InMemorialData()
        {
            restaurant = new List<Restauran>() {
            new Restauran{ id=1,name="Chingon",locationn="Florencia York",type=restaurantCore.typeCusinet.Latina },
            new Restauran{ id=2,name="Re Sede 1",locationn="Florencia York",type=restaurantCore.typeCusinet.Latina },
            new Restauran{ id=3,name="Triple Sede 2",locationn="Florencia York",type=restaurantCore.typeCusinet.Latina },
            };
        }

        public int commit()
        {
            return 1;
        }

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

        public Restauran save(Restauran newRestaurant)
        {
            restaurant.Add(newRestaurant);
            newRestaurant.id = restaurant.Max(c => c.id) + 1;
            return newRestaurant;
        }

        public Restauran update(Restauran rest)
        {
            var restaurante = restaurant.FirstOrDefault(c=> c.id==rest.id);
            if (restaurante!=null)
            {
                restaurante.name = rest.name;
                restaurante.locationn = rest.locationn;
                restaurante.type = rest.type;
            }
            return restaurante;
        }
    }
}
