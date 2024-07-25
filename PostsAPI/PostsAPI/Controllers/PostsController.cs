using PostsAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PostsAPI.Controllers
{
    public class PostsController : ApiController
    {
        [HttpGet]
        public List<PostDTO> Get() 
        {
            //listar todas las entidades post a un listado de post en DTO, y retornarlos.

            List<PostDTO> listadoPostDTO = new List<PostDTO>();
 

            return listadoPostDTO; 
        }

        [HttpPost]
        public PostDTO Post([FromBody] PostDTO postDTO)
        {
            PostDTO postCreadoDTO = postDTO;
            
            //mapear el DTO a entidad, guardar la entidad y retornar el mismo DTO.

            return postCreadoDTO;
        }

        [HttpDelete]
        public PostDTO Delete(int Id) 
        {
            //buscar la entidad por el Id, guardarlo en un objeto DTO y retornarlo.
            
            PostDTO postEliminadoDTO = new PostDTO();

            return postEliminadoDTO;
        }

        //[HttpGet]
        //public List<PostDTO> GetPorNombre([FromBody] string nombrePost)
        //{
        //    List<PostDTO> postList = new List<PostDTO>();

        //    //buscar el listado en entidades de post con el nombre por parametro, y retornar la lista.
        //    //se hace por el front end

        //    return postList;
        //}

    }
}
