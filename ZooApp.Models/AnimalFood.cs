using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooApp.Models
{
    public class AnimalFood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        [ForeignKey("Food")]
        public int FoodId { get; set; }
        public virtual Food Food { get; set; }
        [Required]
        public double Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
         
}
