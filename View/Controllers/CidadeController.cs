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


        public ActionResult Index()
        {
            List<Cidade> cidades = repository.ObterTodos("");
            ViewBag.Cidades = cidades;
            return View();
        }

        public ActionResult Cadastro()
        {
            List<Estado> estados = estadoRepository.ObterTodos("");
            ViewBag.Estados = estados;
            return View();
        }

        public ActionResult Store(int idEstado, string nome, int numeroHabitantes)
        {
            Cidade cidade = new Cidade();
            cidade.EstadoId = idEstado;
            cidade.Nome = nome;
            cidade.NumeroHabitantes = numeroHabitantes;
            repository.Inserir(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Cidade cidade = repository.ObterPeloId(id);
            ViewBag.Cidade = cidade;

            List<Estado> estados = estadoRepository.ObterTodos("");
            ViewBag.Estados = estados;
            return View();
        }

        public ActionResult Update(int id, int idEstado, string nome, int numeroHabitantes)
        {
            Cidade cidade = new Cidade();
            cidade.Id = id;
            cidade.EstadoId = idEstado;
            cidade.Nome = nome;
            cidade.NumeroHabitantes = numeroHabitantes;
            repository.Update(cidade);
            return RedirectToAction("Index");
        }

    }


}