import { Component } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-elimina-proyecto',
  standalone: true,
  imports: [],
  templateUrl: './elimina-proyecto.component.html',
  styleUrl: './elimina-proyecto.component.css'
})
export class EliminaProyectoComponent {
  data:any;

  constructor(private router: Router, private http: HttpClient,private apiService: ApiService){

  }
  ngOnInit(): void {
    this.getproyectos("opcionesEliminarProyecto");
  }
  async eliminarproyecto(){

    const idcliente = parseInt((<HTMLInputElement>document.getElementById('opcionesEliminarProyecto')).value);
    
    this.apiService.deleteProyectoToAPI(idcliente);
    alert("Se va a crear el proyecto: " + idcliente);
    console.log("Se deberia haber creado un nuevo proyecto");
}

getproyectos(opciones: string){
  const options = document.getElementById(opciones) as HTMLOptionElement;
  this.apiService.getDataProyectosFromAPI().subscribe((data: any) =>{
    console.log(data);
  if(options != null ){
    for (let i = 0; i < data.length; i++) {
      if(!data[i].eliminado){
        const option = document.createElement('option');
        console.log(data[i].eliminado);
        option.value = data[i].id; // Asigna el valor de la propiedad id del cliente como valor del option
        option.textContent = data[i].nombre; // Asigna el nombre del cliente como texto del option
        options.appendChild(option); // Agrega el option al elemento select
      }
    }
  }
    });
    
 }

}
