using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCodeFirst.Models
{
    public class BlogPost
    {
        public int id { get; set; }
        [Required]
        [StringLength(200)]
        public string titulo { get; set; }
        [Required]
        public string contenido { get; set; }
        [Required]
        [StringLength(100)]
        public string autor { get; set; }
        public DateTime publicacion { get; set; }

        //Acá especificamos la relación de la tabla BlogPost con la tabla Comentario
        //En este caso como este modelo sera el que envie su ID a la tabla Comentario acá se debe especificar la relación como una lista ya que puede tener mas de un registro
        //este ID en la otra tabla
        public List<Comentario> comentariosID { get; set; }
    }
}