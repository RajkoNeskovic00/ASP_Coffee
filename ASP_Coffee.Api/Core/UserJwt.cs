using ASP_Coffee.Application.Interfaces;
using System.Collections.Generic;

namespace ASP_Coffee.Api.Core
{
    public class UserJwt : IApplicationActor
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
