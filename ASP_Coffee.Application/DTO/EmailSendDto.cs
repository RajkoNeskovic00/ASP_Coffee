using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.DTO
{
    public class EmailSendDto
    {
        public string SentTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
