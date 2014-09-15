using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridMvc;
using MVCSample.Filters;
using MVCSample.Models;

namespace MVCSample.Controllers
{
    
    public class ClientesController : Controller
    {
        [HttpGet]        
        public ActionResult Index(int? page)
        {
            return View(BaseDeClientes.Listar());
        }

        [HttpGet]
        public ActionResult Filtrar(string nome)
        {
            return View("Index", !String.IsNullOrEmpty(nome) ? BaseDeClientes.Listar(c => c.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase)) : BaseDeClientes.Listar());
        }

        [HttpGet]
        [RecebeModelState]
        public ActionResult Adicionar()
        {            
            return View();
        }

        [HttpPost]
        [EnviaModelState]
        public ActionResult Adicionar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BaseDeClientes.Inserir(cliente);
                    TempData["MensagemDeSucesso"] = "Cliente Cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ErroDeNegocio", e.Message);                    
                }
            }

            return RedirectToAction("Adicionar");
        }

        [HttpGet]
        [RecebeModelState]
        public ActionResult Alterar(Guid id)
        {
            return View(BaseDeClientes.Buscar(c => c.Id.Equals(id)));
        }

        [HttpPost]
        [EnviaModelState]
        public ActionResult Alterar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BaseDeClientes.Alterar(cliente);
                    TempData["MensagemDeSucesso"] = "Cliente Alterado com sucesso!";

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ErroDeNegocio", e.Message);
                }
            }

            return RedirectToAction("Alterar");
        }

        [HttpDelete]
        public ActionResult Excluir(Guid id)
        {
            BaseDeClientes.Remover(id);

            return RedirectToAction("Index");
        }
    }
}