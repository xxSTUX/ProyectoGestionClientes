import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { TreeMenuComponent } from "../tree-menu/tree-menu.component";
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common'



@Component({
  selector: 'app-crea-proyecto',
  standalone: true,
  imports: [],
  templateUrl: './crea-proyecto.component.html',
  styleUrl: './crea-proyecto.component.css'
})
export class CreaProyectoComponent {
  
  data:any;

  constructor(private router: Router, private http: HttpClient,private apiService: ApiService){

  }
  ngOnInit(): void {
    this.getclientes("opciones");
  }
  async creaproyecto(){

    const idcliente = parseInt((<HTMLInputElement>document.getElementById('opciones')).value);
    const nombreproyecto = (<HTMLInputElement>document.getElementById('nombreproyecto')).value;
    const tipo = (<HTMLInputElement>document.getElementById('tipoproyecto')).value;
    const estado = (<HTMLInputElement>document.getElementById('estadoproyecto')).value;

    const body = {
        nombre: nombreproyecto,
        tipo:tipo,
        estado:estado
    }

    this.apiService.postProyectosFromAPI(idcliente,body.nombre,body.tipo,body.estado);
    alert("Se va a crear el proyecto: " + nombreproyecto);
    console.log("Se deberia haber creado un nuevo proyecto");
}

getclientes(opciones: string){
  const options = document.getElementById(opciones) as HTMLOptionElement;
  this.apiService.getDataClientesFromAPI().subscribe((data: any) =>{
  if(options != null){
    for (let i = 0; i < data.length; i++) {
      const option = document.createElement('option');
      console.log(data[i]);
      option.value = data[i].id; // Asigna el valor de la propiedad id del cliente como valor del option
      option.textContent = data[i].nombre; // Asigna el nombre del cliente como texto del option
      options.appendChild(option); // Agrega el option al elemento select
    }
    
  }
    });
    
 }

}
