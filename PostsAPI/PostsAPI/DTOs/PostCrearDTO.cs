using System.ComponentModel.DataAnnotations;

namespace PostsAPI.DTOs
{
    public class PostCrearDTO
    {
        [Required]
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}