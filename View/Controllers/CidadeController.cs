using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CidadeController : Controller
    {
        private CidadeRepository repository;

        private EstadoRepository estadoRepository;

        public CidadeController()
        {
            repository = new CidadeRepository();

            estadoRepository = new EstadoRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterTodos(string busca)
        {
            List<Cidade> cidades = repository.ObterTodos(busca);
            List<Estado> estados = estadoRepository.ObterTodos(busca);
            return Json(new { Estado = estados, Cidade = cidades }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObterTodosEstado()
        {
            List<Estado> estados = estadoRepository.ObterTodos("");
            return Json(estados, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult Store(Cidade cidade)
        {
            cidade.RegistroAtivo = true;
            repository.Inserir(cidade);
            return Json(cidade);
        }

        [HttpGet, Route("apagar/{id}")]
        public JsonResult Apagar(int id)
        {
            bool apagou = repository.Delete(id);
            return Json(new { status = apagou }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("obterpeloid/{id}")]
        public JsonResult ObterPeloId(int id)
        {
            Cidade cidade = repository.ObterPeloId(id);
            Estado estado = estadoRepository.ObterPeloId(id);
            return Json(new { Estado = estado, Cidade = cidade }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Cidade cidade)
        {
            bool alterou = repository.Update(cidade);
            return Json(new { status = alterou });
        }

    }
}