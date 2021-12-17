using LanhesMac.Context;
using LanhesMac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanhesMac.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext contexto) 
        {

            _context = contexto;
        
        
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
