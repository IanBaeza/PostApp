import { Component, OnInit } from '@angular/core';
import { PostService } from '../../services/post.service';
import { PostCrearDTO, PostDTO } from '../../interfaces/post.interface';
import { Router } from '@angular/router';
import { PostFormComponent } from '../post-form/post-form.component';
import PostFormFiltroComponent from '../post-form-filtro/post-form-filtro.component';


@Component({
  selector: 'app-post-lista',
  standalone: true,
  imports: [
    PostFormComponent,
    PostFormFiltroComponent
  ],
  templateUrl: './post-lista.component.html',
  styleUrl: './post-lista.component.css'
})
export default class PostListaComponent implements OnInit{

  constructor(private postService : PostService, private router : Router){}

  posts : PostDTO[] = [];

  ngOnInit(): void {
    this.refreshPosts();
  }

  refreshPosts(){
    this.postService.listarPosts().subscribe((listadoPosts: PostDTO[]) => {
      this.posts = listadoPosts;
    });
  }

  crearPost(nuevoPost: PostCrearDTO){
    this.postService.crearPost(nuevoPost).subscribe(() => {
      this.refreshPosts();
    });
  }

  eliminarPost(nombrePost: string){
    this.postService.eliminarPost(nombrePost).subscribe(() => {
      this.refreshPosts();
    });
  }

  filtrarPosts(nombrePost: string){
    //pendiente
  }
}
