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
    public class DeleteAmount : IDeleteAmount
    {
        private readonly Coffee_Context _context;

        public DeleteAmount(Coffee_Context context)
        {
            _context = context;
        }

        public int id => 12;

        public string Name => "Deleting choosen pack amount.";

        public void Execute(int request)
        {
            var amount = _context.Amounts.Find(request);

            if (amount == null)
            {
                throw new EntityNotFound(typeof(Amount));
            }

            amount.DeleteAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
