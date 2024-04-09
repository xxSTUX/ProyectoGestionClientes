import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-aniadecontacto',
  standalone: true,
  imports: [],
  templateUrl: './aniadecontacto.component.html',
  styleUrl: './aniadecontacto.component.css'
})
export class AniadecontactoComponent {
  aniadeContactoForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) {
    this.aniadeContactoForm = this.fb.group({
      nombreCliente: ['', Validators.required],
    });
  }

  aniadeContacto() {

    const nombreCliente = (<HTMLInputElement>document.getElementById('nombreContacto')).value;

    const body = {
      nombre: nombreCliente,
    }
  }
}
