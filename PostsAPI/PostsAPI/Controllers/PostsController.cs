using PostsAPI.DTOs;
using PostsAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using Npgsql;
using System.Configuration;
using System.Web.UI.WebControls;

namespace PostsAPI.Controllers
{
    public class PostsController : ApiController
    {

        private readonly string connectionString;

        public PostsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PostgreSql"].ConnectionString;
        }

        [HttpGet]
        public List<PostDTO> Get() 
        {
            List<PostDTO> listadoPost = new List<PostDTO>();
            DataSet postsDataSet = new DataSet();
            string queryObtenerPosts = "SELECT id, nombre, descripcion FROM public.post;";
            int cantidadPosts = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using(NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = queryObtenerPosts;

                    using(NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(postsDataSet);
                    }
                    
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

                connection.Close();
            }

            DataRowCollection filasPosts = postsDataSet.Tables[0].Rows;
            cantidadPosts = filasPosts.Count;

            if (cantidadPosts > 0)
            {
                const string campoIdEnBD = "id";
                const string campoNombreEnBD = "nombre";
                const string campoDescripcionEnBD = "descripcion";

                for (int i = 0; i < cantidadPosts; i++)
                {
                    PostDTO postDTO = new PostDTO();

                    postDTO.id = (int)filasPosts[i][campoIdEnBD];
                    postDTO.nombre = filasPosts[i][campoNombreEnBD].ToString();
                    postDTO.descripcion = filasPosts[i][campoDescripcionEnBD].ToString();

                    listadoPost.Add(postDTO);
                }
            }

            return listadoPost; 
        }

        public PostDTO GetPorNombre(string nombrePost)
        {
            PostDTO postEncontrado = new PostDTO();
            DataSet dataSet = new DataSet();
            string queryObtenerPostPorNombre = $"SELECT id, nombre, descripcion FROM public.post WHERE nombre = '{nombrePost}';";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = queryObtenerPostPorNombre;

                    using(NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dataSet);
                    }
                    
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                
                connection.Close();
            }

            DataRowCollection filaPosts = dataSet.Tables[0].Rows;
            int cantidadPosts = filaPosts.Count;
            bool postExiste = cantidadPosts == 1 ? true : false;

            if (postExiste)
            {
                const int indiceUnico = 0;
                const string campoId = "id";
                const string campoNombre = "nombre";
                const string campoDescripcion = "descripcion";

                postEncontrado.id = (int)filaPosts[indiceUnico][campoId];
                postEncontrado.nombre = filaPosts[indiceUnico][campoNombre].ToString();
                postEncontrado.descripcion = filaPosts[indiceUnico][campoDescripcion].ToString();
            }

            return postEncontrado;
        }

        [HttpPost]
        public PostDTO Post([FromBody] PostCrearDTO postCrearDTO)
        {
            PostDTO postAgregado = new PostDTO();
            string nombrePost = postCrearDTO.nombre;
            string descripcionPost = postCrearDTO.descripcion;
            string queryAgregarPost = $"INSERT INTO public.post(nombre, descripcion) VALUES ('{nombrePost}', '{descripcionPost}');";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = queryAgregarPost;
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                   
                connection.Close();
            }

            postAgregado = GetPorNombre(nombrePost);

            return postAgregado;
        }

        [HttpDelete]
        public PostDTO Delete(string nombrePost) 
        {   
            string nombrePostEliminar = nombrePost;
            string queryEliminarPost = $"DELETE FROM public.post WHERE nombre = '{nombrePostEliminar}';";
            PostDTO postEliminado = GetPorNombre(nombrePostEliminar);

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = queryEliminarPost;
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

                connection.Close();
            }
            
            return postEliminado;
        }
    }
}
