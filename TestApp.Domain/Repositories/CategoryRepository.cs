using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Data;
using TestApp.Domain.interfaces;
using TestApp.Domain.Models;

namespace TestApp.Domain.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly Context _context;

        public CategoryRepository()
        {
            _context = new Context(Context.ops.dbOptions);
        }
        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
