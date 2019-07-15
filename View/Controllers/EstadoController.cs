using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class EstadoController : Controller
    {
        private EstadoRepository repository;

        public EstadoController()
        {
            repository = new EstadoRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterTodos(string busca)
        {
            List<Estado> estados = repository.ObterTodos(busca);
            return Json(estados, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Store(Estado estado)
        {
            estado.RegistroAtivo = true;
            repository.Inserir(estado);
            return Json(estado);
        }
    }
}