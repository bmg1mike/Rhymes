using Persistence;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UnitOfWork
    {
        public IBookRepository Book { get; set; }
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task save()
        {
           await  _context.SaveChangesAsync();
        }
    }
}
