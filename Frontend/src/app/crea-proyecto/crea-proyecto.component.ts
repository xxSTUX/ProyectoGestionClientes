import { Component } from '@angular/core';
import { SideMenuComponent } from "../side-menu/side-menu.component";
import { HeaderComponent } from "../header/header.component";
import { TreeMenuComponent } from "../tree-menu/tree-menu.component";
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crea-proyecto',
  standalone: true,
  imports: [],
  templateUrl: './crea-proyecto.component.html',
  styleUrl: './crea-proyecto.component.css'
})
export class CreaProyectoComponent {
  getJsonValue: any;

  constructor(private router: Router, private http: HttpClient,private apiService: ApiService){

  }
  creaproyecto(){

    const nombreproyecto = (<HTMLInputElement>document.getElementById('nombreproyecto')).value;
    const tipo = (<HTMLInputElement>document.getElementById('tipoproyecto')).value;
    const estado = (<HTMLInputElement>document.getElementById('estadoproyecto')).value;

    const body = {
        nombre: nombreproyecto,
        tipo:tipo,
        estado:estado
    }

    alert("Se va a crear el proyecto: " + nombreproyecto);
    this.apiService.postProyectosFromAPI(1,body.nombre,body.tipo,body.estado);
    console.log("Se deberia haber creado un nuevo proyecto");
    this.router.navigate(['dashboard']);
}

getcliente(){
  this.apiService.getDataClientesFromAPI().subscribe((data: any) =>{
    this.getJsonValue = data;
    for (let i = 0; i < this.getJsonValue.length; i++) { 
      
    }
  })
}

}
