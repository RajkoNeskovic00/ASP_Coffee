using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.DTO
{
    public class UseCaseLogDto
    {
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public DateTime UseCaseDate { get; set; }
    }
}
