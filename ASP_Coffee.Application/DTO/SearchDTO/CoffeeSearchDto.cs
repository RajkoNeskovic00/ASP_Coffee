using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.DTO
{
    public class CoffeeSearchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AmountCoffeePriceDto> Amounts { get; set; } = new List<AmountCoffeePriceDto>();
    }
}
