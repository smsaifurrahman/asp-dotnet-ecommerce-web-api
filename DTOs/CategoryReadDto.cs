using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_dotnet_ecommerce_web_api.DTOs
{
    public class CategoryReadDto
    {
        public Guid CategoryId { get; set; }
        public String? Name { get; set; }
        public String? Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

    }
}