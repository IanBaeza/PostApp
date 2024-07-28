import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private http = inject(HttpClient);

  listarPosts(){
    return this.http.get('http://localhost:53276/api/Posts');
  }

  crearPost(post : any){
    return this.http.post('http://localhost:53276/api/Posts', post);
  }

  eliminarPost(nombrePost : string){
    return this.http.delete(`http://localhost:53276/api/Posts?nombrePost=${nombrePost}`);
  }

}
