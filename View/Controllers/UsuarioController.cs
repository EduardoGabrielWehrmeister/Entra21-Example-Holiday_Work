using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioRepository repository;

        public UsuarioController()
        {
            repository = new UsuarioRepository();
        }
        
        public ActionResult Index()
        {
            List<Usuario> usuarios = repository.ObterTodos();
            ViewBag.Usuarios = usuarios;
            return View();
        }

        public ActionResult Cadastro()
        {
            List<Usuario> usuarios = repository.ObterTodos();
            ViewBag.Usuarios = usuarios;
            return View();
        }

        public ActionResult Store(string nome, string login, string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Login = login;
            usuario.Senha = senha;
            repository.Inserir(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Usuario usuario = repository.ObterPeloId(id);
            ViewBag.Usuario = usuario;
            return View();
        }

        public ActionResult Update(int id, string nome, string login, string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;
            usuario.Nome = nome;
            usuario.Login = login;
            usuario.Senha = senha;
            repository.Update(usuario);
            return RedirectToAction("Index");
        }
    }
}