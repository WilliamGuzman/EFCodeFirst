using System;
using System.Collections.Generic;
using System.Data.Entity; //Este paquete se debe instalar y luego importar para poder usar el DBContext
using System.Linq;
using System.Web;

namespace EFCodeFirst.Models
{
    public class BlogContext: DbContext //Se extiende a DbContext porque a traves de esta clase se puedan realizar las operaciones CRUD a una base de datos
    {

        //Creamos el constructor con la conexión que hemos creado
        public BlogContext():base("BlogConnection") {}

        //Utilizando DbSet indicamos que podemos hacer querys a las tablas de la BBDD
        //DbSet<modelo> Con esta instrucción hacemos referencial al modelo con el que vamos a trabajar
        //DbSet<BlogPost> NombreDeLaTabla Con esta instrucción indicaremos cual sera el nombre de la tabla en la BBDD
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}