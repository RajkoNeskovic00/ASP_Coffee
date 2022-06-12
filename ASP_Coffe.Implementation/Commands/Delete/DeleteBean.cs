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
    public class DeleteBean : IDeleteBean
    {
        private readonly Coffee_Context _context;

        public DeleteBean(Coffee_Context context)
        {
            _context = context;
        }

        public int id => 4;

        public string Name => "Deleting specific type of coffee bean.";

        public void Execute(int request)
        {
            var bean = _context.Beans.Find(request);

            if (bean == null)
            {
                throw new EntityNotFound(typeof(Bean));
            }

            bean.DeleteAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
