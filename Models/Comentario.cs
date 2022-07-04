using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCodeFirst.Models
{
    public class Comentario
    {
        public int id { get; set; }
        public string contenido { get; set; }
        public string autor { get; set; }
        public int blogPostID { get; set; } //Llave foranea que hace referencia a la tabla BlogPosts

        //Indicamos que propiedad de este modelo sera la llave foranea y a que tabla hace la referencia
        //En este caso como este modelo almacenara el ID principal de otra tabla se especifica de esta forma
        //Una vez creado esto debemos ir a la otra tabla que es la principal que pasara su id a esta para configurar la relación con esta tabla en este caso BlogPost
        [ForeignKey("blogPostID")]
        public BlogPost BlogPost { get; set; }
    }
}