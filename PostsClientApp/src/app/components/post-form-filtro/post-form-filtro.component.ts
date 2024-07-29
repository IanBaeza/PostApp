import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-post-form-filtro',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './post-form-filtro.component.html',
  styleUrl: './post-form-filtro.component.css'
})
export default class PostFormFiltroComponent implements OnInit{
  constructor(private formBuilder : FormBuilder){}

  form!: FormGroup;

  @Output()
  onSubmit: EventEmitter<string> = new EventEmitter<string>();

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: ['', [Validators.required, Validators.maxLength(50)]]
    });
  }

  filtrarPosts(){
    this.onSubmit.emit(this.form.value);
  }
}
