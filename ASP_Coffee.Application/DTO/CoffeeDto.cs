using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.DTO
{
    public class CoffeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public int BeanId { get; set; }
        public int OriginId { get; set; }
        public IEnumerable<AmountCoffeeDto> CoffeeAmounts { get; set; } = new List<AmountCoffeeDto>();
    }

    public class AmountCoffeeDto
    {
        public int AmountId { get; set; }
        public decimal Price { get; set; }
    }
}
