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
  selector: 'app-eliminar-cliente',
  standalone: true,
  imports: [],
  templateUrl: './eliminar-cliente.component.html',
  styleUrl: './eliminar-cliente.component.css'
})
export class EliminarClienteComponent {

  data: any;

  constructor(private router: Router, private http: HttpClient, private apiService: ApiService, private location:Location) {

  }
  ngOnInit(): void {
    this.getEstados();
  }
  async eliminarCliente() {
    const id = this.location.path().split("/")[2];
    this.apiService.deleteCliente(id);
    const newPath = this.location.path().split("/")[1];
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
          option.textContent = data[i].estado+"HA"; // Asigna el nombre del cliente como texto del option
          options.appendChild(option); // Agrega el option al elemento select
        }

      }
    });
  }

}
