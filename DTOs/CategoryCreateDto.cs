using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_dotnet_ecommerce_web_api.DTOs
{
    public class CategoryCreateDto
    {   
    [Required(ErrorMessage = "Category Name is required")]    
    public String? Name { get; set; }
    public String? Description { get; set; } = string.Empty; 
    }
}