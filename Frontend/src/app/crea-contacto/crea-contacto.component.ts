import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { TreeMenuComponent } from "../tree-menu/tree-menu.component";
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common'
import { Alert } from 'bootstrap';
import { Location } from '@angular/common';



@Component({
  selector: 'app-crea-contacto',
  standalone: true,
  imports: [],
  templateUrl: './crea-contacto.component.html',
  styleUrl: './crea-contacto.component.css'
})
export class CreaContactoComponent {

  data: any;

  constructor(private router: Router, private http: HttpClient, private apiService: ApiService, private location:Location) {

  }

  async creaContacto() {
    const nombre = (<HTMLInputElement>document.getElementById('nombreContacto')).value;
    const rol = (<HTMLInputElement>document.getElementById('rolContacto')).value;
    const telefono = (<HTMLInputElement>document.getElementById('telefonoContacto')).value;
    const email = (<HTMLInputElement>document.getElementById('emailContacto')).value;
    const nivel = (<HTMLInputElement>document.getElementById('nivel')).value;
    const id = this.location.path().split("/")[2];
    const body = {
      id: id,
      nombre: nombre,
      rol:rol,
      telefono:telefono,
      email:email,
      nivel:nivel
    }
    
    await this.apiService.postContactoToAPI(body.id, body.nombre, body.rol, body.telefono, body.email,body.nivel);
    alert("Se va a crear el contacto: " + nombre);
    console.log("Se deberia haber creado un nuevo proyecto");
    const newPath = this.location.path().split("/")[1];
    console.log(this.location.path());
    alert(newPath)
    this.location.go(newPath);
  }
}
