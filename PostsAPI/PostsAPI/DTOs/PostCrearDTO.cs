using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PostsAPI.DTOs
{
    public class PostCrearDTO
    {
        [Required]
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}