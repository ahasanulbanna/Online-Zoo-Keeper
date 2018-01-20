using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        ZooContext db = new ZooContext();
        public List<ViewFood> getAll()
        {

            List<Food> foods = db.Foods.ToList();
            var viewFoods = new List<ViewFood>();
            foreach (Food l in foods)
            {
                ViewFood viewFood = new ViewFood()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Price =l.Price
                    
                };
                viewFoods.Add(viewFood);
            }
            return viewFoods;
        }

        public bool Save(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
            return true;
        }

        public Food GetDbModel(int id)
        {
            return db.Foods.Find(id);
        }

        public ViewFood Get(int id)
        {

            Food food = db.Foods.Find(id);
            return new ViewFood()
            {
                Id=food.Id,
                Name=food.Name,
                Price=food.Price

            };
        }

        public bool Delete(Food food)
        {
            Food dbAnimal = db.Foods.Find(food.Id);
            db.Foods.Remove(dbAnimal);
            db.SaveChanges();
            return true;
        }

        public bool update(Food animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}
