using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models;

public class Product
{
    public int id {get;set;}
    [Required]
    [MinLength(3)]
    [MaxLength(10)]
    public string name {get;set;}
    [Range(1,10000)]
    public decimal price {get;set;}
    public string description {get;set;}

    public string? image {get;set;}
    public double rate {get;set;}

        [Display(Name ="Cat")]
    public int CategoryId {get;set;}
    public Category Category {get;set;}
}
