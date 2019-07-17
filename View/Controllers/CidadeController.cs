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
        private EstadoRepository estadoRepository;
        private CidadeRepository repository;

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
           
            return Json(new {cidades, estados }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Store(Cidade cidade)
        {
            cidade.RegistroAtivo = true;
            repository.Inserir(cidade);
            return Json(cidade);
        }

        [HttpGet]
        [Route("apagar/{id}")]
        public JsonResult Apagar(int id)
        {
            bool apagou = repository.Delete(id);
            return Json(new { status = apagou }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("obterpeloid/{id}")]
        public JsonResult obterPeloId(int id)
        {
            Cidade cidade = repository.ObterPeloId(id);

            Estado estado = estadoRepository.ObterPeloId(id);
            
            return Json(new { cidade, estado }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Cidade cidade)
        {
            bool alterou = repository.Update(cidade);
            return Json(new { status = alterou });
        }
    
    }
}