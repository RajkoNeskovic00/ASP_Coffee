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
    public class DeleteOrigin : IdeleteOrigin
    {
        private readonly Coffee_Context _context;

        public DeleteOrigin(Coffee_Context context)
        {
            _context = context;
        }

        public int id => 8;

        public string Name => "Deleting choosen coffee origin.";

        public void Execute(int request)
        {
            var origin = _context.Origins.Find(request);

            if (origin == null)
            {
                throw new EntityNotFound(typeof(Origin));
            }

            origin.DeleteAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
