import { Component, ViewChild } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-crea-seguimineto',
  standalone: true,
  imports: [],
  templateUrl: './crea-seguimineto.component.html',
  styleUrl: './crea-seguimineto.component.css'
})
export class CreaSeguiminetoComponent {

  @ViewChild('warningModal') warningModal: any;
  router: any;
  
  constructor(private apiService:ApiService, private location:Location){}
  ngOnInit(): void {
    this.getEstados();
  }
  async creaSeg() {
    const nombreSeg = (<HTMLInputElement>document.getElementById('nombreSeg')).value;
    const obsevacionSeg = (<HTMLInputElement>document.getElementById('obsevacionSeg')).value;
    const newPath = this.location.path().split("/")[1];
    const id = this.location.path().split("/")[2];
    this.apiService.postSeguimientoToAPI(nombreSeg,id,obsevacionSeg);
    this.location.go(newPath);
    
  }
  getEstados() {
    const options = document.getElementById("estado") as HTMLOptionElement;
    this.apiService.getEstadoProyectos().subscribe((data: any) => {
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
