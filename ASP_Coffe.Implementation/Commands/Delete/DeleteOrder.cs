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
    public class DeleteOrder : IDeleteOrder
    {
        private readonly Coffee_Context _context;

        public DeleteOrder(Coffee_Context context)
        {
            _context = context;
        }

        public int id => 19;

        public string Name => "Deleting choosen order.";

        public void Execute(int request)
        {
            var order = _context.Orders.Find(request);

            if (order == null)
            {
                throw new EntityNotFound(typeof(Order));
            }

            order.DeleteAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
