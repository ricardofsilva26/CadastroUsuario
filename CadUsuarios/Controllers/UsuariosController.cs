using CadUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CadUsuarios.Controllers
{
    public class UsuariosController : Controller
    {
        CadUsuariosMod db = new CadUsuariosMod();
        public ActionResult Index()
        {
            List<Usuario> lstUsuario = db.Usuarios.ToList();
            return View(lstUsuario);
        }
        public ActionResult CarregaUsuarioId(int idusuario)
        {
            Usuario usu = db.Usuarios.Find(idusuario);
            return View(usu);
        }
        public ActionResult SalvarUsuario(string nome, string sobrenome, string email, UsuarioDetalhe[] detalhes)
        {
            string resultado = "Erro, os dados do usuario estão incompletos";

            string strTeste = string.Empty;

            if (nome != null || sobrenome != null || detalhes != null)
            {
                Usuario usu = new Usuario();
                usu.Nome = nome;
                usu.SobreNome = sobrenome;
                usu.Email = email;

                foreach (var item in detalhes)
                {
                    UsuarioDetalhe dta = new UsuarioDetalhe();
                    dta.IdUsuario = usu.IdUsuario;
                    dta.Telefone = item.Telefone;
                    dta.Endereco = item.Endereco;

                    usu.UsuarioDetalhes.Add(dta);


                }

                db.Usuarios.Add(usu);
                db.SaveChanges();
                resultado = "Usuário cadastrado com sucesso!";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        public ActionResult AlterarUsuario(int idusuario, string nome, string sobrenome, string email, UsuarioDetalhe[] detalhes)
        {
            //string resultado = "Erro, os dados do usuario estão incompletos";

            if (nome != null || sobrenome != null || detalhes != null)
            {

                db.UsuarioDetalhes.RemoveRange(db.UsuarioDetalhes.Where(x => x.IdUsuario == idusuario));
                db.SaveChanges();


                Usuario usu = db.Usuarios.Find(idusuario);
                bool novoUsu = false;
                if (usu == null)
                {
                    usu = new Usuario();
                    novoUsu = true;
                }

                usu.Nome = nome;
                usu.SobreNome = sobrenome;
                usu.Email = email;



                foreach (var item in detalhes)
                {
                    UsuarioDetalhe dta = new UsuarioDetalhe();
                    dta.IdUsuario = usu.IdUsuario;
                    dta.Telefone = item.Telefone;
                    dta.Endereco = item.Endereco;

                    usu.UsuarioDetalhes.Add(dta);

                }
                if (novoUsu)
                {
                    db.Usuarios.Add(usu);
                }
                else
                {
                    db.Entry(usu).State = EntityState.Modified;
                }

                db.SaveChanges();

            }

            return RedirectToAction("Index");

        }
        public ActionResult ApagarUsuario(int idusuario)
        {

            if (idusuario > 0)
            {

                db.UsuarioDetalhes.RemoveRange(db.UsuarioDetalhes.Where(x => x.IdUsuario == idusuario));
                db.SaveChanges();

                db.Usuarios.RemoveRange(db.Usuarios.Where(x => x.IdUsuario == idusuario));
                db.SaveChanges();

            }

            return RedirectToAction("Index");


        }

    }
}