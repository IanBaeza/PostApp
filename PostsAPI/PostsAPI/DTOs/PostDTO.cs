using System.ComponentModel.DataAnnotations;

namespace PostsAPI.DTOs
{
    public class PostDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string descripcion{ get; set; }
    }
}