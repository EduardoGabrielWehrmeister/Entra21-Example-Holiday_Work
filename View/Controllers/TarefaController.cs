using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class TarefaController : Controller
    {
        private TarefaRepository repository;

        private UsuarioRepository usuarioRepository;

        private ProjetoRepository projetoRepository;

        private CategoriaRepository categoriaRepository;

        public TarefaController()
        {
           repository = new TarefaRepository();

            usuarioRepository = new UsuarioRepository();

            projetoRepository = new ProjetoRepository();

            categoriaRepository = new CategoriaRepository();
        }

        public ActionResult Index()
        {
            List<Tarefa> tarefas = repository.ObterTodos("");
            ViewBag.Tarefas = tarefas;
            return View();
        }

        public ActionResult Cadastro()
        {
            List<Usuario> usuarios = usuarioRepository.ObterTodos("");
            ViewBag.Usuarios = usuarios;

            List<Projeto> projetos = projetoRepository.ObterTodos("");
            ViewBag.Projetos = projetos;

            List<Categoria> categorias = categoriaRepository.ObterTodos("");
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Store(int idCategoria, int idUsuario, int idProjeto, string titulo, string descricao, DateTime duracao)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.IdCategoria = idCategoria;
            tarefa.IdUsuario = idUsuario;
            tarefa.IdProjeto = idProjeto;
            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Duracao = duracao;
            repository.Inserir(tarefa);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Tarefa tarefa = repository.ObterPeloId(id);
            ViewBag.Tarefa = tarefa;

            CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepository.ObterTodos("");
            ViewBag.Categorias = categorias;

            ProjetoRepository projetoRepository = new ProjetoRepository();
            List<Projeto> projetos = projetoRepository.ObterTodos("");
            ViewBag.Projetos = projetos;

            UsuarioRepository usuarioRepository = new UsuarioRepository();
            List<Usuario> usuarios = usuarioRepository.ObterTodos("");
            ViewBag.Usuarios = usuarios;

            return View();
        }
        

        public ActionResult Update(int id, int idCategoria, int idProjeto, int idUsuario, string titulo, string descricao, DateTime duracao)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = id;
            tarefa.IdCategoria = idCategoria;
            tarefa.IdProjeto = idProjeto;
            tarefa.IdUsuario = idUsuario;
            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Duracao = duracao;
            repository.Update(tarefa);
            return RedirectToAction("Index");
        }
    }
}