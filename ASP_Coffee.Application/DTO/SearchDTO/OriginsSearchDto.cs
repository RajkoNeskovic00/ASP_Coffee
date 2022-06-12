using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.DTO
{
    public class OriginsSearchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CoffeeSearchDto> Coffees { get; set; } = new List<CoffeeSearchDto>();
    }
}
