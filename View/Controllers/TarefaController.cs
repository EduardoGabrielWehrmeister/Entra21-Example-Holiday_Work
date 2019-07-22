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

        //private ProjetoRepository projetoRepository;

        public TarefaController()
        {
            repository = new TarefaRepository();

            categoriaRepository = new CategoriaRepository();

            usuarioRepository = new UsuarioRepository();

            //projetoRepository = new ProjetoRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /*[HttpGet]
        public ActionResult ObterTodos(string busca)
        {
            List<Tarefa> tarefas = repository.ObterTodos(busca);
            List<Categoria> categorias = categoriaRepository.ObterTodos(busca);
            List<Usuario> usuarios = usuarioRepository.ObterTodos(busca);
            //List<Projeto> projetos = projetoRepository.ObterTodos(busca);
            return Json(new { Categoria = categorias, Tarefa = tarefas,
            Usuario = usuarios, Projeto = projetos}, JsonRequestBehavior.AllowGet);
        }*/

        [HttpGet]
        public JsonResult ObterTodosCategoria()
        {
            List<Categoria> categorias = categoriaRepository.ObterTodos("");
            return Json(categorias, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObterTodosUsuario()
        {
            List<Usuario> usuarios = usuarioRepository.ObterTodos("");
            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }

        /*[HttpGet]
        public JsonResult ObterTodosProjeto()
        {
            List<Projeto> projetos = projetoRepository.ObterTodos("");
            return Json(projetos, JsonRequestBehavior.AllowGet);
        }
        */

        [HttpPost]
        public JsonResult Store(Tarefa tarefa)
        {
            tarefa.RegistroAtivo = true;
            repository.Inserir(tarefa);
            return Json(tarefa);
        }

        [HttpGet, Route("apagar/{id}")]
        public JsonResult Apagar(int id)
        {
            bool apagou = repository.Apagar(id);
            return Json(new { status = apagou }, JsonRequestBehavior.AllowGet);
        }

        /*[HttpGet, Route("obterpeloid/{id}")]
        public JsonResult ObterPeloId(int id)
        {
            Tarefa tarefa = repository.ObterPeloId(id);
            Categoria categoria = categoriaRepository.ObterPeloId(id);
            Usuario usuario = usuarioRepository.ObterPeloId(id);
            //Projeto projeto = projetoReposirtory.ObterPeloId(id);
            return Json(new { Categoria = categoria, Tarefa = tarefa,
            Usuario = usuario, Projeto = projeto}, JsonRequestBehavior.AllowGet);
        }*/

        [HttpPost]
        public JsonResult Update(Tarefa tarefa)
        {
            bool alterou = repository.Alterar(tarefa);
            return Json(new { status = alterou });
        }
    }
}