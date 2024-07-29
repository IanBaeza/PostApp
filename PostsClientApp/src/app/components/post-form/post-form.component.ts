import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PostCrearDTO } from '../../interfaces/post.interface';

@Component({
  selector: 'app-post-form',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './post-form.component.html',
  styleUrl: './post-form.component.css'
})
export class PostFormComponent implements OnInit {
  constructor(private formBuilder : FormBuilder){}

  form!: FormGroup;

  @Output()
  onSubmit: EventEmitter<PostCrearDTO> = new EventEmitter<PostCrearDTO>();

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: ['', [Validators.required, Validators.maxLength(50)]],
      descripcion: ['', [Validators.maxLength(50)]]
    });
  }

  crearPost(){
    this.onSubmit.emit(this.form.value);
  }

}
