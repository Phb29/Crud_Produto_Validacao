using CrudProdutos.Data;
using CrudProdutos.Models;
using CrudProdutos.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudProdutos.Controllers
{
    public class ProdutoController : Controller

    {

        private readonly Context _context;
        private readonly Iproduto _produto;

        public ProdutoController(Context context,Iproduto produto)
        {
            _context = context;
            _produto = produto;

        }

        public IActionResult Index()
        {
            
            var employees = _produto.ListEmployee();
            return View(employees);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Produto employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {


                    _produto.NewEmployee(employee);
                    TempData["sucess"] = "Produto criado com sucesso";



                    return RedirectToAction("Index");
                }
                return View(employee);
            }

            catch (System.Exception erro)
            {
                TempData["Erro"] = $" Erro na Criação de Produto!!  {erro.Message}";
                return RedirectToAction("index");

            }




        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            TempData["delete"] = "Produto Deletado Com sucesso";

            _produto.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
        public IActionResult Details(int? id)
        {
            var busca = _produto.Detail(id);
            return View(busca);

        }
        public IActionResult Update(int id)

        {
            var buscar = _produto.IdLoc(id);

            return View(buscar);
        }
        [HttpPost]
        public IActionResult Update(Produto employee)
        {
            if (ModelState.IsValid)
            {
                _produto.Update(employee);
                TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(employee);

        }
    }
}
