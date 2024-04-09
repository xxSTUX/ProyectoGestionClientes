import { Component, ViewChild } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-crea-area',
  standalone: true,
  imports: [],
  templateUrl: './crea-area.component.html',
  styleUrl: './crea-area.component.css'
})
export class CreaAreaComponent {

  @ViewChild('warningModal') warningModal: any;
  router: any;
  contactos: any;
  constructor(private apiService:ApiService, private location:Location){}
  ngOnInit(): void {
    this.getEstados();
  }
  async creaArea() { 
    const obsevacionSeg = (<HTMLInputElement>document.getElementById('obsevacionSeg')).value;
    const newPath = this.location.path().split("/")[1];
    const id = this.location.path().split("/")[2];
    await this.apiService.postSeguimientoToAPI(id,obsevacionSeg);
    this.location.go(newPath);
    
  }

  getEstados() {
    const options = document.getElementById("contactos") as HTMLOptionElement;
    
    this.apiService.getDataContactosFromAPI().subscribe((data: any) => {
      this.contactos = data;
      console.log(options)
      if (options != null) {
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
