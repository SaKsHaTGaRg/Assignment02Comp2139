using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Assignment02Comp2139.Areas.Management.Models;

namespace Assignment02Comp2139.Areas.Management.Models;

public class Category
{
    [Key] public int CategoryId { get; set; }

    [Required(ErrorMessage = "Category Name is required")]
    [StringLength(100, ErrorMessage = "Category Name can't be longer than 100 characters")]
    [MinLength(5, ErrorMessage = "Category Name should have at least 5 characters")]
    public string CategoryName { get; set; }

    [StringLength(500, ErrorMessage = "Category Description can't be longer than 500 characters")]
    public string? CategoryDescription { get; set; }

    [JsonIgnore] public virtual ICollection<Product>? Products { get; set; }
}