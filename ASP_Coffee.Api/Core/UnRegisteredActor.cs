using ASP_Coffee.Application.Interfaces;
using System.Collections.Generic;

namespace ASP_Coffee.Api.Core
{
    public class UnRegisteredActor : IApplicationActor
    {
        public int Id => 0;

        public string Email => "Unknown actor";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 5, 9, 13, 21 };
    }
}
