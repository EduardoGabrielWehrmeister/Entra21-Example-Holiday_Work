using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
        /*
    public class ProjetoController : Controller
    {
        private ProjetoRepository repository;
        public ProjetoController()
        {
            repository = new ProjetoRepository();
        }

        // GET: Projeto
        public ActionResult Index(string busca)
        {
            List<Projeto> projetos = repository.ObterTodos(busca);
            ViewBag.Projetos = projetos;
            return View();
        }

        public ActionResult Cadastro(string busca)
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = clienteRepository.ObterTodos(busca);
            ViewBag.Clientes = clientes;
            return View();
        }

        public ActionResult Store(int idCliente, string nome, DateTime dataFinalizacao, DateTime dataCriacaoProjeto)
        {
            Projeto projeto = new Projeto();
            projeto.Nome = nome;
            projeto.DataCriacaoProjeto = dataCriacaoProjeto;
            projeto.DataFinalizaca = dataFinalizacao;
            projeto.IdCliente = idCliente;
            repository.Inserir(projeto);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Projeto projeto = repository.ObterPeloId(id);
            ViewBag.Projeto = projeto;

            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = clienteRepository.ObterTodos("");
            ViewBag.Clientes = clientes;
            return View();

        }

        public ActionResult Update(int id, int idCliente, string nome, DateTime dataFinalizacao, DateTime dataCriacaoProjeto)
        {
            Projeto projeto = new Projeto();
            projeto.Id = id;
            projeto.Nome = nome;
            projeto.DataCriacaoProjeto = dataCriacaoProjeto;
            projeto.DataFinalizaca = dataFinalizacao;
            projeto.IdCliente = idCliente;
            repository.Update(projeto);
            return RedirectToAction("Index");
        }
    }
    */
}