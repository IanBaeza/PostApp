using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PostsAPI.DTOs
{
    public class PostDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripcion{ get; set; }
    }
}