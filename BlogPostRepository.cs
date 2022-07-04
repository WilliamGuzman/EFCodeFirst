using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;


namespace EFCodeFirst
{
    public class BlogPostRepository
    {
        public List<BlogPost> obtenerBlogs()
        {
            //Instanciamos el DbContext ya que este sera el encargado de realizar las peticiones a la BBDD
            using ( var db = new BlogContext() )
            {
                //En este caso BlogPosts es el nombre de la tabla a la que haremos las consultas que esta refenreciada en el BlogContext.cs en la carpeta Models
                //En este caso el ToList() es igual a decir select * from nombreTabla en SQL SERVER nos proporcionara todos los registros de la tabla indicada
                //El Include() es como realizar un join o inner join en PHP el campo de representa la lleve foranea de la otra tabla debe estar creada en el modelo al que se le quiere realizar el query
                return db.BlogPosts.Include( x => x.comentariosID ).ToList(); 
            }
        }

        internal BlogPost ObtenerBlogPost(int id)
        {

            using (var db = new BlogContext())
            {
                return db.BlogPosts.Find(id);
            }

        }

        internal void Crear(BlogPost model)
        {
            using ( var db = new BlogContext() )
            {
                db.BlogPosts.Add(model);//Aca se prepara la información para el objeto correspondiente, aun no se han insertado en la BBDD
                db.SaveChanges();//Hasta en este momento se ejecutara la inserción en la BBDD, antes de esta instrucción es posible modificar la información o añadir mas datos si es necesario
            }
        }

        internal void actualizar(BlogPost model)
        {
            using ( var db = new BlogContext())
            {
                db.BlogPosts.AddOrUpdate(model);
                db.SaveChanges();

            }
        }

        internal void borrar(int id)
        {
            using (var db = new BlogContext())
            {
                var blog = db.BlogPosts.Find(id);
                db.BlogPosts.Remove(blog);
                db.SaveChanges();

            }
        }
    }
}