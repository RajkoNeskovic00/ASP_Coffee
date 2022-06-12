using ASP_Coffee.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.Interfaces.Email
{
    public interface IEmail
    {
        void Send(EmailSendDto dto);
    }
}
