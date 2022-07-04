namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFCodeFirst.Models.BlogContext>
    {
        public Configuration()
        {
            //Si se realiza un cambio en el modelo c# realizara el cambio en la base de datos
            
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFCodeFirst.Models.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //En esta parte le indicamos a c# que despues de cada migración se crearan estos registros dentro de la tabla Comentarios
            //IMPORTANTE: hay que añadir el modelo de la tabla a utilizar en el Contexto para poder utilizarlo y hacer referencia a ella para ejecutar la inserción
            context.Comentarios.AddOrUpdate(x => x.id, new Models.Comentario()
            {
                id = 1,
                contenido = "Prueba de comentario",
                autor = "Yo de nuevo XD",
                blogPostID = 1
            });
        }
    }
}
