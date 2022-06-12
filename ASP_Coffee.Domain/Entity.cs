using System;

namespace ASP_Coffee.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
