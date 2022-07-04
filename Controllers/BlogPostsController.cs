using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    public class BlogPostsController : Controller
    {
        private BlogPostRepository _repo;
        //Constructor de la clase
        public BlogPostsController()
        {
            _repo = new BlogPostRepository();
        }

        // GET: BlogPosts
        public ActionResult Index()
        {
            List<BlogPost> model = _repo.obtenerBlogs();

            return View( model );
        }

        // GET: BlogPosts/Details/5
        public ActionResult Details(int id)
        {
            BlogPost model = _repo.ObtenerBlogPost(id);

            return View( model );
        }

        // GET: BlogPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        [HttpPost]
        public ActionResult Create(BlogPost model)
        {
            try
            {
                // TODO: Add insert logic here

                //Validamos si las reglas de validación agregadas a cada campo en el modelo sean cumplido o no.
                if (ModelState.IsValid)
                {
                    _repo.Crear(model);//Llamamos a la función que se encargara de insertar los datos en la tabla BlogPosts
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //Mostrar los errores
            }

            return View(model);//Pasandole el modelo al cargar la vista nuevamente se mantienen los datos escritos por el usuario en el formulario.
        }

        // GET: BlogPosts/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _repo.ObtenerBlogPost(id);
            return View( model );
        }

        // POST: BlogPosts/Edit/5
        [HttpPost]
        public ActionResult Edit(BlogPost model)
        {
            try
            {
                // TODO: Add update logic here
                _repo.actualizar(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPosts/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _repo.ObtenerBlogPost(id);
            return View(model);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost]
        public ActionResult Delete(BlogPost model)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.borrar(model.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
