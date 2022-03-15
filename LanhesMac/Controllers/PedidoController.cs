using LanhesMac.Models;
using LanhesMac.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanhesMac.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra) 
        {

            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
    
       [Authorize]
        public IActionResult Checkout() 
        {

            return View();
        
        }
       
        [HttpGet]
        [Authorize]
        public IActionResult Checkout(Pedido pedido)
        {

            var items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;


            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0) 
            
            {
                ModelState.AddModelError("","Seu carrinho esta vazio,incluia um lanche...");
            
            }

            if (ModelState.IsValid) 
            {

                _pedidoRepository.CriarPedido(pedido);
                
                ViewBag.CheckoutCompletoMensagem = "Obrigado Pelo Seu Pedido:)";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();
                
                _carrinhoCompra.LimparCarrinho();
                return View("~/Views/Pedido/CheckoutCompleto.cshtml",pedido);

            }
            return View(pedido);
        }
        
        public IActionResult CheckoutCompleto() 
        {


            ViewBag.Cliente = TempData["Cliente"];
            ViewBag.DataPedido = TempData["DataPedido"];
            ViewBag.NumeroPedido = TempData["NumeroPedido"];
            ViewBag.TotalPedido = TempData["TotalPedido"];
            ViewBag.CheckoutCompletoMensagem ="Obrigado Pelo Seu Pedido  :) ";
            return View();
        
        
        }
      }
    }

