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
  selector: 'app-crea-proyecto',
  standalone: true,
  imports: [],
  templateUrl: './crea-proyecto.component.html',
  styleUrl: './crea-proyecto.component.css'
})
export class CreaProyectoComponent {

  data: any;

  constructor(private router: Router, private http: HttpClient, private apiService: ApiService, private location:Location) {

  }
  ngOnInit(): void {
    this.getEstados();
  }
  async creaproyecto() {
    const nombreproyecto = (<HTMLInputElement>document.getElementById('nombreproyecto')).value;
    const tipo = (<HTMLInputElement>document.getElementById('tipoproyecto')).value;
    const estado = parseInt((<HTMLInputElement>document.getElementById('estado')).value);
    const id = this.location.path().split("/")[2];
    const body = {
      id: id,
      nombre: nombreproyecto,
      tipo: tipo,
      estado: estado
    }
    
    this.apiService.postProyectosFromAPI(body.id, body.nombre, body.tipo, body.estado + "");
    alert("Se va a crear el proyecto: " + nombreproyecto);
    console.log("Se deberia haber creado un nuevo proyecto");
    const newPath = this.location.path().split("/")[1];
    console.log(this.location.path());
    alert(newPath)
    this.location.go(newPath);
  }



  getEstados() {
    const options = document.getElementById("estado") as HTMLOptionElement;
    this.apiService.getEstadoProyectos().subscribe((data: any) => {
      console.log()
      if (options != null) {
        for (let i = 0; i < data.length; i++) {
          const option = document.createElement('option');
          console.log(data[i]);
          option.value = data[i].id; // Asigna el valor de la propiedad id del cliente como valor del option
          option.textContent = data[i].estado; // Asigna el nombre del cliente como texto del option
          options.appendChild(option); // Agrega el option al elemento select
        }

      }
    });
  }

}
