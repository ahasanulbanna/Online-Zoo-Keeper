using System;
using System.ComponentModel.DataAnnotations;
using ZooApp.Models;

namespace ZooApp.ViewModels
{
    public class ViewFoodTotal
    {
        public ViewFoodTotal()
        {

        }
        public ViewFoodTotal(AnimalFood animalFood)
        {
            FoodName = animalFood.Food.Name;
            FoodPrice = animalFood.Food.Price;
            TotalQuantity = animalFood.Animal.Quantity * animalFood.Quantity;
            TotalPrice = FoodPrice * TotalQuantity;
            Date = animalFood.Date;
        }
        [Display(Name ="Food Name")]
        public string FoodName { get;  set; }
        [Display(Name = "Food Price")]
        public double FoodPrice { get; set; }
        [Display(Name = "Total Quantity")]
        public double TotalQuantity { get; set; }
        [Display(Name = "Total Price")]
        public double TotalPrice { get;set; }
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
