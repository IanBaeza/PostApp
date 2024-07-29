import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import PostListaComponent from './components/post-lista/post-lista.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    PostListaComponent
],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'PostsClientApp';
}
