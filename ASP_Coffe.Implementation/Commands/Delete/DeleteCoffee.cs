using ASP_Coffee.Application.Command.Delete;
using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Commands.Delete
{
    public class DeleteCoffee : IDeleteCoffee
    {
        private readonly Coffee_Context _context;

        public DeleteCoffee(Coffee_Context context)
        {
            _context = context;
        }

        public int id => 16;

        public string Name => "Deleting choosen coffee";

        public void Execute(int request)
        {
            var coffee = _context.Coffees.Find(request);

            if (coffee == null)
            {
                throw new EntityNotFound(typeof(Coffee));
            }

            coffee.DeleteAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
