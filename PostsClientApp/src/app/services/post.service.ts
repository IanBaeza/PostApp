import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { PostCrearDTO, PostDTO } from '../interfaces/post.interface';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private apiURL = `http://localhost:53276/api/Posts`;
  private http = inject(HttpClient);

  listarPosts(){
    return this.http.get<PostDTO[]>(`${this.apiURL}`);
  }

  crearPost(nuevoPost : PostCrearDTO){
    return this.http.post<PostDTO>(`${this.apiURL}`, nuevoPost);
  }

  eliminarPost(nombrePost : string){
    return this.http.delete<PostDTO>(`${this.apiURL}?nombrePost=${nombrePost}`);
  }

}
