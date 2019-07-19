using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository repository;

        public ClienteController()
        {
            repository = new ClienteRepository();
        }

        // GET: Cliente
        public ActionResult Index(string busca)
        {
            List<Cliente> clientes = repository.ObterTodos(busca);
            ViewBag.Clientes = clientes;
            return View();
        }

        public ActionResult Cadastro(string busca)
        {
            CidadeRepository cidadeRepository = new CidadeRepository();
            List<Cidade> cidades = cidadeRepository.ObterTodos(busca);
            ViewBag.Cidades = cidades;
            return View();
        }

        public ActionResult Store(int idCidade, string nome, string cpf, DateTime dataNascimento, int numero, string complemento, string logradouro, string cep)
        {
            Cliente cliente = new Cliente();
            cliente.IdCidade = idCidade;
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Numero = numero;
            cliente.Complemento = complemento;
            cliente.Logradouro = logradouro;
            cliente.Cep = cep;
            repository.Inserir(cliente);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id, string busca)
        {
            Cliente cliente = repository.ObterPeloId(id);
            ViewBag.Cliente = cliente;

            CidadeRepository cidadeRepository = new CidadeRepository();
            List<Cidade> cidades = cidadeRepository.ObterTodos(busca);
            ViewBag.Cidades = cidades;
            return View();
        }

        public ActionResult Update(int id, int idCidade, string nome, string cpf, DateTime dataNascimento, int numero, string complemento, string logradouro, string cep)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.IdCidade = idCidade;
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Numero = numero;
            cliente.Complemento = complemento;
            cliente.Logradouro = logradouro;
            cliente.Cep = cep;
            repository.Update(cliente);
            return RedirectToAction("Index");
        }
    }
}