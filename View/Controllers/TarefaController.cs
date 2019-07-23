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

        private CategoriaRepository categoriaRepository;

        private UsuarioRepository usuarioRepository;

        private ProjetoRepository projetoRepository;

        public TarefaController()
        {
            repository = new TarefaRepository();

            categoriaRepository = new CategoriaRepository();

            usuarioRepository = new UsuarioRepository();

            projetoRepository = new ProjetoRepository();
        }
        
        public ActionResult Index(string busca)
        {
            List<Tarefa> tarefas = repository.ObterTodos(busca);
            ViewBag.Tarefas = tarefas;
            return View();
        }

        /*[HttpGet]
        public ActionResult ObterTodos(string busca)
        {
            List<Tarefa> tarefas = repository.ObterTodos(busca);
            List<Categoria> categorias = categoriaRepository.ObterTodos(busca);
            List<Usuario> usuarios = usuarioRepository.ObterTodos(busca);
            List<Projeto> projetos = projetoRepository.ObterTodos(busca);
            return Json(new { Categoria = categorias, Tarefa = tarefas,
            Usuario = usuarios, Projeto = projetos}, JsonRequestBehavior.AllowGet);
        }
        */


        
        public ActionResult Store(int idCategoria, int idUsuario, int idProjeto, string titulo, string descricao, DateTime duracao)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.CategoriaId = idCategoria;
            tarefa.UsuarioId = idUsuario;
            tarefa.ProjetoId = idProjeto;
            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Duracao = duracao;
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
            
        }

        
        public ActionResult Update(int id, int idCategoria, int idUsuario, int idProjeto, string titulo, string descricao, DateTime duracao)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = id;
            tarefa.CategoriaId = idCategoria;
            tarefa.UsuarioId = idUsuario;
            tarefa.ProjetoId = idProjeto;
            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Duracao = duracao;
            return RedirectToAction("Index");
        }

        
        public ActionResult Editar(int id)
        {
            Tarefa tarefa = repository.ObterPeloId(id);
            ViewBag.Tarefa = tarefa;

            List<Categoria> categorias = categoriaRepository.ObterTodos("");
            ViewBag.Categorias = categorias;

            List<Projeto> projetos = projetoRepository.ObterTodos("");
            ViewBag.Projetos = projetos;

            List<Usuario> usuarios = usuarioRepository.ObterTodos("");
            ViewBag.Usuarios = usuarios;

            return View();
        }


    }
}