using LanhesMac.Models;
using LanhesMac.Repositories;
using LanhesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LanhesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _catagoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository catagoriaRepository)
        {


            _lancheRepository = lancheRepository;
            _catagoriaRepository = catagoriaRepository;


        }


        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {

                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoria = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))

                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);


                }
                else
                {

                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.Nome);

                }
                categoriaAtual = _categoria;

            }
            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual

        };

        return View(lanchesListViewModel);
    }

}
}
