using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models;

public class Product
{
    public int id {get;set;}
    [Required]
    public string? name {get;set;}
    public decimal price {get;set;}
    public string describt
}
