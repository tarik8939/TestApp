using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Models;

namespace TestApp.Domain.interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetAll();
    }
}
