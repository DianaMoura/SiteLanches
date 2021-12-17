using LanhesMac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanhesMac.Repositories
{
    public interface ICategoriaRepository
    {

        IEnumerable<Categoria> Categorias { get; }
    }
}
