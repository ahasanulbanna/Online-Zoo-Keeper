using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ZooApp.Models
{
    public class ZooContext : DbContext
    {
        public ZooContext() : base("ZooContext")
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<AnimalFood> AnimalFoods { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
